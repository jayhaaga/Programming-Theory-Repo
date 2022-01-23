using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PyramidEditor : Editor
{
    [MenuItem("GameObject/Create Other/Pyramid")]
    static void Create()
    {
        GameObject gameObject = new GameObject("Pyramid");
        PyramidMesh pm = gameObject.AddComponent<PyramidMesh>();
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        meshFilter.mesh = new Mesh();
        pm.BuildMesh();
        meshCollider.sharedMesh = meshFilter.sharedMesh;
        meshRenderer.material = new Material(Shader.Find("Diffuse"));
    }
}
