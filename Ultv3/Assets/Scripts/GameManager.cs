using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    public GameObject gameOverText;
    public GameObject player;

    public GameObject puck;
    public Transform ThePuck;

    public GameObject AI;
    public Text PlayerScoreText;
    public Text AIScoreText;
    public GameObject EnemyGoalText;
    public GameObject PlayerGoalText;
    
    public int PlayerScore = 0;
    public int AIScore = 0;

    public bool Goal = false;
    public bool TimeRanOut = false;
    public Text WinnerText;
    

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        TimeRanOut = true;
        gameOverText.SetActive(false);
        EnemyGoalText.SetActive(false);
        PlayerGoalText.SetActive(false);
        WinnerText.gameObject.SetActive(false);
        DisplayTime(timeRemaining);
        PlayerScoreText.text = "Player: " + PlayerScore;
        AIScoreText.text = "AI: " + AIScore;
    }

    void Update()
    {
        if(Goal){
            Goal = false;
            EnemyGoalText.SetActive(false);
            //Debug.Log("Here");
            Vector2 puckPosition = ThePuck.position;
            puckPosition.x = -7;
            puckPosition.y = -1;
        }
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                if(TimeRanOut == true){
                    Debug.Log("Ran out of time, no one got to 7");
                    PlayerScore = Score.playerScore;
                    AIScore = Score.aiScore;
                    if(PlayerScore > AIScore){
                        WinnerText.text = "You won!!";
                    }
                    else if(PlayerScore < AIScore){
                        WinnerText.text = "AI won!";
                    }
                    else{
                        WinnerText.text = "Overtime..";
                    }
                    Invoke("Winner",  2);
                }

                gameOverText.SetActive(true);
                player.SetActive(false);
                AI.SetActive(false);
                puck.SetActive(false); //disable them, but if game goes to OT, then reactivate
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        //if(GameObject.Find("puck").transform.position.x < -13.75){
        Vector2 puckPos = ThePuck.position;
        /*
        if(puckPos.x < -13.75){
            //Debug.Log("yup");
            puck.SetActive(false);
            EnemyGoal();
        }
        else if(puckPos.x > 13.4){
            puck.SetActive(false);
            PlayerGoal();
        }*/
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText = GameObject.Find("TimeText").GetComponent<Text>();
        timeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void gameOver(bool playerStatus, bool AIStatus){
        timeRemaining = 0;
        float minutes = 0;
        float seconds = 0;
        //Debug.Log("TimeRanOut = " + TimeRanOut);
        TimeRanOut = false;
        //Debug.Log("TimeRanOut = " + TimeRanOut);
        Update();
        timeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        if(playerStatus == true){
            WinnerText.text = "You won!!";
        }
        else{
            WinnerText.text = "AI won!";
        }
        Invoke("Winner",  2);
    }

    private void Winner(){
        gameOverText.SetActive(false);
        WinnerText.gameObject.SetActive(true);
    }
 
    
    

}
