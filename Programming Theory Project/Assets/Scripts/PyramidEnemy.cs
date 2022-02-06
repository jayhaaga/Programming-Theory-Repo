using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidEnemy : ClunkyEnemy // INHERITANCE
{
    private MeshFilter m_MeshFilter;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        m_MeshFilter = GetComponent<MeshFilter>();
    }
    protected override void Move() // POLYMORPHISM
    {
        Vector3 targetDirection = GetTargetDirection(), bestNorm = new Vector3(0, -1, 0);
        float bestNormVal = 0f;
        foreach (Vector3 norm in m_MeshFilter.mesh.normals)
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
