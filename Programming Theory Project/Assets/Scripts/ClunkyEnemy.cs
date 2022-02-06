using UnityEngine;

public class ClunkyEnemy : Enemy // INHERITANCE
{
    [SerializeField]
    protected float m_MoveRate = 2f;
    [SerializeField]
    protected float m_SpeedScale = 150f;
    protected override void Start() // POLYMORPHISM
    {
        base.Start();
        InvokeRepeating("Move", 0, m_MoveRate);
    }
    protected override void Update() // POLYMORPHISM
    {
        //We want to negate this function for these types
    }
}
