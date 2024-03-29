﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZones : MonoBehaviour
{
    [SerializeField] Material save, warning, danger;
    [SerializeField]private float dDuration,wDuration,tTimer,speedMultiplier = 0.0001f;
    private GameObject player;
    private float timer,speed = 1;
    private int xSize, zSize, x, z;
    private Collider barrier;
    private bool playerAlive = true;

    void Start()
    {
        timer = tTimer;
        xSize = GetComponent<LevelGen>().GetSizeX();
        zSize = GetComponent<LevelGen>().GetSizeZ();
        CreateLocation();

        player = GameObject.Find("PlayerModel");
        var dead = player.GetComponent<Die>();
        dead.PlayerDied += StopChanging;
    }

    void Update()
    {
        ActivateZone();
    }

    private void ActivateZone()
    {
        if (timer <= 0 && playerAlive)//reset
        {
            ChangeStage(save);
            timer = tTimer;
            //speed += speedMultiplier;
            GetComponent<LevelGen>().Floors[x, z].gameObject.GetComponent<Collider>().enabled = false;
            CreateLocation();
        }
        else if (timer < dDuration && playerAlive)//danger
        {
            ChangeStage(danger);
            GetComponent<LevelGen>().Floors[x, z].gameObject.GetComponent<Collider>().enabled = true;
            CountDown();
        }
        else if (timer < wDuration && playerAlive)//warning
        {
            ChangeStage(warning);
            CountDown();
        }
        else if(playerAlive)//counter
        {
            CountDown();
        }
    }

    private void CountDown()
    {
        timer -= Time.deltaTime + speed;
    }

    private void CreateLocation()
    {
        x = Random.Range(0,xSize);
        z = Random.Range(0,zSize);
    }

    private void ChangeStage(Material m)
    {        
        GetComponent<LevelGen>().Floors[x, z].gameObject.GetComponent<MeshRenderer>().material = m;        
    }

    private void StopChanging()
    {
        playerAlive = false;
    }

}
