
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public enum Scores
    {
        AiScore, PlayerScore

    }
    public Text AiScoreTxt, PlayerScoreTxt;
    public static int aiScore, playerScore;
    public GameManager done;
    public bool playerWon, AIWon = false;


    public void Increment(Scores whichScore)
    {
        if(whichScore == Scores.AiScore)
            PlayerScoreTxt.text = "Player: " + (++playerScore).ToString();
        else
            AiScoreTxt.text = "AI: " + (++aiScore).ToString();
            
        checkScore();
    }

    public void IncrementMoneyPuck(Scores whoScored, int amount){

        Debug.Log(amount);
        if(whoScored == Scores.AiScore){
            if(amount < 0){ //for example, if goal amount is -2, and player scored, player would get plus one and AI loses 2 goals
                if((aiScore + amount) < 0){ //if negative score, round up to 0
                    aiScore = 0;
                    AiScoreTxt.text = "AI: " + aiScore.ToString();
                }
                else{
                    aiScore = aiScore + amount;
                    //Debug.Log("Ai loses a goal" + temp2);
                    AiScoreTxt.text = "AI: " + aiScore.ToString();
                }
                PlayerScoreTxt.text = "Player: " + (++playerScore).ToString();
            }
            
            else{ //otherwise, increment player score by random amount
                //int temp = amount;
                playerScore = playerScore + amount;
                PlayerScoreTxt.text = "Player: " + playerScore.ToString();
                //Debug.Log("player scored more than one goal");
            }
        }
            
        else{
            if(amount < 0){ //for example, if goal amount is -2, and AI scored, AI would get plus one and player loses 2 goals
                if((playerScore + amount) < 0){
                    playerScore = 0;
                    PlayerScoreTxt.text = "Player: " + playerScore.ToString();
                }
                else{
                    playerScore = playerScore + amount;
                    //Debug.Log("player loses a goal" + temp2);
                    PlayerScoreTxt.text = "Player: " + playerScore.ToString();
                }
                AiScoreTxt.text = "AI: " + (++aiScore).ToString();
            }
            else{ //otherwise, increment AI score by random amount
                //int temp = amount;
                aiScore = aiScore + amount;
                AiScoreTxt.text = "AI: " + aiScore.ToString();
                //Debug.Log("AI scored more than one goal");
            }
        }
        //Debug.Log("Players score = " + playerScore);
        //Debug.Log("AIs score = " + aiScore);
        checkScore();
    }

    private void checkScore(){
        if(playerScore >= 1){
            playerWon = true;
            done.gameOver(playerWon, AIWon);
        }
        else if(aiScore >= 1){
            AIWon = true;
            done.gameOver(playerWon, AIWon);
        }
    }

}
