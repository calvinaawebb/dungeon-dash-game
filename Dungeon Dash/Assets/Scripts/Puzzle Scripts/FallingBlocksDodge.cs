using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlocksDodge : MonoBehaviour
{
    public int playerNum; //0 or 1
    public DoorController myDoor;
    public GameObject brickPrefab;
    public int bricksNecassary = 14;
    public float playerSpeed = 0.001f;

    private int bricksDropped = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropBlock());
    }

    // Update is called once per frame
    void Update()
    {
        //stuff about puzzle. Will only happen when puzzle object is turned on, so don't worry about logic.
        if (bricksDropped >= bricksNecassary)
        { //beat puzzle condition: (put in a condition using variables in this class, etc.)
            myDoor.OpenDoor(); //open the door (this will also unfreeze the player)
            this.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Vector3 player = this.transform.GetChild(0).transform.localPosition;
        if(!(player.x <= -0.888 && Input.GetAxis("Horizontal_" + playerNum) < 0) || (player.x >= 0.888 && Input.GetAxis("Horizontal_" + playerNum) > 0))
        {
            this.transform.GetChild(0).transform.localPosition = new Vector3(player.x + (Input.GetAxis("Horizontal_" + playerNum) * playerSpeed), player.y, 0);
        }
        
    }

    public void IncreaseScore()
    {
        bricksDropped += 1;
    }

    IEnumerator DropBlock()
    {
        GameObject brick = Instantiate(brickPrefab, new Vector3(Random.Range(-0.9f, 0.9f) + this.transform.position.x, 1.26100004f + this.transform.position.y, 0f), new Quaternion(0, 0, 0, 1), this.transform);
        brick.GetComponent<DodgeBrick>().myPuzzle = this;
        brick.SetActive(true);
        yield return new WaitForSeconds(1);
        StartCoroutine(DropBlock());
    }
}
