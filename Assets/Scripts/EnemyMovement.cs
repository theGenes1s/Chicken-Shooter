using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 0.5f;
    private bool xdirection = true;
    private int movement = 1;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DirectionChanger());

    }


    IEnumerator DirectionChanger()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(2f);
            if (xdirection)
            {
                xdirection = false;
                movement = -1;
            }
            else
            {
                xdirection = true;
                movement = 1;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.right * speed * Time.deltaTime * movement);
    }
}
