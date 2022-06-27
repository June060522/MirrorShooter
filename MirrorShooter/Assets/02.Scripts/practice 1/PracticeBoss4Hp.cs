using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracticeBoss4Hp : MonoBehaviour
{
    Slider slider;
    [SerializeField]PracticeBoss4 boss4;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = boss4.hp / boss4.maxHp;

        if(boss4.boss4DieCheck)
        {
            Destroy(gameObject);
        }
    }
}
