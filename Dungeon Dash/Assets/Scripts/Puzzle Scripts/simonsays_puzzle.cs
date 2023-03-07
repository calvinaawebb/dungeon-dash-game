using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class simonsays_puzzle : MonoBehaviour
{
    public static List<int> randKeys = new List<int>();
    int loop = 0;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log(index);
    }


    // IEnumerator is needed so that you can wait
    IEnumerator showTiles()
    {
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
    }
}
