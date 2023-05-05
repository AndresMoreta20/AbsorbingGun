using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {
    /*
    public float range = 100f;

    void Update () {
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, range)) {
                Debug.Log("Object shot: " + hit.collider.gameObject.name);
            }
        }
    }
}

public class Arma : MonoBehaviour
{
    public float absorptionForce = 10f;
    public float maxDistance = 100f;

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance)) {
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null) {
                    rb.velocity = Vector3.zero;
                    rb.AddForce(transform.forward * absorptionForce, ForceMode.Impulse);
                }
            }
        }
    }

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot(){
        RaycastHit hit;
        Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
        Debug.Log("I hit tihs thing: "+hit.collider.gameObject.name);
    }
*/
[SerializeField] Camera FPCamera;
[SerializeField] float range = 200f;
public float absorptionForce = 10f;
public float attractionForce = 10f; 
// public float range = 100f;

    void Update () {
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range) && hit.collider.gameObject.name != "Terrain") {
                /*
                Collider collider = hit.collider;
                if (collider != null && hit.collider.gameObject.name != "Terrain") {
                    Destroy(collider.gameObject);
                }*/

                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                Debug.Log(rb);
                if (rb != null ) {
                   Vector3 direction = transform.position - hit.point;
                // Se aplica una fuerza de atracción al objeto en la dirección calculada
                    rb.AddForce(direction.normalized * attractionForce, ForceMode.Impulse);
                   // rb.velocity = Vector3.zero;
                    //rb.AddForce(transform.forward * absorptionForce, ForceMode.Impulse);
                
                    if (Vector3.Distance( FPCamera.transform.position, rb.transform.position) <= 1f) {
                    // Se destruye el objeto
                        Destroy(rb.gameObject);
                    }
                }
            }
        }
    }
}
