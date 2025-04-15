using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public int speed = 5;
    public Transform startPoint;
    public Transform endPoint;
    private Vector2 targetPoint;
    void Start()
    {
        targetPoint = startPoint.position;
    }

   
    void Update()
    {
        if(Vector2.Distance(transform.position,startPoint.position) <0.1f)
        {
            targetPoint = endPoint.position;
        }
        if(Vector2.Distance(transform.position,endPoint.position) < 0.1f)
        {
            targetPoint = startPoint.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
