using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceTrap : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 3;

    float startingX;
    int dir = 1;
  
    void Start()
    {
        startingX = transform.position.x;
    }

   
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * dir);
        if (transform.position.x < startingX || transform.position.x > startingX + range)
            dir *= -1;
    }
}
