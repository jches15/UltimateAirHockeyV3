using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public enum MainMenus
    {
        difficulty
    }
    public static int difficulty;

    public void EasyButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        difficulty = 1;
    }
     public void MedButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        difficulty = 2;
    }
     public void HardButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        difficulty = 3;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
