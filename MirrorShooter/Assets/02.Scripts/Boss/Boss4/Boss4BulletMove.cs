using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4BulletMove : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * 3 * Time.deltaTime);
    }
}
