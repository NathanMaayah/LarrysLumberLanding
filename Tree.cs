using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    // treated the tree like an enemy and used combat logic to destroy/chop it
    public int maxHealth = 1;
    int currentHealth;

    private TreeSpawner treeSpawner;

    private AudioSource audioSource;
    
    public ScoreCounter scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
// score counting stuff
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        if (scoreGO != null)
        {
            scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        }

        currentHealth = maxHealth; // tree health set to one so its a quick kill
        treeSpawner = FindObjectOfType<TreeSpawner>();
        audioSource = GetComponent<AudioSource>();

        
    }

    public void TakeDamage(int damage){
        currentHealth -= damage; // attack the tree

        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){ // killed the tree
    if (treeSpawner != null)
    {
        treeSpawner.TreeDestroyed(gameObject);
    }

    // Update the scoe
    if (scoreCounter != null)
    {
        scoreCounter.score += 1;
        HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        Debug.Log("Score updated: " + scoreCounter.score); // Debug line
    }
    else
    {// check if score board is working (it was but not updating on screen)
        Debug.LogWarning("ScoreCounter reference is missing in Tree script!");
    }

    // Play tree sound
    if (audioSource != null && audioSource.clip != null)
    {
        AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
    }

    // Destroy the tree 
    Destroy(gameObject);
}

}
