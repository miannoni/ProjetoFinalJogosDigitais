using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScript : MonoBehaviour
{
    public Terrain t;
    public GameObject player;
    private float [,] grassHeight;
    public float grassGrowthRate = 0.1f;
    private int [,] initialGrassHeight;

    // Start is called before the first frame update
    void Start()
    {
        var map = t.terrainData.GetDetailLayer(0, 0,
          t.terrainData.detailWidth, t.terrainData.detailHeight, 0);
        initialGrassHeight = map;

        grassHeight = new float[t.terrainData.detailHeight, t.terrainData.detailWidth];
        for (var y = 0; y < t.terrainData.detailHeight; y++)
        {
            for (var x = 0; x < t.terrainData.detailWidth; x++)
            {
                grassHeight[x, y] = map[x, y];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float grass = 0;

        var map = t.terrainData.GetDetailLayer(0, 0,
          t.terrainData.detailWidth, t.terrainData.detailHeight, 0);

        // For each pixel in the detail map...
        for (var y = 0; y < t.terrainData.detailHeight; y++)
        {
            for (var x = 0; x < t.terrainData.detailWidth; x++)
            {
                

                if ((player.transform.position - new Vector3(x*(t.terrainData.size.x / t.terrainData.detailResolution), player.transform.position.y , y*(t.terrainData.size.z / t.terrainData.detailResolution))).magnitude < 2f)
                {
                    
                    grass += grassHeight[y, x];
                    grassHeight[y, x] = 0;

                } else if (grassHeight[y, x] <= initialGrassHeight[x, y])
                {
                    grassHeight[y, x] += grassGrowthRate*Time.deltaTime; // funcao da grama
                }

                map[y, x] = (int) grassHeight[y, x]; 
            }
        }

        // Assign the modified map back.
        t.terrainData.SetDetailLayer(0, 0, 0, map);
        player.SendMessage("Grass", grass);

    }

    void OnDestroy()
    {
        t.terrainData.SetDetailLayer(0, 0, 0, initialGrassHeight);
    }

}
