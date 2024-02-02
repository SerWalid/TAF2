using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 5.0f;

    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;

    private Vector3 initialPlayerPosition;
    private int collectedCoinsCount = 0;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        initialPlayerPosition = transform.position;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            print("Col");
            speed = 2.0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            print("Col Exit");
            speed = 5.0f;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision detected");
        if (other.gameObject.tag == "Coin")
        {
            Debug.Log("Player and Coin tags detected");
            Destroy(other.gameObject);
            collectedCoinsCount++;

            if (collectedCoinsCount >= 3)
            {             
                transform.position = initialPlayerPosition;
                collectedCoinsCount = 0;
            }
        }
    }
}
