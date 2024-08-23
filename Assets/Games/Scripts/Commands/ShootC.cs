using UnityEngine;

public class ShootC : MonoBehaviour
{
    #region Fields
    [SerializeField] private ShootH shootHandler;
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
    }
    #endregion
}
