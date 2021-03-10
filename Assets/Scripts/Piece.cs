using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Piece : Item
{
    [SerializeField]
    private MyIntEvent getCracker;
    [SerializeField]
    private int crackerPiece;
    protected override void Start()
    {
        base.Start();
        getCracker.AddListener(FindObjectOfType<CrackerPower>().GetComponent<CrackerPower>().GetCrackerPiece);
    }

    protected override void TouchPlayerEvent()
    {
        base.TouchPlayerEvent();
        getCracker.Invoke(crackerPiece);
    }
}
