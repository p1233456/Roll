using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class MyIntEvent : UnityEvent<int>
{
}

public abstract class Item : MonoBehaviour
{
    [SerializeField]
    protected float rotateSpeed;
    [SerializeField]
    protected MyIntEvent getScore;
    [SerializeField]
    protected int score; 
    
    protected virtual void Start()
    {
        getScore.AddListener(FindObjectOfType<ScoreManager>().GetComponent<ScoreManager>().GetScore);
    }

    protected virtual void Update()
    {
        Rotate();
    }

    protected virtual void Rotate()
    {
        transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.CompareTag("Player"))
        {
            getScore.Invoke(score);
            Destroy(this);
        }
    }
}
