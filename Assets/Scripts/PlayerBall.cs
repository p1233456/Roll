using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public bool canMove;
    private bool isGameOver;
    [SerializeField]
    private UnityEvent gameOver;
    [SerializeField]
    private UnityEvent jump;

    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }
    private void Start()
    {
        canMove = false;
    }

    private void FixedUpdate()
    {
        SpeedCheck();
        Move();
    }

    private void Update()
    {
        if (tag != "Finish")
        {
            InputKey();
            GameOverCheck();
        }
    }
    
    private void SpeedCheck()
    {
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
    }

    private void Move()
    {
        if (speed < maxSpeed && canMove)
            movePower = 1f;
        else
            movePower = 0;
         rigid.AddForce(new Vector3(horizontal, 0, movePower), ForceMode.Impulse);
    }

    private void Jump()
    {
        if (!isJump)
        {
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            isJump = true;
            jump.Invoke();
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

    public void StartMove()
    {
        canMove = true;
    }

    private void GameOverCheck()
    {
        if (transform.position.y < -5)
            GameOver();
    }

    private void GameOver()
    {
        if (tag != "Finish")
            gameOver.Invoke();
    }
}
