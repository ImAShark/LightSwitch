using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    [SerializeField] private Transform start, end;
    [SerializeField] private float laserWidth;
    LineRenderer laserLine;

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.SetWidth(laserWidth,laserWidth);
    }

    void Update()
    {
        laserLine.SetPosition(0,start.position);
        laserLine.SetPosition(1,end.position);
    }
}
