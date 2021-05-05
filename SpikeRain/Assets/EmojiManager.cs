using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EmojiItem
{
    public Sprite sprite = null;
    public int id = 0;
    public EmojiItem next;
    public EmojiItem previous;
}

public class EmojiManager : MonoBehaviour
{
    [SerializeField] public Sprite[] emojis;
    [SerializeField] public Button playButton;
    [SerializeField] public SelectedEmoji selectedEmoji;

    public int showing = 0;
    string[] unlockedEmojisSA;
    string unlockedEmojisString;
    string key;

    //LinkedList<EmojiItem> emojiList = null;

    //public Sprite[] showingArray;
    // Start is called before the first frame update
    void Start()
    {
        //emojiList = null;
        SeparateBoughtEmojiList();
        //AddUnlocked();
        //AddLocked();
    }

    // Update is called once per frame
    void Update()
    {
        Showing();
    }

    //public void AddUnlocked()
    //{
    //    emojiList = new LinkedList<EmojiItem>();
    //    foreach (var emoji in unlockedEmojisSA)
    //    {
    //        emojiList.AddLast(new EmojiItem { sprite = emojis[Int32.Parse(emoji)], id = Int32.Parse(emoji) });
    //    }
    //}

    //public void AddLocked()
    //{
    //    for (int i = 0; i < emojis.Length; i ++)
    //    {
    //        foreach (var unlockedEmoji in unlockedEmojisSA)
    //        {
    //            if (Int32.Parse(unlockedEmoji) == i)
    //            {
    //                break;
    //            }
    //        }
    //        emojiList.AddLast(new EmojiItem { sprite = emojis[i], id = i });
    //    }
    //}

    //public EmojiItem ListAdd(EmojiItem root, Sprite sprite, int id)
    //{
    //    EmojiItem node = new EmojiItem();
    //    node.sprite = sprite;
    //    node.id = id;

    //    if (root == null)
    //    {
    //        return node;
    //    }
    //    root.next = node;
    //    return node;
    //}


    public void SeparateBoughtEmojiList()
    {
        key = "unlockedEmoji";
        if (!PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.SetString(key, "0");
        }
        unlockedEmojisString = PlayerPrefs.GetString(key, "0");
        unlockedEmojisSA = unlockedEmojisString.Split('-');
    }

    public bool HasEmoji(int position)
    {
        if (position == 0)
        {
            return true;
        }

        foreach (var unlockedEmoji in unlockedEmojisSA)
        {
            if (unlockedEmoji == (position).ToString())
            {
                return true;
            }
        }
        return false;
    }

    public void HideOrNot(Transform child, int position, bool half = true)
    {
        if (!HasEmoji(position))
        {
            child.GetComponent<Image>().color = new Color(0f, 0f, 0f, (half ? 0.5f : 1f));
            if (!half) {
                playButton.interactable = false;
                playButton.transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            }
        }
        else{
            child.GetComponent<Image>().color = new Color(1f, 1f, 1f, (half ? 0.5f : 1f));
            if (!half)
            {
                playButton.interactable = true;
                playButton.transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }
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

                if (showing == selectedEmoji.GetSelectedInt())
                {
                    var rot = new Vector3(0, 0, 360);
                    DOTween.Sequence().
                    Append(child.DORotate(rot, 30f, RotateMode.LocalAxisAdd).SetLoops(1, LoopType.Restart));
                }
                else
                {
                    child.transform.Rotate(0, 0, 0);
                    DOTween.Clear();
                    child.transform.rotation = Quaternion.identity;
                }
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

    public void AddBought(int bought)
    {
        PlayerPrefs.SetString(key, unlockedEmojisString + "-" + bought.ToString());
        SeparateBoughtEmojiList();
    }
}
