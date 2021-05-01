using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedEmoji : MonoBehaviour
{
    //public Image selectedImage;
    public Sprite selectedSprite;

    SpriteRenderer playerSpriteRenderer;

    [SerializeField] EmojiManager emojiManager;
    string key;
    // Start is called before the first frame update
    void Start()
    {
        GetDefaultEmoji();
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerImage();
    }

    public void GetDefaultEmoji()
    {
        key = "defaultEmoji";
        if (!PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.SetInt(key, 0);
        }
        selectedSprite = emojiManager.emojis[GetSelectedInt()];
    }

    public int GetSelectedInt()
    {
        return PlayerPrefs.GetInt(key, 0);
    }

    void SetPlayerImage()
    {

        if (playerSpriteRenderer == null)
        {
            var player = GameObject.Find("Player");
            if (player != null)
            {
                playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
            }
        }
        if (playerSpriteRenderer != null && playerSpriteRenderer.sprite != selectedSprite)
        {
            playerSpriteRenderer.sprite = selectedSprite;
        }
    }
}
