using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    [SerializeField] Canvas Diecanvas;
    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Fade(0,1));
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
        yield return StartCoroutine(ScorePop());
    }

    IEnumerator ScorePop()
    {
        Diecanvas.gameObject.SetActive(true);
        yield return null;
    }
}
