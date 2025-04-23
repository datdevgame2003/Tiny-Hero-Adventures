using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGController : MonoBehaviour
{

    public float speed = 2f; // tốc độ nhấp nháy

    private Image image;
    private Color startColor;
    private float t;

    void Start()
    {
        image = GetComponent<Image>();
        startColor = image.color;
    }

    void Update()
    {
        
        t = Mathf.PingPong(Time.time * speed, 1f);

       
        Color newColor = startColor;
        newColor.a = Mathf.Lerp(0.3f, 1f, t);
        image.color = Color.Lerp(Color.white, new Color(0.7f, 1f, 1f), t);
    }
}



