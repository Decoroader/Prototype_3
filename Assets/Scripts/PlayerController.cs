using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //playerRb.AddForce(Vector3.up * 1000);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
    }
}
