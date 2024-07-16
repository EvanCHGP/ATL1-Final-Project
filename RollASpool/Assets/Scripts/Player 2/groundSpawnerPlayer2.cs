using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSpawnerPlayer2 : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        nextSpawnPoint = new Vector3(100, nextSpawnPoint.y, nextSpawnPoint.z);

        Debug.Log(nextSpawnPoint);

        if (spawnItems) {
            temp.GetComponent<groundTilePlayer2>().SpawnObstacle();
            temp.GetComponent<groundTilePlayer2>().SpawnCoins();
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++) {
            if (i < 3) {
                SpawnTile(false);
            } else {
                SpawnTile(true);
            }
        }
        
    }

}
