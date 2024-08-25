using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;

    Rigidbody palyerRb;
    GameObject focalPoint;

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
    }
}
