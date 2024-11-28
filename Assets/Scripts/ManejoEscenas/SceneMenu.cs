using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenu : MonoBehaviour
{
    public void StartGame(string nameScene)
    {
        SceneManager.LoadScene(nameScene);        
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        //Cerrar Juego
        Application.Quit();

        //Mostrar un mensaje
        Debug.Log("Cerrar Juego");

    }
}
