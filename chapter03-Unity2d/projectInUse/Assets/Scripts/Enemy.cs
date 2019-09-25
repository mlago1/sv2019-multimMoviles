using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speedX = 3;
    private float speedY = 3;


    void Update()
    {
        if (transform.position.x < -5 || transform.position.x > 5)
            speedX = -speedX;
        if (transform.position.y < -3 || transform.position.y > 3)
            speedY = -speedY;
        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
    }
}
