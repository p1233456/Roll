using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    private Rigidbody rigid;
    private float horizontal;
    private bool isJump;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float movePower;
    [SerializeField]
    private float jumpPower;
    private Vector3 lastPosition = Vector3.zero;

    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }
    private void Start()
    {

    }

    private void FixedUpdate()
    {
        SpeedCheck();
        Move();
    }

    private void Update()
    {
        InputKey();
    }
    
    private void SpeedCheck()
    {
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
    }

    private void Move()
    {
        if (speed < maxSpeed)
            movePower = 1f;
        else
            movePower = 0;
         rigid.AddForce(new Vector3(horizontal, 0, movePower), ForceMode.Impulse);
    }

    private void Jump()
    {
        if (!isJump)
        {
            Debug.Log("jump position : " + transform.position);
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
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
            Debug.Log("low position" + transform.position);
            isJump = false;
        }
    }
}
