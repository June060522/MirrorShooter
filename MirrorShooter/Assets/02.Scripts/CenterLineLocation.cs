using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterLineLocation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("BlackPlayer"))
        {
            if (transform.rotation.y >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                Debug.Log("바뀜");
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                Debug.Log(transform.rotation.y);
            }
        }
    }
}
