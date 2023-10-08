using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpBarControl : MonoBehaviour
{
    [SerializeField] Transform currentHP;
    int maxHp;

    public void SetMaxHP(int maxHp)
    {
        this.maxHp = maxHp;
    }
    public void UpdateHP(int hp)
    {
        Vector3 scale = currentHP.localScale;
        scale.x = (float)hp / maxHp;
        currentHP.localScale = scale;
    }
}
