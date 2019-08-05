using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class BeaconLauncher : MonoBehaviour
{
    public bool hasABeacon = true;
    public GameObject beaconPrefab;
    public StudioEventEmitter fmodMusic;

    private void Update()
    {
        if (hasABeacon && Input.GetMouseButtonDown(0))
        {
            fmodMusic.SetParameter("Beacon", 2);
            hasABeacon = false;
            Vector3 directionOfThrow;
            Vector3 spawnPos;
            float speed = 15f;

            directionOfThrow = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, Camera.main.ScreenToWorldPoint(Input.mousePosition).z) - transform.position;
            directionOfThrow = directionOfThrow.normalized;
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
            fmodMusic.SetParameter("Beacon", 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "End")
        {
            SceneSwapper.swapper.GoToNextLevel();
        }
    }
}
