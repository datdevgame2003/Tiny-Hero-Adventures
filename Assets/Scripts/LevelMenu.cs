using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }

                
    }
    public void OpenMenu(int levelid)
    {
        AudioManager.instance.Play("Click");
        AudioManager.instance.Stop("Musicgame");
        string levelName = "Level " + levelid;
        SceneManager.LoadScene(levelName);
    }
}
