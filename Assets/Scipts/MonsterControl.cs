using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class MonsterControl : MonoBehaviour
{
    [SerializeField] int startHp;
    MoveScript moveScript;
    hpBarControl hpBarControl;
    FireControl attackControl;
    GameObject target;
    State state;
    int hp = 3;
    void Awake()
    {
        moveScript = GetComponent<MoveScript>();
        hpBarControl = GetComponentInChildren<hpBarControl>();
        attackControl = GetComponentInChildren<FireControl>();
    }

    void Update()
    {
        if(state == State.attackPlayer)
        {
            Vector3 dir = (target.transform.position - transform.position);
            dir.Normalize();
            moveScript.SetDirection(dir);
        }
    }

    public void AttemptAttack()
    {
        attackControl.Fire(transform.position, (target.transform.position - transform.position).normalized);
    }

    public void SetNewState(State state)
    {
        this.state = state;
    }

    public void SetTarget(GameObject go)
    {
        target = go;
    }

    public void KillMonster()
    {
        Item newItem = null;
        Items item = (Items)(Random.Range((int)Items.none, (int)Items.ammo) + 1);
        switch (item)
        {
            case Items.none:
                break;
            case Items.BulletproofCloak:
                newItem = (Item)(new BulletproofCloak(1));
                break;
            case Items.ammo:
                newItem = (Item)(new Ammo(15));
                break;
            default:
                break;
        }
        if (newItem != null) { itemsControl.ItemsControl.SpawnNewItem(transform.position, newItem); }
        gameObject.SetActive(false);
    }

    public void SpawnMonster(Vector3 pos)
    {
        gameObject.transform.position = pos;
        state = State.stay;
        moveScript.SetDirection(Vector3.zero);
        hp = startHp;
        hpBarControl.SetMaxHP(startHp);
        hpBarControl.UpdateHP(hp);
    }
    public void Hit(PlayerControl playerControl)
    {
        hp -= 1;
        hpBarControl.UpdateHP(hp);
        if (hp <= 0)
        {
            KillMonster();
            playerControl.RemoveMonster(this);
        }
    }
}

public enum State
{
    stay,
    attackPlayer
}
