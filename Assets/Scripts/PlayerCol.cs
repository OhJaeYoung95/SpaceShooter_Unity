using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCol : MonoBehaviour
{
    public GameObject dieEffectPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            GameObject effect = Instantiate(dieEffectPrefab, transform.position, Quaternion.identity);
            effect.GetComponent<DieEffect>().DieEffectOn();

            GameManager.Instance.OnPlayerDead();
            Destroy(gameObject);
        }
        if(collision.CompareTag("EnemyProjectile"))
        {
            GameObject effect = Instantiate(dieEffectPrefab, transform.position, Quaternion.identity);
            effect.GetComponent<DieEffect>().DieEffectOn();

            GameManager.Instance.OnPlayerDead();
            Destroy(gameObject);
        }

    }
}
