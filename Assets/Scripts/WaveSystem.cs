using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Wave
{
    public Transform[] pos;
    public int type;
}

public class WaveSystem : MonoBehaviour
{
    public GameObject enemy;

    public int waveType = 0;
    public int waveCount = 10;

    public int maxWaveType;
    public int currentWaveType;

    public Wave[] waves;

    public bool isEndPattern = true;

    // Start is called before the first frame update
    void Start()
    {
        maxWaveType = waves.Length * 2;
        currentWaveType = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaveType == maxWaveType && isEndPattern && !GameManager.Instance.IsGameOver)
        {
            GameManager.Instance.OnGameClear();
        }

        if (isEndPattern && currentWaveType != maxWaveType)
        {
            if(waveType < 2)
            {
                StartCoroutine(CreatEnemys(waveCount, waveType, Random.Range(0.2f, 0.4f)));
            }
            else
            {
                int randType = Random.Range(0, waves.Length);
                StartCoroutine(CreatEnemys(waveCount, waveType, Random.Range(0.2f, 0.4f)));
                StartCoroutine(CreatEnemys(waveCount, randType, Random.Range(0.2f, 0.6f)));
            }
            waveType++;

            currentWaveType++;
            waveType %= waves.Length;
        }

    }

    IEnumerator CreatEnemys(int count, int type, float delay)
    {
        isEndPattern = false;
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(enemy, waves[type].pos[0].position, Quaternion.identity);
            go.GetComponent<EnemyMovement>().SetWaveType(type, waves[type].pos);
            yield return new WaitForSeconds(delay);
        }
        isEndPattern = true;
    }

}
