using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMeshColliders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DisableMeshCollidersFun(transform);
    }

    void DisableMeshCollidersFun(Transform _trans)
    {
        MeshCollider[] cols = _trans.GetComponents<MeshCollider>();
        foreach (MeshCollider col in cols) col.enabled = false;

        for (int i = 0; i < _trans.childCount; i++)
            DisableMeshCollidersFun(_trans.GetChild(i));
    }


}
