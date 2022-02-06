using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereEnemy : Enemy // INHERITANCE
{
    protected override void Move() // POLYMORPHISM
    {
        m_Rb.AddForce(GetTargetDirection() * m_Speed);
        base.Move();
    }
}
