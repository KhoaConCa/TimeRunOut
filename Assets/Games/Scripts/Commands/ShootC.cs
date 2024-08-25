using UnityEngine;

public class ShootC : MonoBehaviour
{
    #region Fields
    [SerializeField] private ShootH shootHandler;
    [SerializeField] private LazerH lazerHandler;
    #endregion

    #region Methods
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shootHandler.isShooting = true;
        }
        else
        {
            shootHandler.isShooting = false;
        }

        shootHandler.LimitVelocity();
        shootHandler.FlipWhenShooting();

        if (shootHandler.isShooting)
        {
            shootHandler.Shoot();
            lazerHandler.EnableLazer();
        }
        else
        {
            lazerHandler.DisableLazer();
        }

        if (transform.position.y < shootHandler.shootData.maxAltitude)
        {
            shootHandler.hasReachedMaxAltitude = false;
        }
    }
    #endregion
}
