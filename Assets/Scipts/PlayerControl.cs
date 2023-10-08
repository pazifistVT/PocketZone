using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] itemsControl itemsControl;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] FireControl fireControl;
    [SerializeField] int startHp;
    List<MonsterControl> monsters;
    hpBarControl hpBarControl;
    int hp;
    public bool isAlive;
    void Start()
    {
        monsters = new List<MonsterControl>();
        hpBarControl = GetComponentInChildren<hpBarControl>();

        SpawnPlayer();
    }

    public void AttemptFire()
    {
        if (monsters.Count > 0)
        {
            if (itemsControl.CheckItem((Item)new Ammo(1)))
            {
                Vector3 v = monsters[0].transform.position - transform.position;
                v.Normalize();
                if (fireControl.Fire(transform.position + (v * 0.25f), v.normalized))
                {
                    itemsControl.ConsumptItem((Item)new Ammo(1));

                }
            }
        }
    }

    public void SpawnPlayer()
    {
        transform.position = Vector3.zero;
        hp = startHp;
        hpBarControl.SetMaxHP(startHp);
        hpBarControl.UpdateHP(hp);
        isAlive = true;
    }

    public void AddMonster(MonsterControl monster)
    {
        monsters.Add(monster);
    }

    public void RemoveMonster(MonsterControl monster)
    {
        monsters.Remove(monster);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        isAlive = false;
    }

    public void RecieveDamage()
    {
        if (isAlive)
        {
            hp -= 1;
            hpBarControl.UpdateHP(hp);
            if (hp <= 0)
            {
                GameOver();
            }
        }
        
    }
}
