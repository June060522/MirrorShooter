using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackObjectOrderInRayer : MonoBehaviour
{
    private GameObject blackBackGround;
    private GameObject whiteBackGround;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        blackBackGround = GameObject.Find("BlackBackGround");
        whiteBackGround = GameObject.Find("WhiteBackGround");
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject == blackBackGround)
        {
            spriteRenderer.sortingOrder = 1;
        }
        else if(other.gameObject == whiteBackGround)
        {
            spriteRenderer.sortingOrder = 2;
        }
    }
}
