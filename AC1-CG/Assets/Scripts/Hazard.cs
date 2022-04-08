using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Island")) {
            Destroy(gameObject);
        }
    }
}
