using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmojiListButton : MonoBehaviour
{
    [SerializeField] EmojiManager emojiManager;
    [SerializeField] bool isLeft;
    [SerializeField] TextMeshProUGUI emojiText;
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
    }
    public void Next()
    {
        emojiManager.showing++;
        emojiText.text = (emojiManager.showing + 1).ToString() + "/" + emojiManager.emojis.Length;
    }
}
