using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrackerPower : MonoBehaviour
{
    private float crackerRate;
    [SerializeField]
    private int currentCrackerPiece;
    [SerializeField]
    private int requireCrakcerPiece;
    [SerializeField]
    private UnityEvent crakcerPower;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        crackerRate = currentCrackerPiece / requireCrakcerPiece;
        if (crackerRate > 0.99)
            GetCrackerPower();
    }

    public void GetCrackerPiece(int num)
    {
        currentCrackerPiece += num;
    }

    public void GetCrackerPower()
    {
        crakcerPower.Invoke();
    }
}
