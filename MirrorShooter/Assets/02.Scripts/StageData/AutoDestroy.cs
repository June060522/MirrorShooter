using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField]StageData stageData;

    private void Update()
    {
        if(transform.position.x < stageData.MinLimit.x ||
        transform.position.x > stageData.MaxLimit.x ||
        transform.position.y < stageData.MinLimit.y ||
        transform.position.y > stageData.MaxLimit.y)
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
