using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    [SerializeField]private float maxEnergy = 100,energyCost,rechargeRate;
    private float energy;
    [SerializeField]private GameObject laser;
    private bool isCharging = false;
    
    void Start()
    {
        energy = maxEnergy;
        laser.SetActive(false);
    }

    void Update()
    {
        FireLaser();
    }

    private void FireLaser()
    {
        if (Input.GetKey(KeyCode.Mouse0) && energy > 0 && !isCharging)
        {
            laser.SetActive(true);
            energy = energy - energyCost * Time.deltaTime;
        }
        else
        {
            laser.SetActive(false);                     
        }

        if (energy >= maxEnergy)
        {
            energy = maxEnergy;
        }
        else
        {
            energy += rechargeRate * Time.deltaTime;
        }
        if (energy < 0 && laser.activeSelf)
        {
            isCharging = true;
        }
        else if (energy >= 5)
        {
            isCharging = false;
        }
    }
}
