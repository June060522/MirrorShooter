using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieSceneScore : MonoBehaviour
{
    Text score;
    int sscore;
    int saveScore;
    void Start()
    {
        score = GetComponent<Text>();
        saveScore = PlayerPrefs.GetInt("Score",0);

        StartCoroutine(UpdateScore());
    }

    IEnumerator UpdateScore()
    {
        while(sscore < saveScore)
        {
            if(saveScore - sscore > 100000)
            {
                sscore += 1000;
                score.text = "Score : " + sscore;
                yield return new WaitForSeconds(0.0000002f);
            }
            else if(saveScore - sscore > 1000)
            {
                sscore += 100;
                score.text = "Score : " + sscore;
                yield return new WaitForSeconds(0.0002f);
            }
            else
            {
                sscore += 50;
                score.text = "Score : " + sscore;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
