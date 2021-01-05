using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;

    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void Update()
    {
        
    }

    void SpawnObstacle()
	{
        GameObject currentObstacle;
        if (playerController.gameOver == false)
        {
            currentObstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
            Destroy(currentObstacle, 1.9f);
        }
    }
}
