using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{

    public AudioSource catchBall;

    public float moveSpeed = 30f; //this sets a speed to the player.
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(9, 0);
            //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-9, 0);
            //transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        } //these functions allow the player to move using the arrow keys. 




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        catchBall.Play(); //play the cheering sound when the player catches the ball
    }

}
