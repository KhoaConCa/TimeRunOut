using UnityEngine;

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
                case "AutoMove":
                    cameraHandler.TriggerAutoMove();
                    break;
                case "SpeedRun":
                    cameraHandler.TriggerSpeedRun();
                    break;
                case "SlowMotion":
                    cameraHandler.TriggerSlowMotion();
                    break;
                case "StopForBoss":
                    cameraHandler.TriggerStopForBoss();
                    break;
            }
        }
    }
}
