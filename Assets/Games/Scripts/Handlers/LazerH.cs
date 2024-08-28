using UnityEngine;

public class LazerH : MonoBehaviour
{
    #region Fields
    #region iOS
    [SerializeField] private MoveH moveHandler;
    [SerializeField] public LineRenderer laserRenderer;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private BoxCollider2D bossCollider;
    [SerializeField] public LayerMask bossLayer;
    [SerializeField] private CharacterStats playerStats;
    [SerializeField] private BossStats bossStats;

    public bool shootingStatus;
    public Joystick shootJoystick;
    #endregion

    #region PC
    /*[SerializeField] private MoveH moveHandler;
    [SerializeField] public LineRenderer laserRenderer;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private BoxCollider2D bossCollider;
    [SerializeField] public LayerMask bossLayer;
    [SerializeField] private CharacterStats playerStats;
    [SerializeField] private BossStats bossStats;

    public bool shootingStatus;*/
    #endregion

    #endregion

    #region Methods

    #region Get Collider

    #region iOS
    private Vector2 GetColliderCharacter(Vector2 direction)
    {
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

    private Vector2 GetColliderBoss(Vector2 direction)
    {
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

    #region PC
    /*private Vector2 GetColliderCharacter()
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
    }*/
    #endregion

    #endregion

    #region Lazer

    #region iOS
    public void EnableLazer()
    {
        Vector2 direction = shootJoystick.Direction.normalized;
        Vector2 startPoint = GetColliderCharacter(direction);

        RaycastHit2D hit = Physics2D.Raycast(startPoint, direction, Mathf.Infinity, moveHandler.groundMask | bossLayer);

        if (hit.collider != null)
        {
            Vector2 laserEndPosition = hit.point;

            laserRenderer.enabled = true;
            laserRenderer.SetPosition(0, startPoint);
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

    #region PC
    /*public void EnableLazer()
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
    }*/
    #endregion

    #endregion

    #endregion
}
