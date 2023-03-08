using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class simonsays_puzzle : MonoBehaviour
{
    int[] randKeys = { 0, 0, 0, 0, 0 };
    public DoorController myDoor;
    public GameObject IHATEUNITYAAAAAAAAAAAAAAAA; //the highlighter square
    public GameObject restartFeedbackSquare; //tells the player when they failed
    public Transform highlighterTransform;
    public int playerNum; //0 or 1
    int index;

    int lastKeyPress; //used to make sure that inputs dont have to be frame perfect
    public int puzzleLength = 5;

    bool instructionsGiven = false;

    void Start()
    {
        newGame();
    }

    public void newGame()
    { //basically just Start() but you can call it (trust me, i'm calling it...)
        lastKeyPress = 0;
        //setting up the game
        Random.seed = System.DateTime.Now.Millisecond;
        for (int i = 0; i < puzzleLength; i++)
        {
            randKeys[i] = Random.Range(1, 5); //sets the list of keys the player has to press
        }
        StartCoroutine(showTiles());
        index = 0;
        instructionsGiven = false;
    }

    void Update()
    {
        if (index >= puzzleLength)
        { //if this is true, then the player has completed the whole code
            myDoor.OpenDoor(); //open the door (this will also unfreeze the player)
            this.gameObject.SetActive(false);
        }
        else if (instructionsGiven == false)
        {
            //do nothing, because we're still in the showTiles IEnumerator
        }
        else
        {
            //at the start, squareInput() returns the current input,
            //and lastKeyPress returns the input from last frame
            //if squareInput() != lastKeyPress, then a new input has just been made
            //ignore it if its 0 bc in that case the new input is just nothing
            if (squareInput() != lastKeyPress && squareInput() != 0)
            {
                if (squareInput() == randKeys[index]) //if the player's input matches the code
                {
                    index++;
                }
                else if (squareInput() != 0) //if the player input a wrong AND nonzero key, then they were wrong
                {
                    IHATEUNITYAAAAAAAAAAAAAAAA.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    restart();
                }
            }
            lastKeyPress = squareInput(); //sets up for next frame

            //make square move when you click keys (seperate from real logic, just graphics:)
            switch (squareInput())
            {
                case 1:
                    IHATEUNITYAAAAAAAAAAAAAAAA.transform.localPosition = new Vector3(0, 0.5f, 0); //1 = up
                    break;
                case 2:
                    IHATEUNITYAAAAAAAAAAAAAAAA.transform.localPosition = new Vector3(-0.5f, 0, 0); //2 = left
                    break;
                case 3:
                    IHATEUNITYAAAAAAAAAAAAAAAA.transform.localPosition = new Vector3(0, -0.5f, 0); //3 = down
                    break;
                case 4:
                    IHATEUNITYAAAAAAAAAAAAAAAA.transform.localPosition = new Vector3(0.5f, 0, 0); //4 = right
                    break;
                default:
                    IHATEUNITYAAAAAAAAAAAAAAAA.transform.localPosition = new Vector3(0, 0, 0);
                    break;
            }
        }
    }


    // IEnumerator is needed so that you can wait
    IEnumerator showTiles()
    {

        IHATEUNITYAAAAAAAAAAAAAAAA.transform.localPosition = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.2f); //basically functions as wait(1);
        IHATEUNITYAAAAAAAAAAAAAAAA.transform.localPosition = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1); //basically functions as wait(1);
        for (int i = 0; i < puzzleLength; i++) //loops through all the keys and shows each 1 at a time
        {
            switch (randKeys[i])
            {
                case 1:
                    IHATEUNITYAAAAAAAAAAAAAAAA.transform.localPosition = new Vector3(0, 0.5f, 0); //1 = up
                    break;
                case 2:
                    IHATEUNITYAAAAAAAAAAAAAAAA.transform.localPosition = new Vector3(-0.5f, 0, 0); //2 = left
                    break;
                case 3:
                    IHATEUNITYAAAAAAAAAAAAAAAA.transform.localPosition = new Vector3(0, -0.5f, 0); //3 = down
                    break;
                case 4:
                    IHATEUNITYAAAAAAAAAAAAAAAA.transform.localPosition = new Vector3(0.5f, 0, 0); //4 = right
                    break;
            }
            yield return new WaitForSeconds(0.3f);
            IHATEUNITYAAAAAAAAAAAAAAAA.transform.localPosition = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(0.3f);
        }
        instructionsGiven = true;
    }

    IEnumerator restartFeedbackShower()
    {
        yield return new WaitForSeconds(0.25f);
        restartFeedbackSquare.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        restartFeedbackSquare.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        restartFeedbackSquare.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        restartFeedbackSquare.SetActive(false);
    }

    void restart()
    {
        instructionsGiven = false;
        //provide feedback to the player
        StartCoroutine(restartFeedbackShower());
        //reset code, show the new code, and reset the index
        //Lets not use the following commented code, so that the pattern is repeated:
        // for (int i = 0; i < puzzleLength; i++)
        // {
        //     randKeys[i] = Random.Range(1, 5); //sets the list of keys the player has to press
        // }
        index = 0;
        StartCoroutine(showTiles());
    }

    int squareInput() //returns what square the player wanted to input given the key presses; if you ever see squareInput(), just think input
    {
        if (Input.GetAxisRaw("Vertical_" + playerNum) > 0) return 1;
        else if (Input.GetAxisRaw("Horizontal_" + playerNum) < 0) return 2;
        else if (Input.GetAxisRaw("Vertical_" + playerNum) < 0) return 3;
        else if (Input.GetAxisRaw("Horizontal_" + playerNum) > 0) return 4;
        else return 0; //0 means no input
    }
}