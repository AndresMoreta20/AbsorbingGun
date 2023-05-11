using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolaCarton : MonoBehaviour {

    [SerializeField] private GameObject controller; 
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 200f;
    public float attractionForce = 10f; 

    void Update () {
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range) && hit.collider.gameObject.name.Contains("Carton")) {

                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null ) {
                    Vector3 direction = transform.position - hit.point;
                    // Se aplica una fuerza de atracción al objeto en la dirección calculada
                    rb.AddForce(direction.normalized * attractionForce, ForceMode.Impulse);
                    
                    // Check if the object is close to the player
                    if (Vector3.Distance(rb.transform.position, controller.transform.position) <= 3f) {
                        Destroy(rb.gameObject);
                    }
                }
            }
        }
    }
}

