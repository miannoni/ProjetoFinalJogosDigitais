using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScript : MonoBehaviour
{
    public Terrain t;
    public GameObject player;
    private float [,] grassHeight;
    public float grassGrowthRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        //print(t.terrainData.detailHeight);
        //print(t.terrainData.detailWidth);
        grassHeight = new float[t.terrainData.detailHeight, t.terrainData.detailWidth];
        for (var y = 0; y < t.terrainData.detailHeight; y++)
        {
            for (var x = 0; x < t.terrainData.detailWidth; x++)
            {
                grassHeight[x, y] = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        var map = t.terrainData.GetDetailLayer(0, 0,
          t.terrainData.detailWidth, t.terrainData.detailHeight, 0);

        // For each pixel in the detail map...
        for (var y = 0; y < t.terrainData.detailHeight; y++)
        {
            for (var x = 0; x < t.terrainData.detailWidth; x++)
            {
                

                if ((player.transform.position - new Vector3(x,0.5f,y)).magnitude < 4)
                {
                    print("Log");
                    print(y);
                    //print(player.transform.position);
                    //print((player.transform.position - new Vector3(x, 0.5f, y)).magnitude);
                    print(x);
                    grassHeight[y, x] = 0;
                } else if (grassHeight[y, x] <= 4)
                {
                    grassHeight[y, x] += grassGrowthRate*Time.deltaTime;
                }

                map[y, x] = (int) grassHeight[y, x];
            }
        }


        // Assign the modified map back.
        t.terrainData.SetDetailLayer(0, 0, 0, map);

    }


}
