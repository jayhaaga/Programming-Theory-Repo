using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_Score = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public override void Move()
    {
        Vector3 targetDirection;
        if(player.transform.position.z > transform.position.z)
        {
            targetDirection = new Vector3(0, 0, 1);
        }
        else
        {
            targetDirection = new Vector3(0, 0, -1);
        }
        m_Rb.AddForce(targetDirection * m_Speed);
        base.Move();
    }
}
