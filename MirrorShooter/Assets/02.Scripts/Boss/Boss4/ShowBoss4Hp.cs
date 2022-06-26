using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBoss4Hp : MonoBehaviour
{
    Slider slider;
    [SerializeField]Boss4 boss4;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = boss4.hp / boss4.maxHp;
    }
}
