using UnityEngine;

public interface IShootHandlers
{
    void Shoot();

    void LimitVelocity();

    void Flip();

    void StopShoot();
}
