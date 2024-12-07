using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
   public List<GameObject> enemyList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.tag =="Undead")
        {
            enemyList.Add(other.gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag =="Undead")
        {
            enemyList.Remove(other.gameObject);
        }
    }
}
