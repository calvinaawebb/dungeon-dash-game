using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeBrick : MonoBehaviour
{

    public FallingBlocksDodge myPuzzle;

    public float speed = 0.001f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y - speed, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Collider_Bottom")
        {
            myPuzzle.IncreaseScore();
            this.gameObject.SetActive(false);
            Debug.Log("Hit bottom");
        }

        else if (other.gameObject.name == "Player")
        {
            this.gameObject.SetActive(false);
            Debug.Log("hit player");
        }


    }
}
