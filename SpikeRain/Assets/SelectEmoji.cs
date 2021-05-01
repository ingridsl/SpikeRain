using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEmoji : MonoBehaviour
{
    [SerializeField] EmojiManager emojiManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectThisEmoji()
    {
        SelectedEmoji selectedEmoji = GameObject.Find("SelectedEmoji").GetComponent<SelectedEmoji>();
        selectedEmoji.selectedSprite = emojiManager.emojis[emojiManager.showing];
        PlayerPrefs.SetInt("defaultEmoji", emojiManager.showing);
    }
}
