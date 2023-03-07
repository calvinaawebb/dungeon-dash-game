using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public GameObject puzzleObject;
    Player_Controller player;
    private bool freezingPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        player = other.gameObject.GetComponent<Player_Controller>();
        player.isStunned = true;
        puzzleObject.SetActive(true);
<<<<<<< Updated upstream
        DialPuzzle puzzleScript = puzzleObject.GetComponent<DialPuzzle>();
        puzzleScript.playerNum = player.player_num;
        puzzleScript.myDoor = this;
=======
        if (puzzleObject.GetComponent<DialPuzzle>() != null)
        {
            DialPuzzle puzzleScript = puzzleObject.GetComponent<DialPuzzle>();
            puzzleScript.velocity = puzzleScript.startVelocity;
            puzzleScript.playerNum = player.player_num;
            puzzleScript.myDoor = this;
        }
        else if (puzzleObject.GetComponent<simonsays_puzzle>() != null)
        {
            simonsays_puzzle puzzleScript = puzzleObject.GetComponent<simonsays_puzzle>();
            puzzleScript.playerNum = 0;
            puzzleScript.myDoor = this;
        }
        else if (puzzleObject.GetComponent<FallingBlocksDodge>() != null)
        {
            FallingBlocksDodge puzzleScript = puzzleObject.GetComponent<FallingBlocksDodge>();
            puzzleScript.playerNum = player.player_num;
            puzzleScript.myDoor = this;
        }


>>>>>>> Stashed changes
    }

    public void OpenDoor()
    {
        player.isStunned = false;
        this.gameObject.SetActive(false);
    }
}
