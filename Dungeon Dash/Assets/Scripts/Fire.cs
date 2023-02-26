using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public GameObject[] players;

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
}
