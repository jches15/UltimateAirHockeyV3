
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
        
    if(playerScore == 7){
        playerWon = true;
        done.gameOver(playerWon, AIWon);
    }
    else if(aiScore == 7){
        AIWon = true;
        done.gameOver(playerWon, AIWon);
    }



}



}
