using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class simonsays_puzzle : MonoBehaviour
{
    public static List<int> randKeys = new List<int>();
<<<<<<< Updated upstream
    int loop = 0;
    int index = 0;
=======
    public DoorController myDoor;
    public GameObject IHATEUNITYAAAAAAAAAAAAAAAA; //the highlighter square
    public GameObject restartFeedbackSquare; //tells the player when they failed
    public Transform highlighterTransform;
    public int playerNum; //0 or 1
    int index;

    int lastKeyPress; //used to make sure that inputs dont have to be frame perfect
    public int puzzleLength = 5;

    bool instructionsGiven = false;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
         for (int i = 0; i<4; i++) {
            randKeys.Add(Random.Range(1,4));
         }
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        while (loop < 1) {
            switch(randKeys[index]) {
=======
        if (index > puzzleLength)
        {
            myDoor.OpenDoor(); //open the door (this will also unfreeze the player)
            this.gameObject.SetActive(false);
            Debug.Log("Endcall");
        }
        switch (randKeys[index])
        {
            case 1:
                if (Input.GetAxis("Vertical_" + playerNum) > 0)
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
        else if (!instructionsGiven)
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
>>>>>>> Stashed changes
                {
                    index++;
                }
                else if (Input.GetAxis("Vertical_" + playerNum) < 0 || Input.GetAxis("Horizontal_" + playerNum) != 0)
                {
                    restart();
                }
<<<<<<< Updated upstream
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
=======
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
>>>>>>> Stashed changes
        }
        Debug.Log(index);
    }


    // IEnumerator is needed so that you can wait
    IEnumerator showTiles()
    {
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        IHATEUNITYAAAAAAAAAAAAAAAA.transform.localPosition = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1); //basically functions as wait(1);
        for (int i = 0; i < puzzleLength; i++) //loops through all the keys and shows each 1 at a time
        {
            switch (randKeys[i])
            {
>>>>>>> Stashed changes
                case 1:
                    if (index > 4)
                    {
                        loop++;
                        break;
                    }
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        index++;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 2:
                    if (index > 4)
                    {
                        loop++;
                        break;
                    }
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        index++;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 3:
                    if (index > 4)
                    {
                        loop++;
                        break;
                    }
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        index++;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 4:
                    if (index > 4)
                    {
                        loop++;
                        break;
                    }
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        index++;
                        break;
                    }
                    else
                    {
                        break;
                    }
            }
        }
        instructionsGiven = true;
    }
<<<<<<< Updated upstream
}
=======

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
        for (int i = 0; i < puzzleLength; i++)
        {
            randKeys[i] = Random.Range(1, 5); //sets the list of keys the player has to press
        }
        StartCoroutine(showTiles());
        index = 0;
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
>>>>>>> Stashed changes
