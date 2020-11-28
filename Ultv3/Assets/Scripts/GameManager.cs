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

    public puck puckOT;

    public GameObject OvertimePuck;
    public puck OtherpuckOT;

    public Enemy MoveEnemyOT;

    public int PlayerScore = 0;
    public int AIScore = 0;

    public bool Goal = false;
    public bool TimeRanOut = false;
    public bool OT = false;
    public Text WinnerText;
    

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        TimeRanOut = true;
        gameOverText.SetActive(false);
        EnemyGoalText.SetActive(false);
        PlayerGoalText.SetActive(false);
        OvertimePuck.SetActive(false);
        WinnerText.gameObject.SetActive(false);
        DisplayTime(timeRemaining);
        PlayerScoreText.text = "Player: " + PlayerScore;
        AIScoreText.text = "AI: " + AIScore;
        Debug.Log("Start");
    }

    void Update()
    {
        if(OT){
            //Debug.Log("Yea buddy!");
            bool result = puckOT.OTgameStatus();
            bool result2 = OtherpuckOT.OTgameStatus();
            //Debug.Log(result);
            if(result || result2){
                timeRemaining = 0;
                float minutes = 0;
                float seconds = 0;
                timeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }
        /*
        if(Goal){
            Goal = false;
            EnemyGoalText.SetActive(false);
            //Debug.Log("Here");
            Vector2 puckPosition = ThePuck.position;
            puckPosition.x = -7;
            puckPosition.y = -1;
            //Debug.Log("working");
        }*/

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                //Debug.Log("Here");
                //Debug.Log(timeRemaining);
                timeRemaining -= Time.deltaTime;
                //Debug.Log(timeRemaining);
                DisplayTime(timeRemaining);
            }
            else
            {
                //Debug.Log("Time has run out!");
                player.SetActive(false);
                AI.SetActive(false);
                puck.SetActive(false); 
                OvertimePuck.SetActive(false);
                if(TimeRanOut == true){
                    //Debug.Log("Ran out of time, no one got to 7");
                    PlayerScore = Score.playerScore;
                    AIScore = Score.aiScore;
                    if(PlayerScore > AIScore){
                        WinnerText.text = "You won!!";
                        OT = false;
                    }
                    else if(PlayerScore < AIScore){
                        WinnerText.text = "AI won!";
                        OT = false;
                    }
                    else{
                        WinnerText.text = "Overtime..";
                        OT = true;
                    }
                
                    Invoke("Winner",  2);
                }

                gameOverText.SetActive(true);
                timeRemaining = 0;
                timerIsRunning = false;
                if(OT){
                    Invoke("Overtime", 4);
                }
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
        //Debug.Log("Winner method");
        gameOverText.SetActive(false);
        WinnerText.gameObject.SetActive(true);
    }

    private void Overtime(){
        //Debug.Log("yo");
        //Start();
        WinnerText.gameObject.SetActive(false);
        timerIsRunning = true;
        player.SetActive(true);

        AI.SetActive(true);
        MoveEnemyOT.OTEnemymove();


        puck.SetActive(true);
        puckOT.OTmove(); //respawn puck
        OtherpuckOT.OTmoveOtherPuck();

        OvertimePuck.SetActive(true);

        timeRemaining = 60;
        //Update();
    }
 
    
    

}
