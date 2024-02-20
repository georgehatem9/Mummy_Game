using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLightChanger : MonoBehaviour
{
    public Light blinkingLight;
    public float maxBlinkingTime = 2f;
    public float minRange = 0f;
    public float maxRange = 50f;

    private float currentBlinkingTime;
    private bool isBlinking;

    void Start()
    {
        currentBlinkingTime = 0f;
        isBlinking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlinking)
        {
            currentBlinkingTime += Time.deltaTime;

            if (currentBlinkingTime >= maxBlinkingTime)
            {
                isBlinking = false;
                currentBlinkingTime = 0f;
                blinkingLight.enabled = false;
            }
            else
            {
                blinkingLight.enabled = (currentBlinkingTime % 0.5f) > 0.25f;
            }
        }
        else
        {
            if (Random.Range(0f, 1f) < 0.01f)
            {
                isBlinking = true;
                blinkingLight.enabled = true;
                blinkingLight.range = Random.Range(minRange, maxRange);
            }
        }
    }
}
