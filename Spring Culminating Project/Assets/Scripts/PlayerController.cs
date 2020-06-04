using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public float yRange = 30.0f;
    public Rigidbody playerRb;
    public float jumpForce = 5.0f;
    public float jumpHeight = 7f;
    public bool isGrounded;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        while (gameManager.isGameActive)
        {
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.y < -yRange)
            {
                transform.position = new Vector3(-yRange, transform.position.x, transform.position.z);
            }
            if (transform.position.y > yRange)
            {
                transform.position = new Vector3(yRange, transform.position.x, transform.position.z);
            }

            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.left * horizontalInput * Time.deltaTime * speed);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                playerRb.AddForce(Vector3.up * jumpHeight);
            }
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
        }
    }

}
    


