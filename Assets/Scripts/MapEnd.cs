using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapEnd : MonoBehaviour
{
    [SerializeField]
    private UnityEvent playerOutMap;
    [SerializeField]
    private MyIntEvent getScore;
    [SerializeField]
    private int score;
    private void Start()
    {
        playerOutMap.AddListener(FindObjectOfType<LevelManager>().GetComponent<LevelManager>().RemovePassMap);
        getScore.AddListener(FindObjectOfType<ScoreManager>().GetComponent<ScoreManager>().GetScore);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Cracker")) { 
            playerOutMap.Invoke();
            getScore.Invoke(score);
        }
    }
}
