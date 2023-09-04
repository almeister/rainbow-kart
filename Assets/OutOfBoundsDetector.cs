using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsDetector : MonoBehaviour
{
    private GameObject player;
    private Vector3 lastPlayerPosition;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastPlayerPosition = player.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Checkpoint")
        {
            lastPlayerPosition = other.transform.position;
        }

        if (other.tag == "OutOfBounds")
        {
            // Reset player force and rotation
            var rb = player.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, 0);
            player.transform.position = lastPlayerPosition;
        }
    }
}
