using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolaPlastico : MonoBehaviour {

[SerializeField] Camera FPCamera;
[SerializeField] float range = 200f;
public float absorptionForce = 10f;
public float attractionForce = 10f; 


    void Update () {
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range) && hit.collider.gameObject.name.Contains("Botella")) {
         

                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                Debug.Log(rb);
                if (rb != null ) {
                   Vector3 direction = transform.position - hit.point;
                // Se aplica una fuerza de atracción al objeto en la dirección calculada
                    rb.AddForce(direction.normalized * attractionForce, ForceMode.Impulse);

                    if (Vector3.Distance( FPCamera.transform.position, rb.transform.position) <= 1f) {
                    // Se destruye el objeto
                        Destroy(rb.gameObject);
                    }
                }
            }
        }
    }
}
