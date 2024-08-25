#region Test
/*using UnityEngine;

public class CameraC : MonoBehaviour
{
    public CameraH cameraHandler;
    public string triggerType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (triggerType)
            {
                case "FollowPlayer":
                    cameraHandler.TriggerFollowPlayer();
                    break;
                case "StopForBoss":
                    cameraHandler.TriggerStopForBoss();
                    break;
*//*              case "AutoMove":
                    cameraHandler.TriggerAutoMove();
                    break;
                case "SpeedRun":
                    cameraHandler.TriggerSpeedRun();
                    break;
                case "SlowMotion":
                    cameraHandler.TriggerSlowMotion();
                    break;*//*
            }
        }
    }
}*/
#endregion

using UnityEngine;

public class CameraC : MonoBehaviour
{
    [SerializeField] private Transform player;
    [Range(0, 1)] public float smooth;

    public Vector2 xLim;
    public Vector2 yLim;
    Vector3 velocity = Vector3.zero;
    public Vector3 positionDefault;

    void LateUpdate()
    {
        Vector3 targetPosition = player.position + positionDefault;
        targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLim.x, xLim.y), Mathf.Clamp(targetPosition.y, yLim.x, yLim.y), -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth);
    }
}