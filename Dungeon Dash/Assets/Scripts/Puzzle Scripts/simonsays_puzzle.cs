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
    public Transform highlighterTransform;
    public int playerNum; //0 or 1
    bool loop = true;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        restart(); //basically sets up the whole puzzle
    }

    // Update is called once per frame
    void Update()
    {
       /* while (loop) {
            if (index > 4)
            {
                loop = false;
            }
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

    // IEnumerator is needed so that you can wait
    IEnumerator showTiles()
    {
        yield return new WaitForSeconds(1); //basically functions as wait(1);
        for (int i=0; i<4; i++) //loops through all the keys and shows each 1 at a time
        {
            switch (randKeys[i])
            {
                case 1:
                    IHATEUNITYAAAAAAAAAAAAAAAA.transform.position = new Vector3(0, 0.5f, 0); //1 = up
                    break;
                case 2:
                    IHATEUNITYAAAAAAAAAAAAAAAA.transform.position = new Vector3(-0.5f, 0, 0); //2 = left
                    break;
                case 3:
                    IHATEUNITYAAAAAAAAAAAAAAAA.transform.position = new Vector3(0, -0.5f, 0); //3 = down
                    break;
                case 4:
                    IHATEUNITYAAAAAAAAAAAAAAAA.transform.position = new Vector3(0.5f, 0, 0); //4 = right
                    break;
            }
            yield return new WaitForSeconds(0.3f);
            IHATEUNITYAAAAAAAAAAAAAAAA.transform.position = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(0.3f);
        }
    }

    /* { //beat puzzle condition
            myDoor.OpenDoor(); //open the door (this will also unfreeze the player)
            this.gameObject.SetActive(false);
        } */

    void restart()
    {
        for (int i = 0; i < 4; i++)
        {
            randKeys.Add(Random.Range(1, 5)); //sets the list of keys the player has to press
        }
        showTiles();
        index = 0;
    }
}
