using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticePlayerHpView : MonoBehaviour
{
    PracticePlayerManager playerManager;
    void Start()
    {
        playerManager = GameObject.Find("BlackPlayer").GetComponent<PracticePlayerManager>();
    }

    public void showHp()
    {
        switch (playerManager.TotalPlayerHp)
        {
            case 6:
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(1).gameObject.SetActive(true);
                this.transform.GetChild(2).gameObject.SetActive(true);
                this.transform.GetChild(3).gameObject.SetActive(true);
                this.transform.GetChild(4).gameObject.SetActive(true);
                this.transform.GetChild(5).gameObject.SetActive(true);
                break;
            case 5:
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(1).gameObject.SetActive(true);
                this.transform.GetChild(2).gameObject.SetActive(true);
                this.transform.GetChild(3).gameObject.SetActive(true);
                this.transform.GetChild(4).gameObject.SetActive(true);
                this.transform.GetChild(5).gameObject.SetActive(false);
                break;
            case 4:
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(1).gameObject.SetActive(true);
                this.transform.GetChild(2).gameObject.SetActive(true);
                this.transform.GetChild(3).gameObject.SetActive(true);
                this.transform.GetChild(4).gameObject.SetActive(false);
                this.transform.GetChild(5).gameObject.SetActive(false);
                break;
            case 3:
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(1).gameObject.SetActive(true);
                this.transform.GetChild(2).gameObject.SetActive(true);
                this.transform.GetChild(3).gameObject.SetActive(false);
                this.transform.GetChild(4).gameObject.SetActive(false);
                this.transform.GetChild(5).gameObject.SetActive(false);
                break;
            case 2:
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(1).gameObject.SetActive(true);
                this.transform.GetChild(2).gameObject.SetActive(false);
                this.transform.GetChild(3).gameObject.SetActive(false);
                this.transform.GetChild(4).gameObject.SetActive(false);
                this.transform.GetChild(5).gameObject.SetActive(false);
                break;
            case 1:
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(1).gameObject.SetActive(false);
                this.transform.GetChild(2).gameObject.SetActive(false);
                this.transform.GetChild(3).gameObject.SetActive(false);
                this.transform.GetChild(4).gameObject.SetActive(false);
                this.transform.GetChild(5).gameObject.SetActive(false);
                break;
            case 0:
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(1).gameObject.SetActive(false);
                this.transform.GetChild(2).gameObject.SetActive(false);
                this.transform.GetChild(3).gameObject.SetActive(false);
                this.transform.GetChild(4).gameObject.SetActive(false);
                this.transform.GetChild(5).gameObject.SetActive(false);
                break;
        }
    }
}
