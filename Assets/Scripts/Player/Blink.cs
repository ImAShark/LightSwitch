using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private float rechargeTime;
    [SerializeField] int maxCharges;
    private int charges;
    private float timer;

    void Start()
    {
        timer = rechargeTime;
        charges = maxCharges;
    }

    void Update()
    {
        if (timer <= 0)
        {
            if (charges != maxCharges)
            {
                charges++;
            }
            
            timer = rechargeTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        BlinkTowards();
    }

    private void BlinkTowards()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && charges > 0)
        {
            Vector3 mouse = Input.mousePosition;
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(
                                                                mouse.x,
                                                                mouse.y,
                                                                transform.position.y));
            transform.position = new Vector3(mouseWorld.x + 1.2f,
                                            transform.position.y,
                                            mouseWorld.z + 1.1f) ;
            charges--;
        }

        
    }
}
