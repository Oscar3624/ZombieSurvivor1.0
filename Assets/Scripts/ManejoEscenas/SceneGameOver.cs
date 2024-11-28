using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGameOver : MonoBehaviour
{
    public void RestartGame(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Home(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void GameOver()
    {
        //Cerrar juego
        Application.Quit();
    }
}
