using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;
    public FixedJoystick joystick; 
    public Button jumpButton;       
    public Button attackButton;    

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
}
