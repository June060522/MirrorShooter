using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionScore : MonoBehaviour
{
    PlayerManager playerManager;
    void Start()
    {
        playerManager = GameObject.Find("BlackPlayer").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            playerManager.Score = 5000;
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            playerManager.score = 30000;
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            playerManager.score = 70000;
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            playerManager.score = 130000;
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.SetInt("BestScore",0);
        }
    }
}
