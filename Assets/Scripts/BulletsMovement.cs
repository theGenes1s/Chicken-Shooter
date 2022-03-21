using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsMovement : MonoBehaviour
{
    private int speed = 25;
    private int yRange = 30;
    private PlayerController playerController;

    //public AudioSource die;



    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        //die = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        if (transform.position.y > yRange)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Destroy(collision.gameObject);
            Destroy(gameObject);
            playerController.UpdateScores(10);
        }

    }
}
