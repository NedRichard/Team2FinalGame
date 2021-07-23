using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static void GoToGameView() {
        //Debug.Log("Starting game!");
        SceneManager.LoadScene("Liisa scene");
    }

    public static void GoToVictoryScene() {
        SceneManager.LoadScene("VictoryScene");
        //Debug.Log("You got out!");
    }

    public static void GoToGameOver() {
        SceneManager.LoadScene("GameOver");
    }

    public static void ExitGame() {
        //Debug.Log("Quitting game!");
        Application.Quit();
    }
}
