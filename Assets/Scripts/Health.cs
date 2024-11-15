using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] GameObject[] objectsToDisable; // Array of objects to disable when the object dies

    

    /* In C# if you do not specify a variable modifier (i.e. public, private, protected), it defaults to private
    The private variable modifier stops other scripts from accessing those variables */
    public int currentHealth;
    #endregion // Marks the end of the region

    #region Unity Methods
    // Start is called before the first frame update
    private void Start()
    {
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
            obj.SetActive(false);
        }
        
        
        if (gameObject.tag == "Player Base") //checks tag for player base to determine if player loss. destroying base objects and giving game over screen
        {
            Debug.Log("game over man");
            gameOver.SetActive(true); ///references EndScreen (canvas) in Unity
            Destroy(gameObject);
        }
        

    }
    #endregion
}

