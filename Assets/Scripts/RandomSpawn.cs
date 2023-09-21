using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public float clampMinX;
    public float clampMaxX;

    public GameObject[] spawnObjects;

    public float delayTimer;
    public float delayDurationMin = 4f;
    public float delayDurationMax = 7f;

    public float delayDuration = 3f;

    // Update is called once per frame
    void Update()
    {
        delayTimer += Time.deltaTime;

        if (delayTimer > delayDuration)
        {
            delayTimer = 0f;
            delayDuration = Random.Range(delayDurationMin, delayDurationMax);
            Spawn();
        }
    }

    public void Spawn()
    {
        // Debug.Log(spawnObjects.Length);
        int randIndex = Random.Range(0, spawnObjects.Length);
        float randPosX = Random.Range(clampMinX, clampMaxX);
        Vector2 pos = new Vector2(randPosX, transform.position.y);
        GameObject go = Instantiate(spawnObjects[randIndex], pos, Quaternion.identity);
        Destroy(go, 10f);
    }
}
