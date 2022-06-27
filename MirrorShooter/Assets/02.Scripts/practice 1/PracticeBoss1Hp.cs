using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracticeBoss1Hp : MonoBehaviour
{
    [SerializeField] PracticeBoss1 boss1;
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = boss1.hp / boss1.maxhp;
    }
}
