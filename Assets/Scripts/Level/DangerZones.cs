using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZones : MonoBehaviour
{
    [SerializeField] Material save, warning, danger;
    [SerializeField]private float dDuration,wDuration,tTimer,speedMultiplier = 0.0001f;
    private float timer,speed = 1;
    private int xSize, zSize, x, z;
    private Collider barrier;

    void Start()
    {
        timer = tTimer;
        xSize = GetComponent<LevelGen>().GetSizeX();
        zSize = GetComponent<LevelGen>().GetSizeZ();
        CreateLocation();
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
            //speed += speedMultiplier;
            GetComponent<LevelGen>().Floors[x, z].gameObject.GetComponent<Collider>().enabled = false;
            CreateLocation();
        }
        else if (timer < dDuration)//danger
        {
            ChangeStage(danger);
            GetComponent<LevelGen>().Floors[x, z].gameObject.GetComponent<Collider>().enabled = true;
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
        x = Random.Range(0,xSize);
        z = Random.Range(0,zSize);
    }

    private void ChangeStage(Material m)
    {        
        GetComponent<LevelGen>().Floors[x, z].gameObject.GetComponent<MeshRenderer>().material = m;        
    }

}
