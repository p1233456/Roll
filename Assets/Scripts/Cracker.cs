using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cracker : Item
{
    [SerializeField]
    protected MyIntEvent getCracker;
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

    protected override void Rotate()
    {

        transform.RotateAround(transform.position, Vector3.left, rotateSpeed * Time.deltaTime);
    }
}
