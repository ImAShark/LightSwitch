using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Die : MonoBehaviour
{
    [SerializeField] private GameObject mainParent;
    public Action PlayerDied;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeathBarrier")
        {
            PlayerDied();
            Destroy(mainParent);
        }
    }
}
