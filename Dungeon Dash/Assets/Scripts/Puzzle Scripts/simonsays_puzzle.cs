using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class simonsays_puzzle : MonoBehaviour
{
    public static List<int> randKeys = new List<int>();
    int loop = 0;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
         for (int i = 0; i<4; i++) {
            randKeys.Add(Random.Range(1,4));
         }
    }

    // Update is called once per frame
    void Update()
    {
        while (loop < 1) {
            switch(randKeys[index]) {
                case 1:
                    if (index > 4)
                    {
                        loop++;
                        break;
                    }
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        index++;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 2:
                    if (index > 4)
                    {
                        loop++;
                        break;
                    }
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        index++;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 3:
                    if (index > 4)
                    {
                        loop++;
                        break;
                    }
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        index++;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 4:
                    if (index > 4)
                    {
                        loop++;
                        break;
                    }
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        index++;
                        break;
                    }
                    else
                    {
                        break;
                    }
            }
        }
    }
}
