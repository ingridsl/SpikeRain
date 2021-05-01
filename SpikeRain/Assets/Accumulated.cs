using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Accumulated : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("total", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
