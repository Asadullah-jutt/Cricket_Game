using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batshot : MonoBehaviour
{
    public float forceMagnitude = 20f; // Magnitude of the force to be applied

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            //Debug.Log(collision.gameObject.name);
            // Calculate the direction of the collision
            Vector3 direction = collision.contacts[0].point - transform.position;

            // Normalize the direction vector
            direction.Normalize();

            // Apply force in the direction of the collision
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction * forceMagnitude, ForceMode.Impulse);
        }
    }
}
