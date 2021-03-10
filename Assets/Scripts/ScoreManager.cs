using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region Serialize Private Variable
    [SerializeField]
    private int score;

    [SerializeField]
    private Text scoreText;
    #endregion

    #region Property
    public int Score { get { return score; } }
    #endregion

    #region MonoBehavior CallBacks
    void Update()
    {
        UIUpdate();
    }
    #endregion

    #region Public Method

    public void GetScore(int score)
    {
        this.score += score;
    }

    #endregion

    #region Private Method

    private void UIUpdate()
    {
        scoreText.text = score + "점";
    }

    #endregion
}
