using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    [SerializeField]
    public Transform groundCheckTransform = null;
    [SerializeField]
    private LayerMask playerMask;
    private int superJumpsRemaining = 0;

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

    // FixedUpdate is called once every physic update
    private void FixedUpdate()
    {

        rigidbodyComponent.velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, horizontalInput * 3); // yürümek için

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0) //birden fazla zıplamayı engellemek için ekledik
        //UnityEngine.Collider[] adlı dizinin lenght'i 0'a eşitse, yani o anda hiç componenta değmiyorsa true döner, bu da havadayken olur ve daha fazla zıplayamayız.
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
            float jumpPower = 5;

            if (superJumpsRemaining > 0)
            {
                jumpPower *= 2;
                superJumpsRemaining --;
            }
            rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;

        }

    }
    //para toplamak için 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3) //layer numarası
        {
            Destroy(other.gameObject);
            superJumpsRemaining++;
        }
    }


}
