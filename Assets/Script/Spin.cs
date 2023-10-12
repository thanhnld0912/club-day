using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField]private float degreesPerSecond = 60;
    private bool reverseRotation = false;
    [SerializeField] private float spinTime = 0f;
    [SerializeField] private float reverseDelay = 2f;

    void Update()
    {
        if (!reverseRotation)
        {
            transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
            spinTime += Time.deltaTime;

            if (spinTime >= reverseDelay)
            {
                reverseRotation = true;
                spinTime = 0f;
            }
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -degreesPerSecond) * Time.deltaTime);
            spinTime += Time.deltaTime;

            if (spinTime >= reverseDelay)
            {
                reverseRotation = false;
                spinTime = 0f;
            }
        }
    }
}
