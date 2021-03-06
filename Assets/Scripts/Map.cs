using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public float MapSize { get { return endPoint.position.z - startPoint.position.z; } }
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform endPoint;
    [SerializeField]
    private GameObject mapOnjects;
    public GameObject MapObject { get { return mapOnjects; } }
}
