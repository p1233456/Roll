using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    private Rigidbody rigid;
    private float horizontal;

    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigid.AddForce(new Vector3(horizontal, 0, 1), ForceMode.Impulse);
    }
}
