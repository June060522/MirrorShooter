using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenScreen : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        gameObject.SetActive(true);
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(Hidden());
    }

    IEnumerator Hidden()
    {
        yield return StartCoroutine(Fade(0,1));
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(Fade(1,0));
    }

    IEnumerator Fade(float start, float end)
    {
        float currentTime = 0;
        float percent = 0;
        while(percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / 0.1f;
            
            Color color = spriteRenderer.color;
            color.a = Mathf.Lerp(start,end,percent);
            spriteRenderer.color = color;

            yield return null;
        }
    }    
}
