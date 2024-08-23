using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterStats
{
    #region Fields
    int HP { get; set; }
    int ATK { get; set; }
    #endregion

    #region Methods
    void TakeDamge(int damage);
    void Attack(ICharacterStats target);
    #endregion
}
