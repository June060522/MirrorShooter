using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinkePlayer : MonoBehaviour
{
    SpriteRenderer blackPlayerSR;
    SpriteRenderer WhitePlayerSR;

    private void Awake()
    {
        blackPlayerSR = GameObject.Find("BlackPlayer").GetComponent<SpriteRenderer>();
        WhitePlayerSR = GameObject.Find("WhitePlayer").GetComponent<SpriteRenderer>();    
    }

    public void Twinke()
    {
        Debug.Log("123123");
        StartCoroutine(TwinkeON());
    }

    IEnumerator TwinkeON()
    {
        yield return StartCoroutine(Fade(1,0));
        yield return StartCoroutine(Fade(0,1));
    }

    IEnumerator Fade(float start, float end)
    {
        float currentTime = 0;
        float percent = 0;
        while(percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / 0.1f;
            
            Color color = blackPlayerSR.color;
            color.a = Mathf.Lerp(start,end,percent);
            blackPlayerSR.color = color;

            Color color1 = WhitePlayerSR.color;
            color1.a = Mathf.Lerp(start,end,percent);
            WhitePlayerSR.color = color1;

            yield return null;
        }
    }    
}
