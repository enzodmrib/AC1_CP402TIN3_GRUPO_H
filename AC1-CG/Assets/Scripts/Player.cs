using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceMultiplier = 5f;
    public float maximumVelocity = 5f;

    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        
        if(rigidBody.velocity.magnitude <= maximumVelocity)
        {
            rigidBody.AddForce(new Vector3(horizontalInput * forceMultiplier, 0, verticalInput * forceMultiplier));
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Hazard")) {
            Destroy(gameObject);
        }
    }
}
