using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightColorChanger : MonoBehaviour
{
    private Light spotlight;
    private bool isBryceMoving;
    public bool green;

    public Animator Anim;
    void Start()
    {
        spotlight = GetComponent<Light>();
        Anim = GetComponent<Animator>();
        spotlight.color = Color.green;
        isBryceMoving = false;
    }



    void Update()
    {
        if (green == false)
        {
            isBryceMoving = true;
            spotlight.color = Color.red;
        }
        else
        {
            isBryceMoving = false;
            spotlight.color = Color.green;
        }
    }
}
