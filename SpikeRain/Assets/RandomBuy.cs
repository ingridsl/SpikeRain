using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class RandomBuy : MonoBehaviour
{
    [SerializeField] int price;
    [SerializeField] EmojiManager emojiManager;
    [SerializeField] Accumulated accumulated;
    [SerializeField] TextMeshProUGUI emojiText;
    [SerializeField] Image middleEmoji;

    // Start is called before the first frame update
    void Start()
    {
        SetButton();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetButton()
    {
        if (accumulated.accTotal == 0)
        {
            accumulated.LoadAccumulated();
        }

        var priceText = this.transform.GetComponentInChildren<TextMeshProUGUI>();

        priceText.text = price.ToString();
        if (accumulated.accTotal < price) //não pode comprar
        {
            this.gameObject.GetComponent<Button>().interactable = false;
            var images = this.gameObject.GetComponentsInChildren<Image>();
            foreach (var image in images)
            {
                if (image.gameObject.name != "BuyButton")
                {
                    if (image.gameObject.name == "CoinImage")
                    {
                        image.color = new Color(255f / 255f, 213f / 255f, 79f / 255f, 0.5f);
                    }
                    else
                    {
                        image.color = new Color(1f, 1f, 1f, 0.5f);
                    }
                }
            }
        }
        else //pode comprar
        {
            this.gameObject.GetComponent<Button>().interactable = true;
            var images = this.gameObject.GetComponentsInChildren<Image>();
            foreach (var image in images)
            {
                if (image.gameObject.name != "BuyButton")
                {
                    if (image.gameObject.name == "CoinImage")
                    {
                        image.color = new Color(255f / 255f, 213f / 255f, 79f / 255f, 1f);
                    }
                    else
                    {
                        image.color = new Color(1f, 1f, 1f, 1f);
                    }
                }
            }
        }

    }

    public void Buy()
    {
        var hasEmoji = false;
        var toBuy = 0;
        do
        {
            toBuy = Random.Range(1, emojiManager.emojis.Length);
            hasEmoji = emojiManager.HasEmoji(toBuy);

        } while (hasEmoji);

        StartCoroutine(MoveToBought(toBuy));
    }

    private IEnumerator MoveToBought(int toBuy)
    {
        if (toBuy < emojiManager.showing)
        {
            while (toBuy != emojiManager.showing)
            {
                emojiManager.showing--;
                yield return new WaitForSeconds(0.5f);
            }
        }
        else
        {
            while (toBuy != emojiManager.showing)
            {
                emojiManager.showing++;
                emojiText.text = (emojiManager.showing + 1).ToString() + "/" + emojiManager.emojis.Length;
                yield return new WaitForSeconds(0.5f);
            }
        }
        StartCoroutine(AddAsBought(toBuy));
    }

    private IEnumerator AddAsBought(int bought)
    {
        var middleImage = middleEmoji.GetComponent<Image>();
        var localScale = middleEmoji.transform.localScale;

        var sequence = DOTween.Sequence()
        .Append(middleEmoji.transform.DOScale(localScale + (localScale * 10 / 100), 0.5f))
        .Append(middleImage.DOColor(new Color(1f, 1f, 1f, 1f), 4));

        yield return new WaitForSeconds(4f);

        middleImage.color = new Color(1f, 1f, 1f, 1f);
        emojiManager.AddBought(bought);
    }
    
}
