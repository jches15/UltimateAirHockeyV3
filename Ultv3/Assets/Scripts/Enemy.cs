using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float MaxMovementSpeed;
  private Rigidbody2D rb;
  private Vector2 startingPosition;
  //public Rigidbody2D Puck;
  public Transform thePuck;

  public Transform OTpuck;

  private Vector2 targetPosition; 
  private Vector2 backoff;

  public int difficultyScaler;
  private float lowerSpeed;
  private float higherSpeed;

  private bool OverTime = false;
 // public Transform PlayerBoundaryHolder; 
    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        //startingPosition = rb.position;
        startingPosition = transform.position;
        //GetComponent<Collider>().material.bounciness = 0f;
        difficultyScaler = MainMenu.difficulty;
        AssignEnemySpeed(difficultyScaler);

    }

    private void AssignEnemySpeed(int num){
        if(num == 1){
            lowerSpeed = 0.15f;
            higherSpeed = 0.25f;
        }
        else if(num == 2){
            lowerSpeed = 0.35f;
            higherSpeed = 0.4f;
        }
        else{
            lowerSpeed = 0.9f;
            higherSpeed = 1.0f;
        }
    }

    public void FixedUpdate(){

        Vector2 enemypos = transform.position;
        if(enemypos.x > 13.5){
            transform.position = new Vector2(11.29f,-1f);
        }
        float movementSpeed;

        int random = Random.Range(0, 12);
        //Debug.Log(random);

        if(OverTime && random < 6){
            movementSpeed = MaxMovementSpeed * Random.Range(lowerSpeed, higherSpeed);
            targetPosition.x = OTpuck.position.x;
            targetPosition.y = OTpuck.position.y;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.fixedDeltaTime);
        }
        else{
            movementSpeed = MaxMovementSpeed * Random.Range(lowerSpeed, higherSpeed);
            //movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
            //rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, movementSpeed * Time.fixedDeltaTime));

            targetPosition.x = thePuck.position.x;
            targetPosition.y = thePuck.position.y;
            //Debug.Log(targetPosition.x - transform.position.x);
            if(targetPosition.x - transform.position.x < -7){ 
                backoff.x = Random.Range(10f, 11f);
                backoff.y = Random.Range(-3.5f, 1.85f);
                //backoff.x = 10f;
                //backoff.y = 1.3f;
                //Debug.Log(backoff.x);
                //Debug.Log(backoff.y);
                //while(transform.position.x != backoff.x && transform.position.y != backoff.y){
                  //  Debug.Log("here");
                   // transform.position = Vector2.MoveTowards(transform.position, backoff, movementSpeed * Time.fixedDeltaTime);
                //}
                transform.position = Vector2.MoveTowards(transform.position, backoff, movementSpeed * Time.fixedDeltaTime);
            }

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.fixedDeltaTime);
        }   
    }
    public void Goal(){
        rb.velocity = new Vector2(0,0);
    }

    public void OTEnemymove(){
        transform.position = new Vector2(10.2f,-1.91f);
        OverTime = true;
    }
}
