using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointC : MonoBehaviour
{
    #region Fields
    [SerializeField] private RespawnH respawnHandler;
    #endregion

    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            respawnHandler.UpdateCheckPoint(transform.position);
        }
    }
    #endregion
}
