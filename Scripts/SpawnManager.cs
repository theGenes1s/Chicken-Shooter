using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    
    public int enemyCount;
    private PlayerController playerController;

    public TextMeshProUGUI timerText;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        timer = 0;
    }
    void SpawnWaves()
    {
        int randomWaves = Random.Range(0, 5);
        Instantiate(enemyPrefab[randomWaves], enemyPrefab[randomWaves].transform.position, enemyPrefab[randomWaves].transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyMovement>().Length;
        if (enemyCount == 0 && playerController.isGamestarted)
        {
             

            SpawnWaves();
            timerText.gameObject.SetActive(true);
            timer = 0;


        }
        timer += Time.deltaTime;
        timerText.text = "Time : " + Mathf.Round(timer);
    }
}
