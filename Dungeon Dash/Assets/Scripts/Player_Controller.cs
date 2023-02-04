using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public int player_num; //which player, 0 or 1? Declare in Unity Inspector
    public float speed; //how fast can character move? (could change...?)


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        Vector3 pos = transform.localPosition;
        pos.x += Input.GetAxis("Horizontal_" + player_num) * speed; //change vertical position based on input from specific player
        pos.y += Input.GetAxis("Vertical_" + player_num) * speed; //change horizontal position based on input from specific player
        transform.localPosition = pos; //update localPosition of player
    }
}
