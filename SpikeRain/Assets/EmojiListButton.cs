using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class EmojiListButton : MonoBehaviour
{
    [SerializeField] EmojiManager emojiManager;
    [SerializeField] bool isLeft;
    [SerializeField] TextMeshProUGUI emojiText;

    private Tween myTween;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetButtonInteract();
    }

    public void SetButtonInteract()
    {
        if (emojiManager.showing == 0 && isLeft)
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        else if (emojiManager.emojis.Length - 1 == emojiManager.showing && !isLeft)
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void Previous()
    {
        emojiManager.showing--;
        emojiText.text = (emojiManager.showing + 1).ToString() + "/" + emojiManager.emojis.Length;
        //StartCoroutine(PumpMiddle());
    }
    public void Next()
    {
        emojiManager.showing++;
        emojiText.text = (emojiManager.showing + 1).ToString() + "/" + emojiManager.emojis.Length;
        //StartCoroutine(PumpMiddle());
    }

    private IEnumerator PumpMiddle()
    {
        yield return new WaitForSeconds(0.5f);
        emojiManager.Showing();
        myTween.Kill();
        myTween = null;

        foreach (Transform child in emojiManager.transform)
        {
            if (child.name == "CentralImage")
            {
                child.transform.localScale = new Vector3(1, 1, 1);

                var previous = child.transform.localScale;
                var localScale = child.transform.localScale;

                child.transform.DOScale(new Vector3(localScale.x + (localScale.x * 50 / 100), localScale.y + (localScale.y * 50 / 100), localScale.z), 0.2f);
                yield return new WaitForSeconds(0.1f);
                child.transform.DOScale(new Vector3(previous.x, previous.y, previous.z), 0.2f);
                //myTween = DOTween.Sequence()
                //           .Append(child.transform.DOScale(new Vector3(localScale.x + (localScale.x * 50 / 100), localScale.y + (localScale.y * 50 / 100), localScale.z), 0.2f))
                //           .Append(child.transform.DOScale(new Vector3(previous.x, previous.y, previous.z), 0.2f));

            }
        }
        //myTween.Kill();
    }
}
