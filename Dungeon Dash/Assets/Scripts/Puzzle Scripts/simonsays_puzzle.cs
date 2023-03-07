using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class simonsays_puzzle : MonoBehaviour
{
    public static List<int> randKeys = new List<int>();
    public DoorController myDoor;
    public GameObject IHATEUNITYAAAAAAAAAAAAAAAA; //the highlighter square
    public GameObject restartFeedbackSquare; //tells the player when they failed
    public Transform highlighterTransform;
    public int playerNum; //0 or 1
    int index;
<<<<<<< Updated upstream
    int puzzleLength = 4;
=======
<<<<<<< Updated upstream
=======
    int lastKeyPress; //used to make sure that inputs dont have to be frame perfect
    int puzzleLength = 4;
>>>>>>> Stashed changes
>>>>>>> Stashed changes

    void Start()
    {
<<<<<<< Updated upstream
        restart(); //basically sets up the whole puzzle
        Debug.Log("Started");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(index > puzzleLength) {
            myDoor.OpenDoor(); //open the door (this will also unfreeze the player)
            this.gameObject.SetActive(false);
            Debug.Log("Endcall");
        }
        switch (randKeys[index]) {
            case 1:
                if (Input.GetAxis("Vertical_" + playerNum) > 0)
                    {
                        index++;
                    }
                else if (Input.GetAxis("Vertical_" + playerNum) < 0 || Input.GetAxis("Horizontal_" + playerNum) != 0)
                    {
                        restart();
                    }
                break;
            case 2:
                if (Input.GetAxis("Horizontal_" + playerNum) < 0)
                    {
                        index++;
                    }
                else if (Input.GetAxis("Horizontal_" + playerNum) > 0 || Input.GetAxis("Vertical_" + playerNum) != 0)
                    {
                        restart();
                    }
                break;
            case 3:
                if (Input.GetAxis("Vertical_" + playerNum) < 0)
                    {
                        index++;
                    }
                else if (Input.GetAxis("Vertical_" + playerNum) > 0 || Input.GetAxis("Horizontal_" + playerNum) != 0)
                    {
                        restart();
                    }
                break;
            case 4:
                if (Input.GetAxis("Horizontal_" + playerNum) > 0)
                    {
                        index++;
                    }
                else if (Input.GetAxis("Horizontal_" + playerNum) < 0 || Input.GetAxis("Vertical_" + playerNum) != 0)
                    {
                        restart();
                    }
                break;
            }
<<<<<<< Updated upstream
        }

=======
            switch (randKeys[index]) {
                case 1:
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        index++;
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        index++;
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        index++;
                    }
                    break;
                case 4:
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        index++;
                    }
                    break;
            }
        }*/
    }
=======
        lastKeyPress = 0;
        //setting up the game
        for (int i = 0; i < puzzleLength; i++)
        {
            randKeys.Add(Random.Range(1, 5)); //sets the list of keys the player has to press
        }
        StartCoroutine(showTiles());
        index = 0;
    }

    void FixedUpdate()
    {
        if (index >= puzzleLength)
        { //if this is true, then the player has completed the whole code
            myDoor.OpenDoor(); //open the door (this will also unfreeze the player)
            this.gameObject.SetActive(false);
        }
        else
        {
            //at the start, squareInput() returns the current input,
            //and lastKeyPress returns the input from last frame
            //if squareInput() != lastKeyPress, then a new input has just been made
            //ignore it if its 0 bc in that case the new input is just nothing
            if (squareInput() != lastKeyPress && squareInput() != 0) {
                if (squareInput() == randKeys[index]) //if the player's input matches the code
                {
                    index++;
                }
                else if (squareInput() != 0) //if the player input a wrong AND nonzero key, then they were wrong
                {
                    restart();
                }
            }
            lastKeyPress = squareInput(); //sets up for next frame
        }
    }

>>>>>>> Stashed changes
>>>>>>> Stashed changes

    // IEnumerator is needed so that you can wait
    IEnumerator showTiles()
    {
<<<<<<< Updated upstream
        IHATEUNITYAAAAAAAAAAAAAAAA.transform.localPosition = new Vector3(0,0,0);
        yield return new WaitForSeconds(1); //basically functions as wait(1);
        for (int i=0; i < puzzleLength; i++) //loops through all the keys and shows each 1 at a time
=======
<<<<<<< Updated upstream
        yield return new WaitForSeconds(1); //basically functions as wait(1);
        for (int i=0; i<4; i++) //loops through all the keys and shows each 1 at a time
=======
        IHATEUNITYAAAAAAAAAAAAAAAA.transform.localPosition = new Vector3(0,0,0);
        yield return new WaitForSeconds(3); //basically functions as wait(3);
        for (int i=0; i < puzzleLength; i++) //loops through all the keys and shows each 1 at a time
>>>>>>> Stashed changes
>>>>>>> Stashed changes
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
    }

<<<<<<< Updated upstream
    void restart()
    {
        for (int i = 0; i < puzzleLength; i++)
=======
<<<<<<< Updated upstream
    /* { //beat puzzle condition
            myDoor.OpenDoor(); //open the door (this will also unfreeze the player)
            this.gameObject.SetActive(false);
        } */

    void restart()
    {
        for (int i = 0; i < 4; i++)
=======
    IEnumerator restartFeedbackShower()
    {
        yield return new WaitForSeconds(0.5f);
        restartFeedbackSquare.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        restartFeedbackSquare.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        restartFeedbackSquare.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        restartFeedbackSquare.SetActive(false);
    }

    void restart()
    {
        //provide feedback to the player
        StartCoroutine(restartFeedbackShower());
        //reset code, show the new code, and reset the index
        for (int i = 0; i < puzzleLength; i++)
>>>>>>> Stashed changes
>>>>>>> Stashed changes
        {
            randKeys[i] = Random.Range(1, 5); //sets the list of keys the player has to press
        }
        StartCoroutine(showTiles());
        index = 0;
    }
<<<<<<< Updated upstream
}
=======
<<<<<<< Updated upstream
}
=======

    int squareInput() //returns what square the player wanted to input given the key presses; if you ever see squareInput(), just think input
    {
        if (Input.GetAxis("Vertical_" + playerNum) > 0) return 1;
        else if (Input.GetAxis("Horizontal_" + playerNum) < 0) return 2;
        else if (Input.GetAxis("Vertical_" + playerNum) < 0) return 3;
        else if (Input.GetAxis("Horizontal_" + playerNum) > 0) return 4;
        else return 0; //0 means no input
    }
}
>>>>>>> Stashed changes
>>>>>>> Stashed changes
