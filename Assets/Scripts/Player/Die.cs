using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Die : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    public Action PlayerDied;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "DeathBarrier")
        {
            PlayerDied();
            Destroy(parent);
        }
    }
}
