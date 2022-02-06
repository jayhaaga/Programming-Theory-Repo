using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float m_MinY = -10f;
    [SerializeField]
    protected float m_Speed = 1f;
    [SerializeField]
    protected int m_Score = 0;
    protected GameObject m_Player;
    protected Rigidbody m_Rb;
    protected virtual void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_Player = GameObject.Find("Player");
    }
    protected virtual void Update()
    {
        Move();
    }
    protected virtual void Move() // ABSTRACTION
    {
        CheckBoundary();
    }
    protected void CheckBoundary() // ABSTRACTION
    {
        if (transform.position.y < m_MinY)
        {
            MainManager.Instance.Score += m_Score;
            Destroy(gameObject);
        }
    }
    protected Vector3 GetTargetDirection() // ABSTRACTION
    {
        Vector3 targetDirection = m_Player.transform.position - transform.position;
        targetDirection.y = 0f;
        return targetDirection.normalized;
    }
}
