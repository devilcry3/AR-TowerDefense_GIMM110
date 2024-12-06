using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    Health hp;
    EnemySpawn eS;
    int wave = 1;
    int maxTut = 10;
    public int tut = 0;
    int maxGlow = 30;
   public int glow=0;
    int maxBerserk = 10;
   public int berserk=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(wave == 1) { Wave1(); }   
       if(wave == 2) { Wave2(); }
       if(wave == 3) { Wave2(); }
    }
    
    void Wave1()
    {
        if(tut == maxTut)
        {

        }
    }

    void Wave2()
    {

    }
    void Wave3()
    {

    }
}
