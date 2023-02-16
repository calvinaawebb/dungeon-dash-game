using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialPuzzle : MonoBehaviour
{

    public float startVelocity;
    public float spinAccleration;
    public float jolt = 0.01f;

    public int playerNum; //0 or 1
    public DoorController myDoor;
    public Transform myDial;

    public float velocity;
    private float currentForce;
    private int inVal;

    // Start is called before the first frame update
    void Start()
    {
        velocity = startVelocity;
        currentForce = 1;
    }

    // Update is called once per frame
    void Update()
    {
        int input = 0;
        if(Input.GetAxis("Horizontal_" + playerNum) != 0){
            input = (int)(Mathf.Abs(Input.GetAxis("Horizontal_" + playerNum))/Input.GetAxis("Horizontal_" + playerNum)); //-1, 0, or 1. No smoothing will happen.
        }

        if(inVal != input){
            inVal = input;
            currentForce = jolt * inVal * -1f;
        }

        if(inVal == 0f){
            currentForce = 0f;
        }
        else{
            currentForce += spinAccleration * inVal * -1f;
            velocity += currentForce;
        }

        var rotationVector = myDial.rotation.eulerAngles;
        rotationVector.z += velocity;
        myDial.rotation = Quaternion.Euler(rotationVector);

        if(rotationVector.z > 177f && rotationVector.z < 183f && Mathf.Abs(velocity) < 0.01f){ //beat puzzle condition
            myDoor.OpenDoor(); //open the door (this will also unfreeze the player)
            this.gameObject.SetActive(false);
        }
    }
}
