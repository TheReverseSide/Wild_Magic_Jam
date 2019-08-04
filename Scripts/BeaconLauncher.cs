using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconLauncher : MonoBehaviour
{
    public bool hasABeacon = true;
    public GameObject beaconPrefab;


    private void Update()
    {
        if (hasABeacon && Input.GetMouseButtonDown(0))
        {
            hasABeacon = false;
            Vector3 directionOfThrow;
            Vector3 spawnPos;
            float speed = 15f;

            directionOfThrow = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            directionOfThrow = directionOfThrow.normalized;
            directionOfThrow = new Vector3(directionOfThrow.x, 0, directionOfThrow.z);
            spawnPos = transform.position + directionOfThrow * 3f;

            GameObject newBeacon = Instantiate(beaconPrefab, spawnPos, Quaternion.identity);
            newBeacon.GetComponent<Rigidbody>().AddForce(directionOfThrow * speed, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Beacon")
        {
            hasABeacon = true;
            Destroy(collision.collider.gameObject);
        }
    }
}
