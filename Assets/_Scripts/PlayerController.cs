using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    private float moveSpeed = 4.0f;

    //Interactor components
    PlayerInteractor playerInteractor;

    [Header("Movement System")]
    public float walkSpeed = 4.0f;
    public float runSpeed = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        playerInteractor = GetComponentInChildren<PlayerInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //Funcion de interacción
        Interact();
    }

    public void Interact()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            playerInteractor.Interact();
        }
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(horizontal,0f,vertical).normalized;
        //El 0.016f es un reemplazo para Deltatime
        Vector3 velocity = moveSpeed * Time.deltaTime  * dir;

        if(Input.GetButton("Sprint"))
        {
            moveSpeed = runSpeed;
            animator.SetBool("isRunning",true);
        } else
        {
            moveSpeed = walkSpeed;
            animator.SetBool("isRunning",false);
        }
        
        if(dir.magnitude >= 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(dir);

            controller.Move(velocity);
        }
        animator.SetFloat("Speed",velocity.magnitude);
    }
}
