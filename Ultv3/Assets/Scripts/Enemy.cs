﻿using System.Collections;
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

  private bool OverTime = false;
 // public Transform PlayerBoundaryHolder; 
    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        //startingPosition = rb.position;
        startingPosition = transform.position;
        //GetComponent<Collider>().material.bounciness = 0f;

    }

    public void FixedUpdate(){
        float movementSpeed;

        int random = Random.Range(0, 12);
        //Debug.Log(random);

        if(OverTime && random < 6){
            movementSpeed = MaxMovementSpeed * Random.Range(0.3f, 0.4f);
            targetPosition.x = OTpuck.position.x;
            targetPosition.y = OTpuck.position.y;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.fixedDeltaTime);
        }
        else{
            movementSpeed = MaxMovementSpeed * Random.Range(0.3f, 0.4f);
            //movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
            //rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, movementSpeed * Time.fixedDeltaTime));

            targetPosition.x = thePuck.position.x;
            targetPosition.y = thePuck.position.y;
            //Debug.Log(targetPosition.x - transform.position.x);
            if(targetPosition.x - transform.position.x < -8){ 
                backoff.x = Random.Range(9f, 11f);
                backoff.y = Random.Range(0f, -1f);
                //Debug.Log(backoff.x);
                //Debug.Log(backoff.y);
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