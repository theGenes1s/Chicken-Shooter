using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   
    private float speed = 5.5f;
    private float horizontalMovement;
    private float xRange = 8.35f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lives;

    public GameObject bulletPrefab;
    private int score;
    public bool isGamestarted = false;
    public GameObject titleScreen;
    

    public GameObject PauseButton;
    public GameObject ResumeButton;

    public AudioSource main;


    // Start is called before the first frame update
    void Start()
    {
         main =GetComponent<AudioSource>();
         main.Play();
        
    }
   

    /// <summary>
    /// When the start button is pressed this method will start the gameplay and activate some text like
    /// score , time health on screem.
    /// </summary>
    public void GameStart()
    {
        score = 0;
        isGamestarted = true;
        scoreText.gameObject.SetActive(true);
        lives.gameObject.SetActive(true);
        titleScreen.SetActive(false);
        PauseButton.SetActive(true);
        main.Stop();
    }

    /// <summary>
    /// Pause Game Method
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseButton.SetActive(false);
        ResumeButton.SetActive(true);

    }
    /// <summary>
    /// Resume Gameplay on button press.
    /// </summary>
    public void Resume()
    {
        Time.timeScale = 1;
        PauseButton.SetActive(true);
        ResumeButton.SetActive(false);
    }

/// <summary>
/// Score updation method upon each kill.
/// </summary>
/// <param name="Scorestoadd"></param>
    public void UpdateScores(int Scorestoadd)
    {
        score += Scorestoadd;
        scoreText.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        BulletSpawner(); 
    }
/// <summary>
/// Spawn bullets from player child.
/// </summary>
    private void BulletSpawner()
    {
        if (Input.GetMouseButtonDown(0) && isGamestarted)
        {
            Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y + 0.65f);
            
            Instantiate(bulletPrefab, playerPosition, bulletPrefab.transform.rotation); //Launch bullet projectile.

        }
    }
/// <summary>
/// Player movement along x-axis.
/// </summary>
    private void PlayerMovement()
    {
        if (isGamestarted)
        {
            horizontalMovement = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * speed * Time.deltaTime * horizontalMovement);
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
        }
    }
}
