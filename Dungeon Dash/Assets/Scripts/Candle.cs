using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{

    public Vector3 expandedSize = new Vector3(15, 15, 1);
    public float time = 20;

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
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(WaitUntilEnd(other.transform.GetChild(0).transform));
    }

    IEnumerator WaitUntilEnd(Transform trans)
    {
        Vector3 oldSize = trans.localScale;
        trans.localScale = expandedSize;
        yield return new WaitForSeconds(time);
        trans.localScale = oldSize;
    }
}
