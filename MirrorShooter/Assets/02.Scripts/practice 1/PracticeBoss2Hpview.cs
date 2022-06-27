using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracticeBoss2Hpview : MonoBehaviour
{
    PracticeBoss2 boss2;
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        boss2 = GameObject.Find("Boss2(Clone)").GetComponent<PracticeBoss2>();
    }

    void Update()
    {
        slider.value = boss2.hp / boss2.maxhp;

        if(boss2.Boss2DieCheck)
        {
            Destroy(gameObject);
        }
    }
}
