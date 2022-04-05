using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertToRegularMesh : MonoBehaviour
{
    [ContextMenu("convert to regular mesh")]
    void Convert ()
    {
        SkinnedMeshRenderer skinedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        meshFilter.sharedMesh = skinedMeshRenderer.sharedMesh;
        meshRenderer.sharedMaterials = skinedMeshRenderer.sharedMaterials;

        DestroyImmediate(skinedMeshRenderer);
        DestroyImmediate(this);
    }
}
