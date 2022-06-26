using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayEnemyBulletManager : MonoBehaviour
{
    private float speed = 7f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(speed * Vector2.down * Time.deltaTime);
    }
}
