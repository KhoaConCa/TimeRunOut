using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointC : MonoBehaviour
{
    #region Fields
    [SerializeField] private RespawnH respawnHandler;

    //private SpriteRenderer spriteRenderer;
    public Transform respawnPoint;
    //private Sprite passive, active;
    #endregion

    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            respawnHandler.UpdateCheckPoint(respawnPoint.position);
            //spriteRenderer.sprite = active;
        }
    }
    #endregion
}
