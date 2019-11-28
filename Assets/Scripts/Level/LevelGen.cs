using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    [SerializeField]private GameObject floor;
    private GameObject[] floors;
    public int gridSizeX, gridSizeZ;

    void Start()
    {
        for (int i = 0; i < gridSizeX; i++)
        {
            Instantiate(floor, new Vector3(i * 5,0,0), Quaternion.identity);

            for (int j = 0; j < gridSizeZ; j++)
            {
                Instantiate(floor, new Vector3(j * 5, 0, i * -5), Quaternion.identity);
                if (j == gridSizeX)
                {
                    j = 0;
                }
            }
        }
    }//INFINIT LOOP WARNING!

    void Update()
    {
        
    }
}
