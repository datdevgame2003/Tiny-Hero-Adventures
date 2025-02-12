using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    public FixedJoystick joystick; 
    public Button jumpButton;       
    public Button attackButton;    

    public static PlayerUI instance; 

    private void Awake()
    {
        
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
}
