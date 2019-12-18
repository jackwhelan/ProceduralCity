using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCity : MonoBehaviour
{
    public GameObject[] buildings;
    public GameObject[] trees;
    public GameObject xStreet;
    public GameObject zStreet;
    public GameObject CrossRoad;
    Vector3 buildingVariance;
    Vector3 treePosVariance;
    public int mapWidth = 20;
    public int mapHeight = 20;
    public int[,] mapgrid;
    public int buildingSpacing = 4;
    public bool Enable_Trees = true;
    public bool Enable_Tree_Position_Variance = true;
    public bool Enable_Building_Position_Variance = true;

    void Start()
    {
        mapgrid = new int[mapWidth, mapHeight];
        float seed = Random.Range(0, 100);

        for(int h = 0; h < mapHeight; h++)
        {
            for(int w = 0; w < mapWidth; w++)
            {
                mapgrid[w,h] = (int) (Mathf.PerlinNoise(w / 10.0f + seed, h / 10.0f + seed) * 10);
            }
        }

        int x = 0;
        for (int n = 0; n < 50; n++)
        {
            for (int h = 0; h < mapHeight; h++)
            {
                mapgrid[x,h] = -1;
            }
            x += Random.Range(3,3);
            if(x >= mapWidth) break;
        }

        int z = 0;
        for (int n = 0; n < 10; n++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                if (mapgrid[w,z] == -1)
                {
                    mapgrid[w,z] = -3;
                }
                else
                {
                    mapgrid[w,z] = -2;
                }
            }
            z += Random.Range(2,20);
            if(z >= mapHeight) break;
        }

        for(int h = 0; h < mapHeight; h++)
        {
            for(int w = 0; w < mapWidth; w++)
            {
                int result = mapgrid[w,h];
                Vector3 pos = new Vector3(w * buildingSpacing, 0, h * buildingSpacing);
                if(result < -2)
                {
                    Instantiate(CrossRoad,pos,CrossRoad.transform.rotation);
                }
                else if(result < -1)
                {
                    Instantiate(xStreet,pos,xStreet.transform.rotation);
                }
                else if(result < 0)
                {
                    Instantiate(zStreet,pos,zStreet.transform.rotation);
                }
                else if(result < 1)
                {
                    if(Enable_Building_Position_Variance)
                    {
                        buildingVariance = new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1));
                        Instantiate(buildings[0],pos+buildingVariance,Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(buildings[0],pos,Quaternion.identity);
                    }
                }
                else if(result < 2)
                {
                    if(Enable_Building_Position_Variance)
                    {
                        buildingVariance = new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1));
                        Instantiate(buildings[1],pos+buildingVariance,Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(buildings[1],pos,Quaternion.identity);
                    }
                }
                else if(result < 4)
                {
                    if(Enable_Building_Position_Variance)
                    {
                        buildingVariance = new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1));
                        Instantiate(buildings[2],pos+buildingVariance,Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(buildings[2],pos,Quaternion.identity);
                    }
                }
                else if(result < 6)
                {
                    if(Enable_Building_Position_Variance)
                    {
                        buildingVariance = new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1));
                        Instantiate(buildings[3],pos+buildingVariance,Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(buildings[3],pos,Quaternion.identity);
                    }
                }
                else if(result < 7)
                {
                    if(Enable_Building_Position_Variance)
                    {
                        buildingVariance = new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1));
                        Instantiate(buildings[4],pos+buildingVariance,Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(buildings[4],pos,Quaternion.identity);
                    }
                }
                else if(result < 10)
                {
                    Instantiate(buildings[5],pos,Quaternion.identity);
                    int hasTree = Random.Range(0,2);
                    if (hasTree == 0 && Enable_Trees)
                    {
                        if (Enable_Tree_Position_Variance)
                        {
                            treePosVariance = new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1));
                            Instantiate(trees[0], pos+treePosVariance, Quaternion.identity);
                        }
                        else
                        {
                            Instantiate(trees[0], pos, Quaternion.identity);
                        }
                    }
                }
            }
        }
    }
}
