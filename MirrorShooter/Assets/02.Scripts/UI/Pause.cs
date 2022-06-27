using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public void Option(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume(GameObject panel)
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void ReStart(GameObject panel)
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }
}
