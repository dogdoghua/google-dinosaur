using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ObstacleManager : MonoBehaviour
{
    public float groundMoveSpeed = 20;
    public GameObject[] obstacles;
    public GameObject cloudPrefab;
    public GameObject retryButton; 

    public Vector2 spawnRateRange;
    public Vector2 cloudSpawnRateRange;

    public Text scoreText;
    

    float timer;
    float spawnRate;
    float cloudtimer;
    float cloudSpawnRate;
    float score;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Random.Range(spawnRateRange.x, spawnRateRange.y);
        cloudSpawnRate = Random.Range(cloudSpawnRateRange.x, cloudSpawnRateRange.y);
        retryButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        cloudtimer += Time.deltaTime;
        if(timer > spawnRate){
            SpawnNewObstacle();
            timer = 0;
        }
        if(cloudtimer > cloudSpawnRate){
            cloudSpawnNewObstacle();
            cloudtimer = 0;
        }
        string zero = "00000";
        score += Time.deltaTime * 10;
        scoreText.text = "SCORE " + zero.Substring(0, zero.Length - ((int)score).ToString().Length) + ((int)score).ToString();
    }

    void SpawnNewObstacle(){
        int index = Random.Range(0, obstacles.Length);
        GameObject obstacle = Instantiate(obstacles[index], transform);
        obstacle.transform.localPosition = new Vector3(32f, -1.8f, 0); 
    }
    void cloudSpawnNewObstacle(){
        GameObject cloud = Instantiate(cloudPrefab, transform);
        cloud.transform.localPosition = new Vector3(32f,Random.Range(0, 3.5f), 0); 
    }

    public void GameOver(){
        retryButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void Retry(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
