﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{


    Dino dino;
    EnemySpawn enemySpawn;
    GroundMovement groundMovement;

    bool gameOver = false;

    float timeToIncreaseDifficulty = 0;
    float interval = 5f; // segundos

    void Start()
    {

        dino = FindObjectOfType<Dino>();
        enemySpawn = FindObjectOfType<EnemySpawn>();
        groundMovement = FindObjectOfType<GroundMovement>();

        timeToIncreaseDifficulty = Time.time + interval;

    }

    void Update()
    {

        if (!gameOver)
        {

            if (Physics2D.OverlapBoxAll(dino.transform.position, Vector2.one * 0.3f, 0, LayerMask.GetMask("Enemy")).Length > 0)
            {

                gameOver = true;

                enemySpawn.stopSpawn = true;

                groundMovement.speed = 0;

                Cactus[] allCactus = FindObjectsOfType<Cactus>();
                foreach (Cactus obj in allCactus)
                    obj.speed = 0;

            }

            // aumenta dificuldade
            if (Time.time >= timeToIncreaseDifficulty)
            {

                groundMovement.speed += 0.2f;
                enemySpawn.speed += 0.2f;
                timeToIncreaseDifficulty = Time.time + interval;
            }

        }
        else
        {
            // restart
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
