using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DENEME : MonoBehaviour
{
    private bool jumpKeyWasPressed;
    private float horizontalInput;

    private Rigidbody rigidbodyComponent;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {

        if (jumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 4, ForceMode.VelocityChange);
        }

        rigidbodyComponent.velocity = new Vector3(0, rigidbodyComponent.velocity.y, horizontalInput);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }




}
