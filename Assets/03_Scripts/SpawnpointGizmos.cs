using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointGizmos : MonoBehaviour
{
    public float radius = 1.0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.transform.position, radius);
    }
}
