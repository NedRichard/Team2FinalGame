using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static void GoToGameView() {
        SceneManager.LoadScene("LiisaScene");
    }

    public static void GoToVictoryScene() {
        Debug.Log("You got out!");
    }

    public static void GoToGameOver() {

    }
}
