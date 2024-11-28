using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorPausaJuego : MonoBehaviour
{
    private IPlayerInput playerInput;
    private bool isPaused = false;

    [SerializeField] private GameObject objectPause;

    public void Initialize(IPlayerInput input)
    {
        playerInput = input;        
    }

    public void PauseGame()
    {
        if (playerInput.GetPressPause() && !isPaused && objectPause != null)
        {
            objectPause.SetActive(true);
            isPaused = true;

            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            if (isPaused && playerInput.GetPressPause())
            {
                ResumeGame();
            }

        }
    }

    public void ResumeGame()
    {
        objectPause.SetActive(false);
        isPaused = false;

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MenuGame(string nameMenu)
    {
        SceneManager.LoadScene(nameMenu);
    }

    public void ExitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
        Debug.Log("Close Game");
    }
}
