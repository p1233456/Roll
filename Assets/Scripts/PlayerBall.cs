using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    private Rigidbody rigid;
    private float horizontal;
    private bool isJump;

    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        InputKey();
    }

    private void Move()
    {
        rigid.AddForce(new Vector3(horizontal, 0, 1), ForceMode.Impulse);
    }

    private void Jump()
    {
        if (!isJump)
        {
            rigid.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            isJump = true;
        }
    }

    private void InputKey()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJump = false;
        }
    }
}
