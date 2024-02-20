using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPillar : MonoBehaviour
{
    void Start()
    {
        SetRandomPosition();
    }

    void SetRandomPosition()
    {
        float randomX = Random.Range(50f, 200f);
        float randomZ = Random.Range(60f, 100f);
        Vector3 newPosition = new Vector3(randomX, 0f, randomZ);
        transform.position = newPosition;
    }
}