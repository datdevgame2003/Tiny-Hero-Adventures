using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
