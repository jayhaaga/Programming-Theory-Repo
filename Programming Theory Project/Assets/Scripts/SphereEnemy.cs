using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_Score = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public override void Move()
    {
        m_Rb.AddForce(GetTargetDirection() * m_Speed);
        base.Move();
    }
}
