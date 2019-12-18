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
        float seed = Random.Range(0, 100);

        for(int h = 0; h < mapHeight; h++)
        {
            for(int w = 0; w < mapWidth; w++)
            {
                int result = (int)(Mathf.PerlinNoise(w / 10.0f + seed,h / 10.0f + seed) * 10);
                Vector3 pos = new Vector3(w * buildingSpacing,0,h * buildingSpacing);
                if(result < 2)
                {
                    Instantiate(buildings[0],pos,Quaternion.identity);
                }
                else if(result < 4)
                {
                    Instantiate(buildings[1],pos,Quaternion.identity);
                }
                else if(result < 6)
                {
                    Instantiate(buildings[2],pos,Quaternion.identity);
                }
                else if(result < 8)
                {
                    Instantiate(buildings[3],pos,Quaternion.identity);
                }
                else if(result < 10)
                {
                    Instantiate(buildings[4],pos,Quaternion.identity);
                }
            }
        }
    }
}
