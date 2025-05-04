using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class GameManger : MonoBehaviour
{
    public List<GameObject> targets; //Lists let us pass in the type of thing we want, and array you have to declare what it is when you make it(?)
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (true)/// A While Loop is a fusion of a For Loop and an If Statement, A While Loop will continually run the code but instead of giving it a defined number of times(Like a For Loop). It uses a condition(True/False) to stop running (Like an If Statement)
        {
            // Every 1 second(spawnRate) get a random number between 0 and the number of objects in the List, then spawn the object based on its number in the List.
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }

    }

    public void UpdateScore(int scoreToAdd)// Need to make it public so I can reference this methoed outside of this script.
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
