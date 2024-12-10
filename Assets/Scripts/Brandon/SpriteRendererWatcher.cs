using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpriteRendererWatcher : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Custom UnityEvent that passes the GameObject as a parameter
    public UnityEvent<GameObject> OnSpriteEnabled;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (spriteRenderer != null)
        {
            if (spriteRenderer.enabled && spriteRenderer.gameObject.activeInHierarchy)
            {
               // Debug.Log($"SpriteRenderer active on {gameObject.name}");
                OnSpriteEnabled?.Invoke(gameObject); // Pass the current GameObject
            }
        }
        else
        {
           // Debug.LogWarning($"SpriteRenderer not found on {gameObject.name}");
        }
    }
}

