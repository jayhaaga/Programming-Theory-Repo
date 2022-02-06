using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : ClunkyEnemy // INHERITANCE
{
    protected override void Move() // POLYMORPHISM
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
