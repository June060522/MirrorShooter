using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void OpenRealPanel(GameObject _panel)
    {
        _panel.SetActive(true);
    }

    public void CloseRealPanel(GameObject _panel)
    {
        _panel.SetActive(false);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
