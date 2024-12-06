using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Suitsofpower : MonoBehaviour
{
    RepairTower RT;
    WizTower_Cast WT;
    Catapult cat;
    BallistaTower BT;
    Rotate spin;
    [SerializeField] GameObject[] cards;
    int selector;

    private void Start()
    {

        WT = FindObjectOfType<WizTower_Cast>();
        cat = FindObjectOfType<Catapult>();
        BT = FindObjectOfType<BallistaTower>();
        spin = FindObjectOfType<Rotate>();
        // Attach listeners to each card's SpriteRendererWatcher
        foreach (GameObject card in cards)
        {
            if (card != null)
            {
                SpriteRendererWatcher watcher = card.GetComponent<SpriteRendererWatcher>();
                if (watcher != null)
                {
                    watcher.OnSpriteEnabled.AddListener(OnSpriteActivated);
                }
            }
        }
    }

    private void OnSpriteActivated(GameObject triggeringCard)
    {
        Debug.Log("starting search");
        // Check which GameObject in cards triggered the event
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i] == triggeringCard)
            {
               selector = i;
                break; // Exit loop once the matching card is found
                
            }
        }
        Debug.Log($"your card is {selector}");
        switch (selector)
        {
            case 0:
                cat.Boost(); break;
            case 1:
                WT.Boost(); break;
            case 2:
                BT.Boost(); break;
            case 3:
                spin.Boost(); break;
            default:
               Debug.Log("switch failed");
                break;
        }
    }
}

