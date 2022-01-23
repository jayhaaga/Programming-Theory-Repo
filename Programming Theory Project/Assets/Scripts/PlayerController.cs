using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private float jumpForce = 50.0f;
    private bool isOnGround;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertInput = Input.GetAxis("Vertical"), horzInput = Input.GetAxis("Horizontal");
        Move(horzInput, vertInput);
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }
    private void Move(float horizontal, float vertical)
    {
        if (isOnGround)
        {
            playerRb.AddForce(new Vector3(horizontal, 0, vertical) * speed);
        }
    }
    private void Jump()
    {
        if (isOnGround)
        {
            isOnGround = false;
            playerRb.AddForce(new Vector3(0, jumpForce, 0));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            //add me
        }
    }
}
