using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //allows access to the Unity UI
using UnityEngine.SceneManagement;

public class DropBall2 : MonoBehaviour
{
    public Text score; //setting a variable to display text for the score.

    public int catchCount = 0; //using some code from Chris Blake. 

    float speed = -5.0f; //sets a speed to the ball.



    // Update is called once per frame
    void Update()
    {


        if (transform.position.y < -5.5f)
        {
            ResetBall();
        } // every time the football has a y position less than -5.5, call the function. 


        // we are sending speed to the console so we can see what it is
        Debug.Log(speed);

        // we send current velocity so we can see what it is 
        Debug.Log(GetComponent<Rigidbody2D>().velocity);

        

       


        if (catchCount == 10)
        {
            SceneManager.LoadScene("Win2"); //if the score is 10, load the second win screen.
        }
        else if (catchCount < 0)
        {
            SceneManager.LoadScene("Lose2"); //if the score is under 0, load the second lose screen.
        }




    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Target") //calling the tag
        {
            catchCount++; //adds a point for every time the player catches the ball.
            score.text = "Touchdowns: " + catchCount.ToString(); //displays the score.
            transform.position = new Vector2(Random.Range(-5, 6), 5.6f); //every time the ball touches the player, the ball will reset to the top of the screen with a random x position.  //when the target collides with the asteroid, it will disappear

        }




    } //this function detects a collision and adds a point every time the player catches the football.

    void ResetBall()
    {
        transform.position = new Vector2(Random.Range(-5, 6), 5.6f);
        catchCount--; //takes away a point from the player.
        score.text = "Touchdowns: " + catchCount.ToString(); //shows the score.
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);//changes the velocity of the ball.
    }
}
//Used some code from clunk47 on Unity forums to figure out how to set a random x position to the ball whenever the player scores or goes past -5.5 on the screen. Also had help from Shawn.
