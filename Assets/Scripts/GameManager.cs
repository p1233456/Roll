using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent gameStart;
    [SerializeField]
    private UnityEvent gameOver;

    public void GameStart()
    {
        gameStart.Invoke();
    }

    public void GameOver()
    {
        gameOver.Invoke();
    }
}
