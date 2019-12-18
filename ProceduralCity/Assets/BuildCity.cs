using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCity : MonoBehaviour
{
    public GameObject[] buildings;
    public int mapWidth = 20;
    public int mapHeight = 20;
    public int buildingSpacing = 3;

    void Start()
    {
        for(int h = 0; h < mapHeight; h++)
        {
            for(int w = 0; w < mapWidth; w++)
            {
                Vector3 pos = new Vector3(w * buildingSpacing,0,h * buildingSpacing);
                int rn = Random.Range(0,buildings.Length);
                Instantiate(buildings[rn],pos,Quaternion.identity);
            }
        }
    }
}
