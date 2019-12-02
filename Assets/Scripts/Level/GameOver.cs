using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameObject player, levelGen;
    private GameObject[,] grid;
    [SerializeField] private Material danger;
    private int x, z;

    void Start()
    {
        player = GameObject.Find("PlayerModel");
        levelGen = GameObject.Find("Block");
        var dead = player.GetComponent<Die>();
        dead.PlayerDied += EndGame;
    }

    private void EndGame()//makes all tiles white from tile where player died
    {
        //ChangeColors();
    }

    private void ChangeColors()
    {
        for (int i = 0; i < grid.Length; i++)
        {

        }
    }

    private void ChangeStage(Material m)
    {
        GetComponent<LevelGen>().Floors[x, z].gameObject.GetComponent<MeshRenderer>().material = m;
    }

    public void SetIndex(int a, int b)
    {
        x = a;
        z = b;
    }
}
