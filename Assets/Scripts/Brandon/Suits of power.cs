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
    [SerializeField] GameObject[] cards;
    int selector;

    private void Start()
    {

        WT = FindObjectOfType<WizTower_Cast>();
        cat = FindObjectOfType<Catapult>();
        BT = FindObjectOfType<BallistaTower>();
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
                UpCastt(); break;
            case 2:
                BetterBellista(); break;
            case 3:
                SharpEdge(); break;
            default:
               Debug.Log("switch failed");
                break;
        }
    }
    void UpCastt()
    {
        if (cards != null && cards.Length > 0)
        {
            if (cards[1] != null)
            {
                SpriteRenderer spriteRenderer = cards[1].GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    if (spriteRenderer.enabled && spriteRenderer.gameObject.activeInHierarchy)
                    {
                        Debug.Log("The SpriteRenderer is active and visible.");
                    }
                }
            }
        }
    }
    void SharpEdge()
    {
        if (cards != null && cards.Length > 0)
        {
            if (cards[3] != null)
            {
                SpriteRenderer spriteRenderer = cards[3].GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    if (spriteRenderer.enabled && spriteRenderer.gameObject.activeInHierarchy)
                    {
                        Debug.Log("The SpriteRenderer is active and visible.");
                    }
                }
            }
        }
    }
    void BetterBellista()
    {
        if (cards != null && cards.Length > 0)
        {
            if (cards[2] != null)
            {
                SpriteRenderer spriteRenderer = cards[2].GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    if (spriteRenderer.enabled && spriteRenderer.gameObject.activeInHierarchy)
                    {
                        Debug.Log("The SpriteRenderer is active and visible.");
                    }
                }
            }
        }
    }
}

