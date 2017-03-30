using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditorInternal;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : Entity // this is used in order to access the getRotation() method
{
    private float timer = 2f;
    private float maxTimer;

    public Transform BigAstroid;

    // Use this for initialization
    void Start()
    {
        maxTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (maxTimer > 1)
            {
                maxTimer -= 0.2f;
            }
            timer = maxTimer;

            //TODO: Spawn another astroïd
            SpawnAstroid();
        }
    }

    public void SpawnAstroid() //TODO determen position and rotation, then spawn astroid
    {
        float xPos;
        float yPos;
        float rotation;

        int side = Random.Range(1, 5);
        print(side);

        Vector2 spawnPos = new Vector2(0, 0);
        Vector2 targetPos = new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-10f, 10f));

        switch (side)
        {
            case 1: // left
                spawnPos.x = -10.5f;
                spawnPos.y = Random.Range(-8f, 8f);
                break;
            case 2: // top
                spawnPos.x = Random.Range(-10.5f, 10.5f);
                spawnPos.y = 8.0f;
                break;
            case 3: // right
                spawnPos.x = 10.5f;
                spawnPos.y = Random.Range(-8f, 8f);
                break;
            case 4: // bottom
                spawnPos.x = Random.Range(-10.5f, 10.5f);
                spawnPos.y = -8.0f;
                break;
        }

        rotation = getRotation(spawnPos, targetPos);

        if (side == 2 || side == 4)
        {
            rotation = rotation*-1;
        }

        Instantiate(BigAstroid, new Vector3(spawnPos.x, spawnPos.y, 0f), Quaternion.Euler(0f, 0f, rotation));
    }
}
