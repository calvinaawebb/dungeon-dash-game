using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public int player_num; //which player, 0 or 1? Declare in Unity Inspector
    public float speed; //how fast can character move? (could change...?)
    public bool isStunned = false; //becomes true to penalize player or to keep them from walking around when doing puzzles.
    public Quaternion curAngle;
    public Quaternion curAngle2;
    public Quaternion angleTo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isStunned)
        {
            Vector3 pos = transform.localPosition;
            pos.x += Input.GetAxisRaw("Horizontal_" + player_num) * speed; //change vertical position based on input from specific player
            pos.y += Input.GetAxisRaw("Vertical_" + player_num) * speed; //change horizontal position based on input from specific player
            transform.localPosition = pos; //update localPosition of player
            switch(Input.GetAxisRaw("Horizontal_" + player_num)) 
            {
                case 1:
                    gameObject.transform.rotation = Quaternion.Euler(0,0,90);
                    break;
                case -1:
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
                    break;
            }
            switch (Input.GetAxisRaw("Vertical_" + player_num))
            {
                case 1:
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case -1:
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
            }
            /*
            if(Input.anyKey) 
            {
                angleTo = gameObject.transform.rotation;
            }
            Vector3 pos = transform.localPosition;
            pos.x += Input.GetAxis("Horizontal_" + player_num) * speed; //change vertical position based on input from specific player
            pos.y += Input.GetAxis("Vertical_" + player_num) * speed; //change horizontal position based on input from specific player
            transform.localPosition = pos; //update localPosition of player
            switch (Input.GetAxis("Horizontal_" + player_num))
            {
                case > 0:
                    curAngle = new Quaternion(0,0,90,0);
                    curAngle2 = new Quaternion(0,0,270,0);
                    if(angleTo.z < 0) 
                    {
                        angleTo = angleTo * Quaternion.Euler(0,0,360);
                    }
                    if (angleTo.z >= curAngle.z && angleTo.z <= curAngle2.z) 
                    {
                        if (gameObject.transform.rotation != curAngle) 
                        {
                            gameObject.transform.rotation = Quaternion.Euler(0, 0, Input.GetAxis("Horizontal_" + player_num)*Quaternion.Inverse(curAngle).z);
                        }
                    } else if (angleTo.z < curAngle.z) 
                    {
                        if (gameObject.transform.rotation != curAngle) 
                        {
                            gameObject.transform.rotation = Quaternion.Euler(0, 0, Input.GetAxis("Horizontal_" + player_num)*curAngle.z);
                        }
                    }
                    //gameObject.transform.rotation = Quaternion.Euler(0, 0, (Input.GetAxis("Horizontal_" + player_num)*Quaternion.Angle(Quaternion.Euler(0,0,1), (Quaternion.Angle(gameObject.transform.rotation, Quaternion.Euler(0,0,90)) >= 90f ? gameObject.transform.rotation * Quaternion.Inverse(Quaternion.Euler(0, 0, 90)) : gameObject.transform.rotation * Quaternion.Euler(0, 0, 90)))));
                    break;
                case -1:
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
                    break;
            }
            switch (Input.GetAxis("Vertical_" + player_num))
            {
                case 1:
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case -1:
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
            }
            */
        }

    }
}
