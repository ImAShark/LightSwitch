using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    [SerializeField]private GameObject floor;
    private GameObject[,] floors;
    [SerializeField]private int gridSizeX, gridSizeZ;

    public GameObject[,] Floors { get => floors;}

    void Start()
    {
        floors = new GameObject[gridSizeX,gridSizeZ];
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                floors[x, z] = Instantiate(floor, new Vector3(x * 5, 0, z * -5), Quaternion.identity);
                floors[x, z].gameObject.transform.parent = gameObject.transform;
            }
        }
        GetComponent<DangerZones>().enabled = true;
    }

    public int GetSizeX()
    {
        return gridSizeX;
    }

    public int GetSizeZ()
    {
        return gridSizeZ;
    }

}
