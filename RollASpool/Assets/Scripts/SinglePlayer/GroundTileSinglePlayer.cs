using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTileSinglePlayer : MonoBehaviour
{
    GroundSpawnerSinglePlayer groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawnerSinglePlayer>();
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            groundSpawner.SpawnTile(true);
            Destroy(gameObject, 2);
            
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] GameObject obstaclePrefab;

    public void SpawnObstacle()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstacle at the position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);    
    }

    [SerializeField] GameObject coinPrefab;
    public float coinsToSpawn = 1;

    public void SpawnCoins()
    {
        for (int i = 0; i < coinsToSpawn; i++) {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
            temp.transform.position = new Vector3(temp.transform.position.x, 0.5f, temp.transform.position.z);
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if (point != collider.ClosestPoint(point)) {
            point = GetRandomPointInCollider(collider);
        }
        point.y = 1;

        return point;
    }
}
