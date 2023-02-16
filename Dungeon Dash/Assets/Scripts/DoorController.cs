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

    void OnTriggerEnter2D(Collider2D other){
        player = other.gameObject.GetComponent<Player_Controller>();
        player.isStunned = true;
        puzzleObject.SetActive(true);
        puzzleObject.GetComponent<DialPuzzle>().playerNum = player.player_num;
    }

    public void OpenDoor(){
        player.isStunned = false;
        this.gameObject.SetActive(false);
    }
}
