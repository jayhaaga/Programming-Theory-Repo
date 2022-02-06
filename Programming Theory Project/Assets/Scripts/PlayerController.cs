using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_PlayerRb;
    [SerializeField]
    private float m_Speed = 3.0f;
    [SerializeField]
    private float m_JumpForce = 300.0f;
    private bool m_IsOnGround;
    // Start is called before the first frame update
    void Start()
    {
        m_PlayerRb = GetComponent<Rigidbody>();
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
        if (m_IsOnGround)
        {
            m_PlayerRb.AddForce(new Vector3(horizontal, 0, vertical) * m_Speed);
        }
    }
    private void Jump()
    {
        if (m_IsOnGround)
        {
            m_IsOnGround = false;
            m_PlayerRb.AddForce(new Vector3(0, m_JumpForce, 0));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_IsOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            //Lose health response
        }
    }
}
