using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent gameStart;
    [SerializeField]
    private UnityEvent gameOver;

    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject reStartButton;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        reStartButton.SetActive(false);
    }
    public void GameStart()
    {
        gameStart.Invoke();
        startButton.SetActive(false);
    }

    public void GameOver()
    {
        gameOver.Invoke();
        gameOverPanel.SetActive(true);
        reStartButton.SetActive(true);
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene("Game Scene");
    }
}
