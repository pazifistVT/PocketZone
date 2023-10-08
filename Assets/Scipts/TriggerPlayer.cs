using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayer : MonoBehaviour
{
    [SerializeField] PlayerControl playerControl;


    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject go = other.gameObject;

        if (go.GetComponent<BulletControl>() != null)
        {
            BulletControl bulletControl = go.GetComponentInParent<BulletControl>();
            bulletControl.DestoyBullet();
            playerControl.RecieveDamage();
        }
    }
}
