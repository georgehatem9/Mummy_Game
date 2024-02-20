using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyController : MonoBehaviour
{
    public Transform bryce;  
    public int BryceLives;
    public Animator animator;  
    public Animator animator2;
    public CharacterController controller;
    public float minRotationInterval = 3f;
    public float maxRotationInterval = 10f;
    public float rotationDuration = 5f;
    public float alertLevel = 0f;  
    public bool green;
    private float gravityY = 0.0f;
    private bool isDetectingBryce = false; 
    private Quaternion originalRotation;
    private Quaternion targetRotation;
    private float rotationTimer;
    private float rotationInterval;
    public float rotationDurationTimer;
    public bool isBryceDead;
    
    private void Start()
    {
        
        isBryceDead = false;
        CalculateRotationSpeed();
        originalRotation = transform.rotation;
        rotationInterval = Random.Range(minRotationInterval, maxRotationInterval);
        rotationTimer = rotationInterval;
        BryceLives = 3;
        green = true;
}

    private void Update()
    {
        if (controller.isGrounded)
        {
            gravityY = -0.5f;
        }
        rotationTimer -= Time.deltaTime;
        if (rotationTimer <= 0f)
        {
            
            RotateMummy();
            rotationDurationTimer = rotationDuration;
            rotationInterval = Random.Range(minRotationInterval, maxRotationInterval);
            rotationTimer = rotationInterval;
            
        }


        if (rotationDurationTimer > 0f)
        {
            animator.SetBool("isLooking", true);

            if (BryceLives >= 1)
            {
                if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.Space)))
                {
                    animator2.SetBool("isHit", true);
                    animator.SetBool("isDancing", true);
                    BryceLives -= 1;
                    green = false;

                }

                rotationDurationTimer -= Time.deltaTime;
                if (rotationDurationTimer <= 0f)
                {
                    animator2.SetBool("isHit", false);
                    animator.SetBool("isLooking", false);
                    animator2.SetBool("isRecovering", true);
                    animator.SetBool("isDancing", false);
                    ResetRotation();
                }
            }
            if (BryceLives < 1)
            {
                animator2.SetBool("isHit", false);
                animator2.SetBool("isDead", true);
                animator.SetBool("isDancing", true);
                isBryceDead = true;
            }

        }
        
    }

    private void RotateMummy()
    {
        targetRotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + 180f, 0f);
    }

    private void ResetRotation()
    {
        targetRotation = originalRotation;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 180f * Time.deltaTime);
    }


private void CalculateRotationSpeed()
    {
        
        alertLevel += 100f;
    }

    private bool IsFacingBryce()
    {
        Vector3 directionToBryce = (bryce.position - transform.position).normalized;
        float dotProduct = Vector3.Dot(transform.forward, directionToBryce);
        return dotProduct >= 0.5f;
    }

    private void BryceLosesLife()
    {
        
    }

    private void PlayDetectionBehavior()
    {
        
        //animator.SetBool("isDancing", true);
        
    }
}
