using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBestScore : MonoBehaviour
{
    Text bestScoreText;
    [SerializeField] PlayerManager playerManager;
    private void Awake()
    {
        bestScoreText = GetComponent<Text>();
    }
    void Update()
    {
        bestScoreText.text = "BestScore : " + PlayerPrefs.GetInt("BestScore",0);
    }
}
