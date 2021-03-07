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
    protected MyIntEvent touchPlayer;
    [SerializeField]
    protected MyIntEvent touchCracker;
    [SerializeField]
    protected int score; 
    
    protected virtual void Start()
    {
        touchPlayer.AddListener(FindObjectOfType<ScoreManager>().GetComponent<ScoreManager>().GetScore);
        touchCracker.AddListener(FindObjectOfType<ScoreManager>().GetComponent<ScoreManager>().GetScore);
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
            TouchPlayerEvent();
            transform.Translate(new Vector3(0, 0));
        }
        if (other.CompareTag("Cracker"))
        {
            TouchPlayerEvent();
            TouchCrackerEvent();
            transform.Translate(new Vector3(0, 0));
        }
    }

    protected virtual void TouchPlayerEvent()
    {
        touchPlayer.Invoke(score);
    }

    protected virtual void TouchCrackerEvent()
    {
        touchCracker.Invoke(score * 2);
    }
}
