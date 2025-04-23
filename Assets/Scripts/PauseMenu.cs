using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Pause()
    {
        AudioManager.instance.Play("Click");
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Home()
    {
        AudioManager.instance.Play("Click");
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void Resume()
    {
        AudioManager.instance.Play("Click");
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

    }
    public void Restart()
    {
        AudioManager.instance.Play("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    
}
