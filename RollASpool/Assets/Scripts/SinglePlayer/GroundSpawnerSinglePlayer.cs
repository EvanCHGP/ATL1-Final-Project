using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnerSinglePlayer : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems) {
            temp.GetComponent<GroundTileSinglePlayer>().SpawnObstacle();
            temp.GetComponent<GroundTileSinglePlayer>().SpawnCoins();
        }
                        
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++) {
            if (i < 2) {
                SpawnTile(false);
            } else {
                SpawnTile(true);
            }
        }
        
    }

    public void Update()
    {
        
    }

}