using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround;
    public bool gameOver;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private Rigidbody playerRb;
    private Animator playerAnimator;
    private AudioSource playerAudio;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.Q))
            Application.Quit();

    }
	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            dirtParticle.Play(); // sometimes it call after Obstacle-collision, so this incorrect code
            // for fix it added check flag gameOver
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game over!");
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            dirtParticle.Stop();
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
