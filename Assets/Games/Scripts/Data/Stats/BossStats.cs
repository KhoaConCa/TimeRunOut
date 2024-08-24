using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour, ICharacterStats
{
    #region Fields
    public int HP = 150000;
    public int ATK = 1;
    #endregion

    #region Methods
    public void TakeDamage(int damage)
    {
        int actualDamage = damage;
        if (actualDamage > 0)
        {
            HP -= actualDamage;
        }
    }

    public void Attack(ICharacterStats target)
    {
        target.TakeDamge(ATK);
    }
    #endregion

    #region Implements
    int ICharacterStats.HP { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    int ICharacterStats.ATK { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public void TakeDamge(int damage)
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
