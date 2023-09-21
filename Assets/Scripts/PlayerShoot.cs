using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;

    public Transform fireCenPos;
    public Transform fireLeftPos;
    public Transform fireRightPos;

    public ParticleSystem fireCenParticle;
    public ParticleSystem fireLeftParticle;
    public ParticleSystem fireRightParticle;

    public float shootDelay = 2f;
    public float shootTimer;

    public Vector3 phasePos = new Vector3(0.5f, 0, 0);
    public int projectilePhase = 0;

    // Update is called once per frame
    void Update()
    {
        AutoShoot();
    }

    void AutoShoot()
    {
        shootTimer += Time.deltaTime;
        if ( shootTimer > shootDelay )
        {
            shootTimer = 0;
            switch(projectilePhase)
            {
                case 0:
                    Instantiate(projectile, fireCenPos.position, Quaternion.identity);
                    fireCenParticle.Play();
                    break;
                case 1:
                    Instantiate(projectile, fireCenPos.position - phasePos, Quaternion.identity);
                    Instantiate(projectile, fireCenPos.position + phasePos, Quaternion.identity);
                    fireCenParticle.Play();

                    break;
                case 2:
                    Quaternion leftrotation = Quaternion.Euler(new Vector3(0, 0, 1.5f));
                    Quaternion rightrotation = Quaternion.Euler(new Vector3(0, 0, -1.5f));

                    Instantiate(projectile, fireCenPos.position, Quaternion.identity);
                    Instantiate(projectile, fireLeftPos.position, leftrotation);
                    Instantiate(projectile, fireRightPos.position, rightrotation);

                    fireCenParticle.Play();
                    fireLeftParticle.Play();
                    fireRightParticle.Play();
                    break;
                default:
                    Quaternion leftrotation1 = Quaternion.Euler(new Vector3(0, 0, 4f));
                    Quaternion leftrotation2 = Quaternion.Euler(new Vector3(0, 0, 16f));

                    Quaternion rightrotation1 = Quaternion.Euler(new Vector3(0, 0, -4f));
                    Quaternion rightrotation2 = Quaternion.Euler(new Vector3(0, 0, -16f));


                    Instantiate(projectile, fireCenPos.position, Quaternion.identity);

                    Instantiate(projectile, fireLeftPos.position, leftrotation1);
                    Instantiate(projectile, fireLeftPos.position, leftrotation2);

                    Instantiate(projectile, fireRightPos.position, rightrotation1);
                    Instantiate(projectile, fireRightPos.position, rightrotation2);

                    fireCenParticle.Play();
                    fireLeftParticle.Play();
                    fireRightParticle.Play();

                    break;
            }
        }
    }

    public void EatItem()
    {
        projectilePhase++;
    }
}
