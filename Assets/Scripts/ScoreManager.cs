using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int score;
    public int Score { get { return score; } }

    [SerializeField]
    private Text scoreText;

    void Update()
    {
        UIUpdate();
    }

    private void UIUpdate()
    {
        scoreText.text = score + "점";
    }
}
