using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolaAbosrver : MonoBehaviour {

[SerializeField] Camera FPCamera;
[SerializeField] float range = 200f;

public float attractionForce = 10f; 


    void Update () {
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            //Se comprueba que el arma no tome en cuenta objetos no deseados
            if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range) && hit.collider.gameObject.name != "Terrain") {

                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null ) {
                   Vector3 direction = transform.position - hit.point;

                // Se aplica una fuerza de atracción al objeto en la dirección calculada
                    rb.AddForce(direction.normalized * attractionForce, ForceMode.Impulse);
                    if (Vector3.Distance(rb.transform.position, FPCamera.transform.position) <= 2f) {
                        Destroy(rb.gameObject);
                    }
                }
            }
        }
    }
}
