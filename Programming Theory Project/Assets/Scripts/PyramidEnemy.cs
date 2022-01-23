using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidEnemy : ClunkyEnemy
{
    private MeshFilter meshFilter;
    // Start is called before the first frame update
    void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_Score = 25;
        InvokeRepeating("Move", 0, m_MoveRate);
        meshFilter = GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Move()
    {
        Vector3 targetDirection = GetTargetDirection(), bestNorm = new Vector3(0, -1, 0);
        float bestNormVal = 0f;
        foreach (Vector3 norm in meshFilter.mesh.normals)
        {
            float val = Vector3.Dot(transform.TransformVector(norm), targetDirection);
            if (val > bestNormVal)
            {
                bestNormVal = val;
                bestNorm = transform.TransformVector(norm);
            }
        }
        m_Rb.AddForceAtPosition(bestNorm.normalized * m_Speed * m_SpeedScale, transform.position + new Vector3(0, transform.localScale.y * 0.85f, 0));
        base.Move();
    }
}
