using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    float timer = 0;
    Vector3 movement = new Vector3 (0, 1, 0);

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            timer = 0;
            movement = -1 * movement;
        }
        
        transform.Translate(movement * Time.deltaTime);

    }
}
