using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public float MapSize { get { return startPoint.position.z - endPoint.position.z; } }
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform endPoint;
}
