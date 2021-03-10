using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wall : MonoBehaviour
{
    #region Serialize Private Field
    [SerializeField]
    private UnityEvent touchPlayer;
    [SerializeField]
    private UnityEvent touchCracker;
    #endregion

    #region MonoBehaviour CallBacks
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
        if (collision.gameObject.CompareTag("Cracker"))
        {
            touchCracker.Invoke();
            Destroy(gameObject);
        }
    }
    #endregion
}
