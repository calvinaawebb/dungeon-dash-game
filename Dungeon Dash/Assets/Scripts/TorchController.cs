using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    public GameObject[] players;

    public GameObject darkness;
    public StageUIController endScreen;

    int winningPlayer = 0;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float player0dist = Vector3.Distance(this.transform.position, players[0].transform.position);
        float player1dist = Vector3.Distance(this.transform.position, players[1].transform.position);

        audio.volume = 1 - (0.1f * (player0dist + player1dist) / 2f); //0.1 * average distance of players

        audio.panStereo = (player0dist - player1dist) * -0.2f; //difference * -0.2
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == players[0])
        {
            winningPlayer = 0;
            endStage();
        }
        else if (other.gameObject == players[1])
        {
            winningPlayer = 1;
            endStage();
        }
    }

    void endStage()
    {
        players[0].GetComponent<Player_Controller>().isStunned = true;
        players[1].GetComponent<Player_Controller>().isStunned = true;
        darkness.SetActive(false);
        endScreen.gameObject.SetActive(true);
        endScreen.winningPlayer = winningPlayer;
    }
}
