using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackGround : MonoBehaviour
{
    float moveSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = FindObjectOfType<ObstacleManager>().groundMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if(transform.position.x < -55.47f)
        {
            transform.position = new Vector3(55.47f, -2.3f, 0);
        }
    }
}
