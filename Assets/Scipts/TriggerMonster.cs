using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMonster : MonoBehaviour
{
    [SerializeField] MonsterControl monsterControl;
    PlayerControl playerControl;


    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject go = other.gameObject;
        if(go.GetComponentInParent<PlayerControl>() != null)
        {
            playerControl = go.GetComponentInParent<PlayerControl>();
            monsterControl.SetNewState(State.attackPlayer);
            monsterControl.SetTarget(go);

            playerControl.AddMonster(monsterControl);
        }

        if (go.GetComponent<BulletControl>() != null)
        {
            BulletControl bulletControl = go.GetComponent<BulletControl>();
            bulletControl.DestoyBullet();
            monsterControl.Hit(playerControl);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        if (go.GetComponent<PlayerControl>() != null)
        {
            monsterControl.AttemptAttack();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        if (go.GetComponentInParent<PlayerControl>() != null)
        {
            playerControl.RemoveMonster(monsterControl);
        }
    }
}
