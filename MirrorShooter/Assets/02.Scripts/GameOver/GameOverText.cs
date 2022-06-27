using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    Text text;
    private void OnEnable()
    {
        text = GetComponent<Text>();
        StartCoroutine(GameOverTextWhite());
    }

    IEnumerator GameOverTextWhite()
    {
        while(true)
        {
            for(float i = 0; i <1; i += 0.01f)
            {
                Color color = text.color;
                color.r = i;
                color.g = i;
                color.b = i;
                text.color = color;
                yield return new WaitForSeconds(0.01f);
            }
            for(float i = 1; i > 0; i -= 0.01f)
            {
                Color color = text.color;
                color.r = i;
                color.g = i;
                color.b = i;
                text.color = color;
                yield return new WaitForSeconds(0.01f);
            }
            yield return null;
        }
    }
}
