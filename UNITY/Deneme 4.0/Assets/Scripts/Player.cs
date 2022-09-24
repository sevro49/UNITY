using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10f;

    [SerializeField]
    private float jumpForce = 5;

    private float movementX;

    private Rigidbody rb;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        PlayerJumpKeyboard();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position +=
            new Vector3(movementX, 0, 0) * Time.deltaTime * movementSpeed;
    }

    void PlayerJumpKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter()
    {
        isGrounded = true;
    }

    /*void OnTriggerEnter(Collider other){ 
        if(other.gameObject.CompareTag(GOLD_TAG)){ //para toplamak için. Colliderda isTrigger'ı işaretle
            gold ++;
            Destroy(other.gameObject); //other.gameObject dersem tag'ı seçili olan, gameObject dersem script'e sahip olan obje yok edilir.
        }
    } */
} //class
