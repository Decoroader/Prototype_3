using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController playerController;
    private float leftBound = -11;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(playerController.gameOver == false)
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        // this is way of the removing the obstacles as in the course, 
        // using a tag since this script attached to two objects
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
