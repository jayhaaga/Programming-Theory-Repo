using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float m_MinY = -10f;
    [SerializeField]
    protected float m_Speed = 1f;
    [SerializeField]
    protected int m_Score = 0;
    [SerializeField]
    protected GameObject player;
    protected Rigidbody m_Rb;
    public virtual void Move() 
    {
        CheckBoundary();
    }
    protected void CheckBoundary()
    {
        if (transform.position.y < m_MinY)
        {
            MainManager.Instance.Score += m_Score;
            Destroy(gameObject);
        }
    }
    protected Vector3 GetTargetDirection()
    {
        Vector3 targetDirection = player.transform.position - transform.position;
        targetDirection.y = 0f;
        return targetDirection.normalized;
    }
}
