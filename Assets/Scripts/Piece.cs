using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class MyIntEvent : UnityEvent<int>
{
}

public class Piece : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private MyIntEvent getScore;
    [SerializeField]
    private int score;
    // Start is called before the first frame update
    private void Start()
    {
        getScore.AddListener(FindObjectOfType<ScoreManager>().GetComponent<ScoreManager>().GetScore);
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        //transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.CompareTag("Player"))
        {
            getScore.Invoke(score);
            Destroy(this);
        }
    }
}
