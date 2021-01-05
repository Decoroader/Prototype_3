using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void Update()
    {
        
    }

    void SpawnObstacle()
	{
        GameObject currentObstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        Destroy(currentObstacle, 1.9f);
    }
}
