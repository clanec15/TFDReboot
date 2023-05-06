using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.Security.Cryptography;

public class IDGenerator : MonoBehaviour
{
    public int seed;
    
    //public int[] tagidentificators = new int[4] {0, 0, 0, 0};
    void OnEnable()
    {
        byte[] seedBytes = new byte[4];
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        rng.GetBytes(seedBytes);
        seed = BitConverter.ToInt32(seedBytes, 0); 

        seed = Mathf.Abs(seed)/ (10 ^ 7)
        ;
        /*
        tagidentificators[0] = seed/1000000
        ;
        tagidentificators[1] = (seed / 10000) % 100
        ;
        tagidentificators[2] = (seed / 100) % 100
        ;
        tagidentificators[3] = seed % 100
        ;*/
    }
}
