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
    
    
    public AudioSource SongOne;
    public AudioSource SongTwo;
    public AudioSource SongThree;
    public AudioSource SongFour;
    public AudioSource YouWin;
    public AudioSource YouLose;
    int songNum;

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
        pickSong();
    }

    void Update()
    {
        if(OT){
            bool result = puckOT.OTgameStatus();
            bool result2 = OtherpuckOT.OTgameStatus();
            if(result || result2){
                timeRemaining = 0;
                float minutes = 0;
                float seconds = 0;
                timeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
            }
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
                player.SetActive(false);
                AI.SetActive(false);
                puck.SetActive(false); 
                OvertimePuck.SetActive(false);
                if(TimeRanOut == true){
                    PlayerScore = Score.playerScore;
                    AIScore = Score.aiScore;
                    if(PlayerScore > AIScore){
                        WinnerText.text = "You won!!";
                        SongStop();
                        YouWin.Play();
                        OT = false;
                    }
                    else if(PlayerScore < AIScore){
                        WinnerText.text = "AI won!";
                        SongStop();
                        YouLose.Play();
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
        Vector2 puckPos = ThePuck.position;
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

        TimeRanOut = false;
        Update();
        timeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        if(playerStatus == true){
            WinnerText.text = "You won!!";
            SongStop();
            YouWin.Play();
        }
        else{
            WinnerText.text = "AI won!";
            SongStop();
            YouLose.Play();
        }
        Invoke("Winner",  2);
    }

    private void Winner(){
        gameOverText.SetActive(false);
        WinnerText.gameObject.SetActive(true);
    }

    private void Overtime(){

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
    }

    private void pickSong(){
        songNum = Random.Range(0, 4);
        if(songNum == 0){
            SongOne.Play();
        }
        else if(songNum == 1){
            SongTwo.Play();
        }
        else if(songNum == 2){
            SongThree.Play();
        }
        else{
            SongFour.Play();
        }
    }

    private void SongStop(){
        if(songNum == 0){
            SongOne.Stop();
        }
        else if(songNum == 1){
            SongTwo.Stop();
        }
        else if(songNum == 2){
            SongThree.Stop();
        }
        else{
            SongFour.Stop();
        }
    }
 
    
    

}
