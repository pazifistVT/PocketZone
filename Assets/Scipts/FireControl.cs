using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    GameObject[] bullets;
    BulletControl[] bulletControls;

    [SerializeField] float pauseBetweenShoots;
    [SerializeField] int poolSize;
    float currentTime;
    bool enableShoot;
    void Start()
    {
        bullets = new GameObject[poolSize];
        bulletControls = new BulletControl[poolSize];
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i] = Instantiate(bulletPrefab);
            bulletControls[i] = bullets[i].GetComponent<BulletControl>();
            bullets[i].SetActive(false);
        }
        enableShoot = true;
        currentTime = 0f;
    }

    void Update()
    {
        if(!enableShoot)
        {
            currentTime += Time.deltaTime;
            if(currentTime >= pauseBetweenShoots)
            {
                enableShoot = true;
                currentTime = 0f;
            }
        }
    }

    public bool Fire(Vector3 pos, Vector3 direction)
    {
        if(enableShoot)
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                if(bullets[i].activeInHierarchy == false)
                {
                    bullets[i].SetActive(true);
                    bullets[i].transform.position = pos;
                    bulletControls[i].StartMoving(direction);
                    enableShoot = false;
                    return true;
                }
            }
        }
        return false;
    }
}
