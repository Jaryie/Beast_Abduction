using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTaker : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector3.zero;
                playerRigidbody.angularVelocity = Vector3.zero;
            }
            BA_GameManager.gm.TakeCaptured();
            var playerController = playerRigidbody.GetComponent<PlayerController>();
            playerController.transform.position = playerController.home;
            Destroy(this.gameObject);
        }
    }
}