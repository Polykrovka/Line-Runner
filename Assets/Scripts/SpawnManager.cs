using UnityEngine;
using System.Collections;

public class SpawnManager:MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    Vector3 spawnPosition;

    public float spawnRate;
    void Start()
    {
        spawnPosition = transform.position;
        StartCoroutine(SpawnObstacleCoroutine());
    }

    void SpawnObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Length);
        int ramdomSpot = Random.Range(0, 2); // 0 top, 1 bottom

        spawnPosition = transform.position;

        if(ramdomSpot == 0)
        {
            Instantiate(obstaclePrefabs[index], spawnPosition, transform.rotation);
        }
        else
        {
            spawnPosition.y = -transform.position.y;

            if(index == 1)
            {
                spawnPosition.x += 1;
            }
            else if(index == 2)
            {
                spawnPosition.x += 2;
            }

            GameObject obs = Instantiate(obstaclePrefabs[index], spawnPosition, transform.rotation);
            obs.transform.eulerAngles = new Vector3(0, 0, 180); 
        }

    }

    IEnumerator SpawnObstacleCoroutine()
    {
        while(true)
        {
            SpawnObstacle();
            GameManager.Instance.UpdateScore();
            yield return new WaitForSeconds(spawnRate);
        }
    }
}

