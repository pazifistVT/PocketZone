using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    MoveScript moveScript;
    Vector3 startPos;
    void Awake()
    {
        moveScript = GetComponent<MoveScript>();
    }

    public void StartMoving(Vector3 dir)
    {
        moveScript.SetDirection(dir);
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 distance = startPos - transform.position;
        if(distance.magnitude >= 1.5f)
        {
            DestoyBullet();
        }
    }

    public void DestoyBullet()
    {
        moveScript.SetDirection(Vector3.zero);
        gameObject.SetActive(false);
    }
}
