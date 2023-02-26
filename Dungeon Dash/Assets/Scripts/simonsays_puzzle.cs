using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using Internal;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simonsays_puzzle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] keyPattern = [];
        for (int i = 0; i < 4; i++) {
            keyPattern.Add(Random.Range(0,4));
            Console.WriteLine(keyPattern);
        }
    }

    // Update is called once per frame
    void Update()
    {
        i = 0;
        switch (keyPattern[i])
        {
            case 1:
                if (Input.GetKeyDown(KeyCode.W)) {
                    if (i < keyPatten.Count) {
                        Console.WriteLine("detected");
                        return True;
                        break;
                    }
                    else
                    {
                        i++;
                        break;
                    }
                }
                else {
                    break;
                }
            default:
        }
    }
}
