using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameObject player, levelGen;
    [SerializeField] private Material danger;

    void Start()
    {
        player = GameObject.Find("Player");
        levelGen = GameObject.Find("Block");
        var dead = player.GetComponent<Die>();
        dead.PlayerDied += EndGame;
    }

    private void EndGame()//makes all tiles white from tile where player died
    {
        
    }
}
