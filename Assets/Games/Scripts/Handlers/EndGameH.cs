using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameH : MonoBehaviour
{
    #region Fields
    [SerializeField] private EndGameC endGameCommand;
    #endregion

    #region Methods
    public void HandleEndGame()
    {
        if (endGameCommand != null)
        {
            endGameCommand.ShowEndGamePanel();
        }
    }
    #endregion
}
