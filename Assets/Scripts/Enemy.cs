using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem hitEffect;
    public GameObject DieEffectPrefab;

    public GameObject projectile;

    public float timer;
    public float duration = 0.5f;

    public int maxHp = 2;
    public int currentHp;

    public int shotRate;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        shotRate = UnityEngine.Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > duration)
        {
            timer = 0f;
            if(shotRate == 0)
            {
                GameObject go = Instantiate(projectile, transform.position, Quaternion.identity);
                Destroy(go, 5f);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Math.Clamp(currentHp -= damage, 0, maxHp);
        if (currentHp <= 0)
        {
            OnDie();
        }
        else
        {
            hitEffect.Play();
        }
    }

    public void OnDie()
    {
        GameObject go = Instantiate(DieEffectPrefab, transform.position, Quaternion.identity);
        go.GetComponent<DieEffect>().DieEffectOn();

        GameManager.Instance.AddScore(1);

        Destroy(gameObject);
    }
}
