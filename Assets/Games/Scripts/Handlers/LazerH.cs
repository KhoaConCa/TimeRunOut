using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LazerH : MonoBehaviour
{
    #region Fields
    [SerializeField] private MoveH moveHandler;
    [SerializeField] public LineRenderer laserRenderer;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private BoxCollider2D bossCollider;
    [SerializeField] public LayerMask bossLayer;
    [SerializeField] private CharacterStats playerStats;
    [SerializeField] private BossStats bossStats;

    public bool shootingStatus;
    #endregion

    #region Methods
    void Update()
    {
        switch (shootingStatus)
        {
            case true:
                EnableLazer();
                break;
            case false:
                DisableLazer();
                break;
        }
    }
    #region Get Collider
    private Vector2 GetColliderCharacter()
    {
        Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        Vector2 lazerStartPosition = transform.position;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                lazerStartPosition = new Vector2(playerCollider.bounds.max.x, transform.position.y);
            }
            else
            {
                lazerStartPosition = new Vector2(playerCollider.bounds.min.x, transform.position.y);
            }
        }
        else
        {
            if (direction.y > 0)
            {
                lazerStartPosition = new Vector2(transform.position.x, playerCollider.bounds.max.y);
            }
            else
            {
                lazerStartPosition = new Vector2(transform.position.x, playerCollider.bounds.min.y);
            }
        }

        return lazerStartPosition;
    }

    private Vector2 GetColliderBoss()
    {
        Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        Vector2 lazerStartPosition = transform.position;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                lazerStartPosition = new Vector2(playerCollider.bounds.max.x, transform.position.y);
            }
            else
            {
                lazerStartPosition = new Vector2(playerCollider.bounds.min.x, transform.position.y);
            }
        }
        else
        {
            if (direction.y > 0)
            {
                lazerStartPosition = new Vector2(transform.position.x, playerCollider.bounds.max.y);
            }
            else
            {
                lazerStartPosition = new Vector2(transform.position.x, playerCollider.bounds.min.y);
            }
        }

        return lazerStartPosition;
    }
    #endregion

    #region Lazer
    public void EnableLazer()
    {
        GetColliderCharacter();

        Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(GetColliderCharacter(), direction, Mathf.Infinity, moveHandler.groundMask | bossLayer);

        if (hit.collider != null)
        {
            Vector2 laserEndPosition = hit.point;

            laserRenderer.enabled = true;
            laserRenderer.SetPosition(0, GetColliderCharacter());
            laserRenderer.SetPosition(1, laserEndPosition);

            if (((1 << hit.collider.gameObject.layer) & bossLayer) != 0)
            {
                bossStats.TakeDamage(playerStats.ATK);
            }
        }
        else
        {
            DisableLazer();
        }
    }

    public void DisableLazer()
    {
        laserRenderer.enabled = false;
    }
    #endregion

    #endregion
}
