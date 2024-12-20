using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wave : MonoBehaviour
{
    Health hp;
    EnemySpawn eS;
    [SerializeField] int wave = 1;
    [SerializeField] GameObject MainTrack;
    [SerializeField] GameObject BossTrack;
    int maxTut = 10;
    int maxBerserk = 10;
    int maxGlow = 20;
    public int tut = 0;
    public int glow=0;
    public int berserk = 0;
    bool nextWaveStarting = false;

    [SerializeField] GameObject necroSpeech;
    int speechTime = 4;

    // Start is called before the first frame update
    void Start()
    {
        hp = FindObjectOfType<Health>();
        eS = GetComponent<EnemySpawn>();
        StartCoroutine(Necromancer());
        
    }

    // Update is called once per frame
    void Update()
    { //using update to do a wave check, in each method their is a further check
       if(wave == 1) { Wave1(); }   
       if(wave == 2) { Wave2(); }
       if(wave == 3) { Wave3(); }
    }
    
    void Wave1()
    {
        if(tut >= maxTut && !nextWaveStarting)
        {
            nextWaveStarting = true;
            StartCoroutine(Necromancer());
           StartCoroutine(NextWave(1)); //calls coroutine to begin moving into the next wave
            
        }
    }

    void Wave2()
    {
        if (glow >= maxGlow && !nextWaveStarting)
        {
            StartCoroutine(Necromancer());
            nextWaveStarting = true;
            StartCoroutine(NextWave(2)); 
            MainTrack.SetActive(false);
            BossTrack.SetActive(true);
        }
    }
    void Wave3()
    {
        if (glow >= maxGlow && berserk >= maxBerserk)
        {
            StartCoroutine(Necromancer());
            SceneManager.LoadScene(3);
        }
    }

    IEnumerator NextWave(int x)
    {
        yield return new WaitForSeconds(4);

        //Necromance speach blurb
        yield return new WaitForSeconds(1);

        eS.waveCheck(x);
        glow = 0;
        if (x == 1) { wave = 2; }
        else if (x == 2) { wave = 3; maxGlow = 30; }
        else { }
        nextWaveStarting = false;
        //Debug.Log("next wave started");
    }

    private IEnumerator Necromancer()
    {
        necroSpeech.SetActive(true);
        yield return new WaitForSeconds(speechTime);
        necroSpeech.SetActive(false);
    }
}
