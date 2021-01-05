using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController playerController;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(playerController.gameOver == false)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
