using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCity : MonoBehaviour
{
    [Header("Model Configuration")]
    public GameObject[] features;
    public GameObject[] trees;
    public GameObject xStreet;
    public GameObject zStreet;
    public GameObject CrossRoad;
    Vector3 buildingVariance;
    Vector3 treePosVariance;
    [Space]

    [Header("Map Generation")]
    [Range(0, 250)]
    public int mapWidth = 200;
    [Range(0, 250)]
    public int mapHeight = 200;
    [Range(0, 1000)]
    public float seed = 0;
    [Range(0, 100)]
    public int xRoadAmount = 50;
    [Range(0, 100)]
    public int zRoadAmount = 50;
    [Range(0,100)]
    public int xRoadFrequencyMin = 3;
    [Range(0,100)]
    public int xRoadFrequencyMax = 3;
    [Range(0,100)]
    public int zRoadFrequencyMin = 2;
    [Range(0,100)]
    public int zRoadFrequencyMax = 20;
    [Range(0, 5)]
    public int buildingSpacing = 4;
    [Space]
    
    [Header("Enable/Disable Features")]
    public bool enableRandomSeed = true;
    public bool enableTrees = true;
    public bool enableTreePositionVariance = true;
    public bool enableBuildingPositionVariance = true;
    public bool enableParkBenches = true;
    public bool enableMultipleTreeTypes = true;

    [HideInInspector]
    public int[,] map;
    

    void Start()
    {
        map = new int[mapWidth, mapHeight];
        if (enableRandomSeed)
        {
            seed = Random.Range(0, 1000);
        }

        for(int Height = 0; Height < mapHeight; Height++)
        {
            for(int Width = 0; Width < mapWidth; Width++)
            {
                map[Width,Height] = (int)(Mathf.PerlinNoise(Width / 10.0f + seed, Height / 10.0f + seed) * 10);
            }
        }

        int xFreq = 0;
        for (int amt = 0; amt < xRoadAmount; amt++)
        {
            for (int Height = 0; Height < mapHeight; Height++)
            {
                map[xFreq,Height] = -1;
            }
            xFreq += Random.Range(xRoadFrequencyMin,xRoadFrequencyMax);
            if(xFreq >= mapWidth) break;
        }

        int zFreq = 0;
        for (int amt = 0; amt < zRoadAmount; amt++)
        {
            for (int Width = 0; Width < mapWidth; Width++)
            {
                if (map[Width,zFreq] == -1)
                {
                    map[Width,zFreq] = -3;
                }
                else
                {
                    map[Width,zFreq] = -2;
                }
            }
            zFreq += Random.Range(zRoadFrequencyMin,zRoadFrequencyMax);
            if(zFreq >= mapHeight) break;
        }

        for(int Height = 0; Height < mapHeight; Height++)
        {
            for(int Width = 0; Width < mapWidth; Width++)
            {
                int currentLocation = map[Width,Height];
                Vector3 pos = new Vector3(Width * buildingSpacing, 0, Height * buildingSpacing);
                if(currentLocation < -2)
                {
                    Instantiate(CrossRoad,pos,CrossRoad.transform.rotation);
                }
                else if(currentLocation < -1)
                {
                    Instantiate(xStreet,pos,xStreet.transform.rotation);
                    if(enableParkBenches)
                    {
                        Quaternion benchRot = Quaternion.Euler(-90, -90, 0);
                        if(Random.Range(0, 10) >= 9)
                        {
                            Instantiate(features[6],pos + new Vector3(0, 0.1f, 1.5f),Quaternion.identity * benchRot);
                        }
                    }
                }
                else if(currentLocation < 0)
                {
                    Instantiate(zStreet,pos,zStreet.transform.rotation);
                    if(enableParkBenches)
                    {
                        Quaternion benchRot = Quaternion.Euler(-90, 0, 0);
                        if(Random.Range(0, 10) >= 9)
                        {
                            Instantiate(features[6],pos + new Vector3(1.5f, 0.1f, 0),Quaternion.identity * benchRot);
                        }
                    }
                }
                else if(currentLocation < 1)
                {
                    if(enableBuildingPositionVariance)
                    {
                        buildingVariance = new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1));
                        Instantiate(features[0],pos+buildingVariance,Quaternion.identity);
                    }
                    else
                    {
                        buildingVariance = new Vector3(0, 0, 0);
                        Instantiate(features[0],pos+buildingVariance,Quaternion.identity);
                    }
                }
                else if(currentLocation < 2)
                {
                    Quaternion scraperRot = Quaternion.Euler(0, -90, 0);
                    if(enableBuildingPositionVariance)
                    {
                        buildingVariance = new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1));
                        Instantiate(features[1],pos+buildingVariance,Quaternion.identity * scraperRot);
                    }
                    else
                    {
                        Instantiate(features[1],pos,Quaternion.identity * scraperRot);
                    }
                }
                else if(currentLocation < 4)
                {
                    if(enableBuildingPositionVariance)
                    {
                        buildingVariance = new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1));
                        Instantiate(features[2],pos+buildingVariance,Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(features[2],pos,Quaternion.identity);
                    }
                }
                else if(currentLocation < 6)
                {
                    if(enableBuildingPositionVariance)
                    {
                        buildingVariance = new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1));
                        Instantiate(features[3],pos+buildingVariance,Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(features[3],pos,Quaternion.identity);
                    }
                }
                else if(currentLocation < 7)
                {
                    if(enableBuildingPositionVariance)
                    {
                        buildingVariance = new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1));
                        Instantiate(features[4],pos+buildingVariance,Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(features[4],pos,Quaternion.identity);
                    }
                }
                else if(currentLocation < 10)
                {
                    Instantiate(features[5],pos,Quaternion.identity);
                    int hasTree = Random.Range(0,2);
                    if (hasTree == 0 && enableTrees)
                    {
                        int treeType = Random.Range(0,10);
                        GameObject treeToUse;
                        if (treeType < 2 && enableMultipleTreeTypes)
                        {
                            treeToUse = trees[2];
                        }
                        else if (treeType < 5 && enableMultipleTreeTypes)
                        {
                            treeToUse = trees[1];
                        }
                        else
                        {
                            treeToUse = trees[0];
                        }

                        if (enableTreePositionVariance)
                        {
                            treePosVariance = new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1));
                            Instantiate(treeToUse, pos+treePosVariance, Quaternion.identity);
                        }
                        else
                        {
                            Instantiate(treeToUse, pos, Quaternion.identity);
                        }
                    }
                }
            }
        }
    }
}
