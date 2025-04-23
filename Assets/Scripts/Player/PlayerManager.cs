using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using TMPro;
public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public static bool isGameWin;
    public GameObject gameWinScreen;
    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;
    private void Awake()
    {
        isGameOver = false;
        isGameWin = false;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
    }
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        coinsText.text = numberOfCoins.ToString();
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
        if (isGameWin)
        {
            gameWinScreen.SetActive(true);
        }
    }
    public void Home()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
