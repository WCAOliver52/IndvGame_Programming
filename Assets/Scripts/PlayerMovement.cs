using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Implamented from learning from these tutorials: https://www.youtube.com/watch?v=4HpC--2iowE&t=920s https://www.youtube.com/watch?v=_QajrabyTJc&t=1123s https://learn.unity.com/project/john-lemon-s-haunted-jaunt-3d-beginner?uv=2019.4


    public CharacterController player;

    public float walkingSpeed = 6f;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;


    Animator m_Animator;
    Vector3 velocity;
    bool isGrounded;


    void Start()
    {
        m_Animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, groundMask);
    
        if (!isGrounded)
        {
            velocity.y = -2f;
        }
        else
        {
            velocity.y = 0f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;

        m_Animator.SetBool("IsWalking", isWalking);

        Vector3 direction = new Vector3(horizontal, 0F, vertical).normalized;
        direction.y = velocity.y;
        

        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            player.Move(direction * walkingSpeed * Time.deltaTime);
        }
    }
}
