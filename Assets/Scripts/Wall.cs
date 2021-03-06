using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private UnityEvent touchPlayer;
    private void Awake()
    {
        touchPlayer.AddListener(FindObjectOfType<GameManager>().GetComponent<GameManager>().GameOver);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touchPlayer.Invoke();
        }
    }
}
