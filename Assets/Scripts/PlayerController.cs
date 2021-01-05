using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround;
    public bool gameOver;


    private Rigidbody playerRb;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //playerRb.AddForce(Vector3.up * 1000);
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

    }
	private void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.CompareTag("Ground"))
            isOnGround = true;
        else if (collision.gameObject.CompareTag("Obstacle"))
		{
            gameOver = true;
            Debug.Log("Game over!");
		}
    }
}
