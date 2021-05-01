using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Accumulated : MonoBehaviour
{
    public int accTotal;
    string key = "total";
    // Start is called before the first frame update
    void Start()
    {
        LoadAccumulated();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadAccumulated()
    {
        accTotal = PlayerPrefs.GetInt(key, 0);
        this.gameObject.GetComponent<TextMeshProUGUI>().text = accTotal.ToString();
    }

    public void UpdateAccumulated(int newTotal)
    {
        accTotal = newTotal;
        PlayerPrefs.SetInt(key, accTotal);
        LoadAccumulated();
    }
}
