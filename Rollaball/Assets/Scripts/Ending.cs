
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int total_score = PlayerPrefs.GetInt("TOTAL SCORE", 0);
        TextMeshProUGUI gui = GetComponent<TextMeshProUGUI>();
        gui.text = total_score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}