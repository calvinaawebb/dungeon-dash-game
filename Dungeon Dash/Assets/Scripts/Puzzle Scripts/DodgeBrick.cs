using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeBrick : MonoBehaviour
{

    public FallingBlocksDodge myPuzzle;

    public float speed = 0.001f;

    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y - speed, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Collider_Bottom")
        {
            myPuzzle.IncreaseScore();
            Debug.Log("Hit bottom");
            isDead = true;
            this.transform.GetChild(0).gameObject.SetActive(true); //green shield
            StartCoroutine(killBrick());
        }

        else if (other.gameObject.name == "Player")
        {
            Debug.Log("hit player");
            isDead = true;
            this.transform.GetChild(1).gameObject.SetActive(true); //red shield
            StartCoroutine(killBrick());
        }
    }

    IEnumerator killBrick()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
}
