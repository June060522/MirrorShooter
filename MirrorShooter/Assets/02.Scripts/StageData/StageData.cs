using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [SerializeField] Vector2 minLimit;
    [SerializeField] Vector2 maxLimit;
    public Vector2 MinLimit => minLimit;
    public Vector2 MaxLimit => maxLimit;
}
