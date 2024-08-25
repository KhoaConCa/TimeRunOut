using System.Collections;
using UnityEngine;

public class ShootH : MonoBehaviour
{
    #region Fields
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private ShootD shootData;
    [SerializeField] private MoveV moveView;
    [SerializeField] private MoveD moveData;
    [SerializeField] private MoveH moveHandler;
    [SerializeField] private LazerH lazerHandler;
    [SerializeField] private LineRenderer laserRenderer;

    public bool isShooting;
    private bool hasReachedMaxAltitude;
    #endregion

    #region Methods
    void Update()
    {
        LimitVelocity();
        FlipWhenShooting();

        if (isShooting)
        {
            Shoot();
            lazerHandler.EnableLazer();
        }
        else
        {
            lazerHandler.DisableLazer();
        }

        if (transform.position.y < shootData.maxAltitude)
        {
            hasReachedMaxAltitude = false;
        }
    }

    #region Constraints
    void LimitVelocity()
    {
        if (body.velocity.magnitude > shootData.maxVelocity && isShooting)
        {
            Vector2 limitedVelocity = body.velocity.normalized * shootData.maxVelocity;
            body.velocity = limitedVelocity;
        }
    }

    void FlipWhenShooting()
    {
        Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        if (direction.x > 0 && !moveHandler.grounded)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction.x < 0 && !moveHandler.grounded)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    #endregion

    #region Shoot
    public void Shoot()
    {
        if (transform.position.y >= shootData.maxAltitude)
        {
            hasReachedMaxAltitude = true;
        }

        if (!hasReachedMaxAltitude)
        {
            Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            body.AddForce(-direction * shootData.thrust, ForceMode2D.Impulse);
        }
    }

    public void StopShoot()
    {
        StartCoroutine(StopAndResume());
    }

    private IEnumerator StopAndResume()
    {
        Vector2 originalVelocity = body.velocity;
        float originalAngularVelocity = body.angularVelocity;

        body.velocity = Vector2.zero;
        body.angularVelocity = 0f;

        yield return new WaitForSeconds(0.5f);

        body.velocity = originalVelocity;
        body.angularVelocity = originalAngularVelocity;
    }
    #endregion

    #endregion
}
