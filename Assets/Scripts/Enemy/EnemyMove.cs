using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private GameObject player;
    private float health = 100;
    [SerializeField] private float speed = 1;
    private bool playerAlive = true;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        try
        {
            if (playerAlive)
            {
                MoveAndLook();
            }
        }
        catch
        {
            playerAlive = false;
        }

    }

    private void MoveAndLook()
    {
        Vector3 pos = new Vector3(player.transform.position.x - 1.2f,
                                  transform.position.y,
                                  player.transform.position.z - 1.3f);
        transform.LookAt(pos, Vector3.up);
        MoveToPlayer(pos);
    }

    private void MoveToPlayer(Vector3 pos)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,pos,step);
    }
}
