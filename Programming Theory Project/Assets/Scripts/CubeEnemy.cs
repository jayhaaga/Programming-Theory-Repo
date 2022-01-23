using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : ClunkyEnemy
{
    // Start is called before the first frame update
    void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_Score = 50;
        InvokeRepeating("Move", 0, m_MoveRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Move()
    {
        Vector3 targetDirection = GetTargetDirection();
        if(Mathf.Abs(targetDirection.x) > Mathf.Abs(targetDirection.z))
        {
            targetDirection.z = 0f;
        }
        else
        {
            targetDirection.x = 0f;
        }
        m_Rb.AddForceAtPosition(targetDirection.normalized * m_Speed * m_SpeedScale, transform.position + new Vector3(0, transform.localScale.y * 0.75f, 0));
        base.Move();
    }
}
