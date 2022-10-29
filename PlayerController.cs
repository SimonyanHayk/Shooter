using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool AreSprinting;
    public bool AreCrouching;
    public bool isGrounded;

    private float Speed;
    public float WalkSpeed = 5f;
    public float Sprinting = 12f;
    public float Crouching = 3f;

    public CharacterController Controller;

    public GameObject GroundCheck;
    public LayerMask Ground;

    Vector3 Gravity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        AreSprinting = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W);
        AreCrouching = Input.GetKey(KeyCode.LeftControl);
        isGrounded = Physics.CheckSphere(GroundCheck.transform.position, 0.2f, Ground);

        Vector3 Move = transform.right * x + transform.forward * z;

        if (!isGrounded)
        {
            Gravity.y += -9.81f * Time.deltaTime;
        }

        //Time.timeScale = 1f;

        if (isGrounded)
        {
            Gravity.y = -9.81f;
        }

        Controller.Move(Speed * Time.deltaTime * Move);
        Controller.Move(Gravity * Time.deltaTime);

        
            if (AreSprinting)
            {                
                Speed = Sprinting;
            }
        

        if (AreCrouching)
        {
            Speed = Crouching;
            GetComponent<CharacterController>().height = 1.2f;
        }

        if (!AreCrouching)
        {
            GetComponent<CharacterController>().height = 1.8f;
        }

        if (!AreCrouching && !AreSprinting)
        {
            Speed = WalkSpeed;
        }
    }
}
