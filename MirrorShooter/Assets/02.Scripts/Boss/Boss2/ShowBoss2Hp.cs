using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBoss2Hp : MonoBehaviour
{
    [SerializeField] Boss2 boss2;
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = boss2.hp / boss2.maxhp;
    }
}
