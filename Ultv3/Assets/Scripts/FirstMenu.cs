using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstMenu : MonoBehaviour
{

    public enum MenuChoice
    {
        moneyPuck

    }
    public static bool moneyPuck = false;

    public void NormalButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void MoneyPuckButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        moneyPuck = true;    
    }
}
