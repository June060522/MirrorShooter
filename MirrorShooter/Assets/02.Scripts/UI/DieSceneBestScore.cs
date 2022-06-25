using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieSceneBestScore : MonoBehaviour
{
    Text bestScore;
    void Start()
    {
        bestScore = GetComponent<Text>();
        bestScore.text = "BestScore : " + PlayerPrefs.GetInt("BestScore",0);
    }

    void Update()
    {
        
    }
}
