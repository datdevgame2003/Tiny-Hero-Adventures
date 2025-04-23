using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.Play("Musicgame");
    }
    public void Play()
    {
        
        SceneManager.LoadSceneAsync(1);
    }
    public void Exit()
    {
        AudioManager.instance.Play("Click");
        Application.Quit();
    }
    public void DeletePrefs()
    {
        AudioManager.instance.Play("Click");
        PlayerPrefs.DeleteAll();
    }
    public void PlaySoundButton()
    {
        AudioManager.instance.Play("Click");
        
    }
    public void ExitSoundButton()
    {
        AudioManager.instance.Play("Click");

    }
    public void RestoreButtonSound()
    {
        AudioManager.instance.Play("Click");

    }
    public void SettingsButtonSound()
    {
        AudioManager.instance.Play("Click");

    }
    public void CancelButtonSound()
    {
        AudioManager.instance.Play("Click");

    }
}
