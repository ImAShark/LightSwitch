using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZones : MonoBehaviour
{
    [SerializeField] Material save, warning, danger;
    [SerializeField]private float dDuration,wDuration,tTimer,speedMultiplier = 0.0001f;
    private float timer,speed = 1;
    private int xSize, zSize;


    void Start()
    {
        timer = tTimer;
        xSize = GetComponent<LevelGen>().GetSizeX();
        zSize = GetComponent<LevelGen>().GetSizeZ();
    }

    void Update()
    {
        ActivateZone();
        //Debug.Log(timer);
    }

    private void ActivateZone()
    {
        if (timer <= 0)//reset
        {
            ChangeStage(save);
            timer = tTimer;
            speed += speedMultiplier;
        }
        else if (timer < dDuration)//danger
        {
            ChangeStage(danger);
            CountDown();
        }
        else if (timer < wDuration)//warning
        {
            ChangeStage(warning);
            CountDown();
        }
        else//counter
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
        int x = Random.Range(0,xSize);
        int z = Random.Range(0,zSize);
    }

    private void ChangeStage(Material m)
    {
        GetComponent<LevelGen>().Floors[0, 0].gameObject.GetComponent<MeshRenderer>().material = m;
    }

}
