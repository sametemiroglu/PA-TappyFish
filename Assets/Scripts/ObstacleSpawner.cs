using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    float timer;
    public float maxTime;
    public float minY;
    public float maxY;
    private float randomY;
    
    public void InstantiateObstacle()
    {
        randomY = Random.Range(minY, maxY);
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector3 (transform.position.x, randomY,0);
    }
    void Start()
    {
        //InstantiateObstacle();
    }

    
    void Update()
    {

        if (GameManager.gameOver ==  false && GameManager.gameStarted == true) 
        {
            timer += Time.deltaTime;

            if (timer >= maxTime)
            {
                InstantiateObstacle();
                timer = 0;
            }

        }     
    }
}
