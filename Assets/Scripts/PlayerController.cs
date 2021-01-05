using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround;
    public bool gameOver;
    public ParticleSystem explosionParticle;

    private Rigidbody playerRb;
    private Animator playerAnimator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        //playerRb.AddForce(Vector3.up * 1000);
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
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
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
		}
    }
}
