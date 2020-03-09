using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float downwardBound = -8;
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
        if(transform.position.y < downwardBound)
        {
            Destroy(gameObject);
        }
    }
}
