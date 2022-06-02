using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEnemyManager : MonoBehaviour
{
    private int hp = 3;
    [SerializeField] GameObject BlackBullet;
    void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    IEnumerator SpawnBullet()
    {
        int random = 0;
        while(true)
        {
            random = Random.Range(0,10);
            if(random < 6)
                Instantiate(BlackBullet,this.transform.position,Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BlackBullet"))
        {
            hp--;
        }
    }
}
