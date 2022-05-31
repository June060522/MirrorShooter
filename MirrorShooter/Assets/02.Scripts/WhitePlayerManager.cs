using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitePlayerManager : MonoBehaviour
{
    private Vector2 MinPos = new Vector2 (-17.28f,-9.5f);
    private Vector2 MaxPos = new Vector2 (17.28f,9.5f);
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,MinPos.x,MaxPos.x),Mathf.Clamp(transform.position.y,MinPos.y,MaxPos.y));
    }
}
