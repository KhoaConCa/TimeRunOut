using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameH : MonoBehaviour
{
    [SerializeField] private EndGameC endGameCommand;

    public void HandleEndGame()
    {
        if (endGameCommand != null)
        {
            endGameCommand.ShowEndGamePanel();
        }
    }
}
