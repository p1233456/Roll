using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CrackerPower : MonoBehaviour
{
    [SerializeField]
    private float crackerRate;
    [SerializeField]
    private int currentCrackerPiece;
    [SerializeField]
    private int requireCrakcerPiece;
    [SerializeField]
    private UnityEvent startEvent;
    [SerializeField]
    private UnityEvent endEvent;

    [SerializeField]
    private Image crackerImage;
    [SerializeField]
    private float continueTime;

    // Update is called once per frame
    void Update()
    {
        crackerRate = (float)currentCrackerPiece / requireCrakcerPiece;
        Debug.Log(crackerRate);
        UpdateUI();
        if (crackerRate > 0.99)
            StartCoroutine(CrackerPowerEvent());
    }

    public void GetCrackerPiece(int num)
    {
        currentCrackerPiece += num;
    }

    public void GetCrackerPower()
    {
        currentCrackerPiece = 0;
        gameObject.tag = "Cracker";
    }
    public void EndCrackerPower()
    {
        gameObject.tag = "Player";
    }

    private void UpdateUI()
    {
        crackerImage.fillAmount = crackerRate;
    }

    IEnumerator CrackerPowerEvent()
    {
        StartEvent();
        yield return new WaitForSeconds(continueTime);
        EndEvent();
    }

    public void StartEvent()
    {
        startEvent.Invoke();
    }

    public void EndEvent()
    {
        endEvent.Invoke();
    }
}
