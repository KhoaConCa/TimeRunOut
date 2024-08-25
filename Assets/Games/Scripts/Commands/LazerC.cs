using UnityEngine;

public class LazerC : MonoBehaviour
{
    #region Fields
    [SerializeField] private LazerH lazerHandler;
    #endregion

    #region Methods
    void Start()
    {
        lazerHandler.shootingStatus = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lazerHandler.shootingStatus = true;
        }

        if (Input.GetMouseButton(0))
        {
            lazerHandler.shootingStatus = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            lazerHandler.shootingStatus = false;
        }

        switch (lazerHandler.shootingStatus)
        {
            case true:
                lazerHandler.EnableLazer();
                break;
            case false:
                lazerHandler.DisableLazer();
                break;
        }
    }
    #endregion
}
