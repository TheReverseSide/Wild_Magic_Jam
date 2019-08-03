using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVMeshGenerator : MonoBehaviour
{
    Mesh myMesh;
    public MeshFilter[] mRender;
    public float radius;
    public float angleBetweenPoints;
    public LayerMask clippingLayers;

    private void Start()
    {
        myMesh = new Mesh();
        myMesh.vertices = DefinePoints();
        myMesh.triangles = DefineTris();
        for (int i = 0; i < mRender.Length; i++)
        {
            mRender[i].sharedMesh = myMesh;
        }
    }
    void Update()
    {
        myMesh.Clear();
        myMesh.vertices = DefinePoints();
        myMesh.triangles = DefineTris();
        for (int i = 0; i < mRender.Length; i++)
        {
            mRender[i].sharedMesh = myMesh;
        }
    }


    Vector3[] DefinePoints()
    {
        Vector3[] points = new Vector3[Mathf.RoundToInt(360/angleBetweenPoints) + 1];
        points[0] = Vector3.zero;
        Vector3 lastDirection = Vector3.forward;
        for (int i = 0; i < Mathf.RoundToInt(360 / angleBetweenPoints); i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(new Ray(transform.position, lastDirection), out hit, radius, clippingLayers)){
                points[i + 1] = hit.point - transform.position;
            } else
            {
                points[i + 1] = lastDirection * radius;
            }

            lastDirection = Quaternion.Euler(0,angleBetweenPoints,0) * lastDirection;
        }
        return points;
    }

    int[] DefineTris()
    {
        List<int> tris = new List<int>();
        for (int i = 1; i < Mathf.RoundToInt(360 / angleBetweenPoints); i++)
        {
            tris.Add(0);
            tris.Add(i);
            tris.Add(i + 1);
        }

        tris.Add(0);
        tris.Add(Mathf.RoundToInt(360 / angleBetweenPoints));
        tris.Add(1);
        return tris.ToArray();
    }
}
