using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracticeBoss3Hp : MonoBehaviour
{
    Slider slider;
    [SerializeField]PracticeBoss3White boss3WhiteManager;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = boss3WhiteManager.hp / boss3WhiteManager.maxHp; 
    }
}
