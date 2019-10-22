using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{

    public GameObject defenderPrefab; // var to hold prefab for instantiating the helmets

    public float speed = 5f; // speed of the empty object 
    

    float chanceDirectionChange = 0.04f; // how likely the object will change direction

    public float secsBetweenSpawn = 2f; // rate that the helmets generate 



    // on start the ships will spawn on the screen
    void Start()
    {
        InvokeRepeating("SpawnOpponent", 2f, secsBetweenSpawn);  //calls a function every .7 seconds 2f from start of game
    }

    // move the empty object and randomly change direction while game is running
    void Update()
    {

        Vector3 pos = transform.position; // create a var to hold current position
        pos.x += speed * Time.deltaTime; // sets the x position of the helmets to the speed var * sec since last frame
        transform.position = pos;
        

        if (pos.x < -6)
        { // if the empty object's x position is less than -6 set speed to a positive number
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > 6)
        {

            speed = -Mathf.Abs(speed);  // if the empty object's x position is greater than 6 reverse speed
        }


    }

    void FixedUpdate()
    {

        if (Random.value < chanceDirectionChange)
        {  // change direction at a random interval
            speed *= -1;

        }

    }

    void SpawnOpponent()
    {

        GameObject orb = Instantiate(defenderPrefab) as GameObject; // create reference to hold game object
        orb.transform.position = transform.position;

    }


} //from class website with modifications