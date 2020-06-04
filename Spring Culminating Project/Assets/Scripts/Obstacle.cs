using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Rigidbody obstacleRb;
    public float jumpForce;
    

    // Start is called before the first frame update
    void Start()
    {
        obstacleRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Awake()
    {
        transform.Rotate(0, 0, Random.Range(0, 360));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            obstacleRb.AddForce(Vector3.forward * jumpForce, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Destroy(gameObject, 10);
    }
}
