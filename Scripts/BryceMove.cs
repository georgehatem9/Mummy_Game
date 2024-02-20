using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class BryceMove : MonoBehaviour
{
    public float maximumSpeed = 1.0f;
    public CharacterController controller;
    public Camera cam;
    public float mass = 1.0f;
    private float gravityY = 0.0f;
    Animator anim;
    bool isRunning;
    float lerpWR;
    bool isLeaping;
    public float alertLevel;
    public float decreaseRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Debug.Log(anim);
        alertLevel = 0f;

}

    // Update is called once per frame
    void Update()
    {
        float dX = 0.0f;
        float dY = 0.0f;

        dX = Input.GetAxis("Horizontal");
        dY = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(dX, 0, dY);
        moveVector = Quaternion.AngleAxis(cam.transform.eulerAngles.y, Vector3.up) * moveVector; //34an azbot angle el cam le angle el character el bybos 3leh we ba3daha a5leh el etgah bta3y 

        moveVector.Normalize(); // normalization le el vector bta3y 34an yb2a ka2eno inside a circle my5rog4 menha ama tdrb 7aga fe 7aga

        moveVector *= maximumSpeed; // maintaing maximum speed
        gravityY += Physics.gravity.y * mass * Time.deltaTime; // b3ml el gravity kol frame byzeed 3leha el total gravity of the past frames
        if (controller.isGrounded) // 34an nt2kd eno 3la ard m4 fe el hawa
        {
            gravityY = -0.5f; // 34an ama byrg3 el ard byb2a sa3at fe space beno we ben el ard
        }
        Vector3 moveNewVector = moveVector; // 34an m2sr4 3la el vector bta3 el rotation mayboz4
        moveNewVector.y = gravityY;

        //controller.Move(moveNewVector * Time.deltaTime);
        // transform.Translate(moveVector, Space.World);
        if (alertLevel > 0)
        {
            // Decrease alertLevel over time
            alertLevel -= decreaseRate * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("isWalking", true);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("isWalking", false);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);

            alertLevel += 20;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isJumping", false);
        }

        if (moveVector != Vector3.zero)
        {

            //anim.SetBool("Moving", true);
           // anim.SetFloat("IDT", 0.0f);
            //if (!Input.GetKey(KeyCode.LeftShift))
            //    anim.SetFloat("IWR", 0.5f, 0.5f, Time.deltaTime);
           // else
           //     anim.SetFloat("IWR", 1.0f, 0.5f, Time.deltaTime);
            Quaternion rotaionDirection = Quaternion.LookRotation(moveVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotaionDirection, 720 * Time.deltaTime);

        }


    }

    private void OnApplicationFocus(bool focus) // Make mouse disapear 
    {
        if (focus)
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        else
            UnityEngine.Cursor.lockState = CursorLockMode.None;
    }
    private void OnAnimatorMove()
    {
        Vector3 _move = anim.deltaPosition;
        _move.y = gravityY;
        controller.Move(_move);
    }
}
