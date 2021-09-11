using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    float moveSpeed;
    public bool isObstacle;
    public Sprite[] obstacleImage;
    void Start()
    {
        moveSpeed = FindObjectOfType<ObstacleManager>().groundMoveSpeed;
        if (!isObstacle)
        {
            moveSpeed /= 3;
        }
        else{
           GetComponent<SpriteRenderer>().sprite = obstacleImage[Random.Range(0, obstacleImage.Length)];
        }
        Destroy(gameObject, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
    
}
