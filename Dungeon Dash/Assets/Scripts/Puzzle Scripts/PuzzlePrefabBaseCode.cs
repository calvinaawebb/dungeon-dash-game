using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePrefabBaseCode : MonoBehaviour
{

    public int playerNum; //0 or 1
    public DoorController myDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //stuff about puzzle. Will only happen when puzzle object is turned on, so don't worry about logic.

        if(false){ //beat puzzle condition: (put in a condition using variables in this class, etc.)
            myDoor.OpenDoor(); //open the door (this will also unfreeze the player)
            this.gameObject.SetActive(false);
        }
    }
}
