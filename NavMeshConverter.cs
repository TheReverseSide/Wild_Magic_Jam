using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavMeshConverter : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<NavMeshObstacle>().center = gameObject.GetComponent<BoxCollider>().center;
        gameObject.GetComponent<NavMeshObstacle>().size = gameObject.GetComponent<BoxCollider>().size;
    }
}
