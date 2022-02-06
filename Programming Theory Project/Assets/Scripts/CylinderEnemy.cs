using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderEnemy : Enemy // INHERITANCE
{
    protected override void Move() // POLYMORPHISM
    {
        Vector3 targetDirection;
        if(m_Player.transform.position.z > transform.position.z)
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
