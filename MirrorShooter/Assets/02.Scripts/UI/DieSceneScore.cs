using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieSceneScore : MonoBehaviour
{
    Text score;
    void Start()
    {
        score = GetComponent<Text>();
        score.text = "Score : " + PlayerPrefs.GetInt("Score",0);;
    }

    void Update()
    {
        
    }
}
