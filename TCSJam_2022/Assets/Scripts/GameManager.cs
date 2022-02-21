using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* 3D clock model - https://www.turbosquid.com/3d-models/3d-alarm-clock/529790 */

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public float GameTimer { get; set; }


    [SerializeField] private TMP_Text _timerText; 
    [SerializeField] private float _timerReduceRate;
    [SerializeField] private int maxSpawnedPlatforms = 3;
    private Queue<GameObject> spawnedPlatforms;


    private void Start()
    {
        Time.timeScale = 0;
        GameTimer = 30f;
        spawnedPlatforms = new Queue<GameObject>();
        GameObject basePlatform = GameObject.FindGameObjectWithTag("BasePlatform");
        AddPlatforms(basePlatform);
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

    }

    private void Update()
    {
        DecreaseTimer();
        RemoveExcessPlatforms();
    }

    private void DecreaseTimer()
    {
        if(GameTimer <= 0)
        {
            GameOver();
            return;
        }

        _timerText.color = GameTimer <= 5 ? Color.red : Color.black; //change the text color to indicate very low amount of time


        GameTimer -=  _timerReduceRate * Time.deltaTime;
        _timerText.text = GameTimer.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        UIManager.instance.EnableGameOverPanel(); //GameOver condition
    }

    private void RemoveExcessPlatforms()
    {
        if(spawnedPlatforms.Count >= maxSpawnedPlatforms)
        {
            GameObject lastPlatform = spawnedPlatforms.Dequeue();
            Destroy(lastPlatform);         
        }
       
    }
    public void AddPlatforms(GameObject platformObj)
    {
        spawnedPlatforms.Enqueue(platformObj);
    }



}
