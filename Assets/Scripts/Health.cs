using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Regions help to visually organize your code into sections.
    #region Variables
    // Headers are like titles for the Unity Inspector.
    [Header("Health Settings")]
    // SerializeField allows you to see private variables in the inspector while keeping them private
    [SerializeField] GameObject gameOver;
    [SerializeField] int maxHealth = 100;
    [SerializeField] Slider healthSlider;
    [SerializeField] List<GameObject> objectsToDisable = new List<GameObject>(); // Array of objects to disable when the object dies
    [SerializeField] GameObject[] units;
    EnemySpawn ES;
    RequisitionPoints rP;

    /* In C# if you do not specify a variable modifier (i.e. public, private, protected), it defaults to private
    The private variable modifier stops other scripts from accessing those variables */
    public int currentHealth;
    #endregion // Marks the end of the region

    private void Update()
    {
        ListClear();
        
    }

    #region Unity Methods
    // Start is called before the first frame update
    private void Start()
    {
        rP = FindObjectOfType<RequisitionPoints>();
        ES = FindObjectOfType<EnemySpawn>();
        if (ES == null)
        {
            Debug.LogError("EnemySpawn not found");
        }
        else
        {
            Debug.Log($"EnemySpawn found. {ES.enemyUndead.Length} undead enemies");
        }

        if (ES != null && ES.enemyUndead != null && ES.enemyUndead.Length > 0)
        {
            units = ES.enemyUndead;
            Debug.Log($"First position: {units[0]?.name}");
        }
        else
        {
            Debug.LogError("ES or ES.enemyUndead is null or empty");
        }
        //Comment out this next line for testing Repair Towers
        currentHealth = maxHealth; // Sets the current health to the max health

        // If the health slider is not null, set the max value and current value
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
        }
    }
    #endregion

    #region Custom Methods
    /// <summary>
    /// Reduces the health of the object
    /// </summary>
    /// <param name="damage">The amount of damage to take</param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduces the health by the damage amount

        // If the health slider is not null, update the value
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth; // Updates the health slider value to the current health
        }

        // If the health is less than or equal to 0, call the Die method
        if (currentHealth <= 0)
        {
            Debug.Log($"ES is null: {ES == null}");

            if (gameObject.CompareTag("Undead"))
            {
                rP.AddPoints(5);
            }
            if (gameObject.CompareTag("Glow Undead"))
            {
                rP.AddPoints(5);
            }
            if (gameObject.CompareTag("Berserker"))
            {
                rP.AddPoints(10);
            }
            else
            {
                Debug.LogWarning("process came up null");
            }

            objectsToDisable.Add(gameObject);
            Die();

        }
    }

    /// <summary>
    /// Destroys the object
    /// </summary>
    private void Die()
    {


        // Disables all objects in the objectsToDisable array
        foreach (GameObject obj in objectsToDisable)
        {
            
            Destroy(gameObject);
        }


        if (gameObject.tag == "Player Base") //checks tag for player base to determine if player loss. destroying base objects and giving game over screen
        {
            Debug.Log("game over man");
            gameOver.SetActive(true); ///references EndScreen (canvas) in Unity
            Destroy(gameObject);
        }

    }

   void ListClear()
    {
        objectsToDisable.RemoveAll(item => item == null);
    }

    // Added to make repair towers work. -Steph
    public void RestoreAllHealth()
    {
        Debug.Log("Restoring health to: " + maxHealth);
        currentHealth = maxHealth;
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth; // Update the slider
        }
    }

    #endregion
}