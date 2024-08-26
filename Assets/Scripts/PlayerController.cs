using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public bool hasPowerup;
    public GameObject powerupIndicator;

    Rigidbody palyerRb;
    GameObject focalPoint;
    float powerupStrength = 15;

    // Start is called before the first frame update
    void Start()
    {
        palyerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        palyerRb.AddForce(speed * forwardInput * focalPoint.transform.forward);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -.3f, 0);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Powerup")) {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCoutdownRoutine());
        }
    }

    IEnumerator PowerupCoutdownRoutine(){
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy") && hasPowerup) {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDirection = (enemyRb.transform.position - transform.position).normalized; 
            enemyRb.AddForce(forceDirection * powerupStrength, ForceMode.Impulse);
            // Debug.Log("Collide with a enemy.");
        }
    }
}
