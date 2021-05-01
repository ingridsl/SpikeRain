using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmojiManager : MonoBehaviour
{
    [SerializeField] public Sprite[] emojis;

    public int showing = 0;
    string[] unlockedEmojisSA;
    // Start is called before the first frame update
    void Start()
    {
        var key = "unlockedEmoji";
        if (!PlayerPrefs.HasKey(key)){
            PlayerPrefs.SetString(key, "0");
        }
        var unlockedEmojisString = PlayerPrefs.GetString(key, "0");
        unlockedEmojisSA = unlockedEmojisString.Split('-');
    }

    // Update is called once per frame
    void Update()
    {
        Showing();
    }

    public bool HasEmoji(int position)
    {
        if (position == 0)
        {
            return true;
        }

        foreach (var unlockedEmoji in unlockedEmojisSA)
        {
            return (unlockedEmoji == (position).ToString());
        }
        return false;
    }

    public void HideOrNot(Transform child, int position, bool half = true)
    {
        if (!HasEmoji(position))
        {
            child.GetComponent<Image>().color = new Color(0f, 0f, 0f, (half ? 0.5f : 1f));
        }
        else{
            child.GetComponent<Image>().color = new Color(1f, 1f, 1f, (half ? 0.5f : 1f));
        }
    }

    public void Showing()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "LeftImage")
            {
                HideOrNot(child, showing - 1);
                if (showing > 0)
                {
                    child.GetComponent<Image>().sprite = emojis[showing - 1];
                }
                else
                {
                    child.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                }
            }
            else if(child.name == "CentralImage")
            {
                HideOrNot(child, showing, false);
                child.GetComponent<Image>().sprite = emojis[showing];
            }
            else if (child.name == "RightImage")
            {
                HideOrNot(child, showing + 1);
                if (showing == emojis.Length - 1)
                {
                    child.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                }
                else
                {
                    child.GetComponent<Image>().sprite = emojis[showing + 1];
                }
            }
        }
    }
}
