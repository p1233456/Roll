using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapEnd : MonoBehaviour
{
    [SerializeField]
    private UnityEvent playerOutMap;

    private void Start()
    {
        playerOutMap.AddListener(FindObjectOfType<LevelManager>().GetComponent<LevelManager>().RemovePassMap);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerOutMap.Invoke();
    }
}
