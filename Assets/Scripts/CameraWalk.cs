using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWalk : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Vector3 offset;

    private bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerTransform.position;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(canMove)
            transform.position = playerTransform.position + offset;
    }

    public void StopMove()
    {
        canMove = false;
    }
}
