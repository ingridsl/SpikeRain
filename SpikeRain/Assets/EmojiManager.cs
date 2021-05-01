using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmojiManager : MonoBehaviour
{
    [SerializeField] public Sprite[] emojis;

    public int showing = 0;
    // Start is called before the first frame update
    void Start()
    {
        LoadEmojis();
    }

    // Update is called once per frame
    void Update()
    {
        Showing();
    }

    public void LoadEmojis()
    {
        for (int i = 0; i < emojis.Length; i++)
        {
            if(i == 0) //emoji inicial sempre disponível - grinning
            {


            }
            else
            {

            }
        }
    }

    public void Showing()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "LeftImage")
            {
                if (showing > 0)
                {
                    child.GetComponent<Image>().sprite = emojis[showing - 1];
                    child.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                }
                else
                {
                    child.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                }
            }
            else if(child.name == "CentralImage")
            {
                child.GetComponent<Image>().sprite = emojis[showing];
                child.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }
            else if (child.name == "RightImage")
            {
                if (showing == emojis.Length - 1)
                {
                    child.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                }
                else
                {
                    child.GetComponent<Image>().sprite = emojis[showing + 1];
                    child.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                }
            }
        }
    }
}
