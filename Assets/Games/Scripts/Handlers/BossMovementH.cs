using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementH : MonoBehaviour
{
    public float speed;
    Vector3 targetPosition;

    public GameObject ways;
    public Transform[] wayPoints;
    int index;
    int count;
    int direction = 1;

    public float waitDuration;
    int speedMultiplier = 1;

    private void Start()
    {
        count = wayPoints.Length;
        index = 1;
        targetPosition = wayPoints[index].transform.position;
    }

    private void Update()
    {
        var step = speedMultiplier * speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (transform.position == targetPosition)
        {
            NextPoint();
        }
    }

    public void NextPoint()
    {
        if (index == count - 1)
        {
            direction = -1;
        }

        if (index == 0)
        {
            direction = 1;
        }

        index += direction;
        targetPosition = wayPoints[index].transform.position;
        FlipBoss(transform.position.x);
        StartCoroutine(WaitNextPoint());
    }

    public void FlipBoss(float x)
    {
        if (x > 0)
        {
            transform.localScale = new Vector3(-8, 8, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(8, 8, 1);
        }
    }

    IEnumerator WaitNextPoint()
    {
        speedMultiplier = 0;
        yield return new WaitForSeconds(waitDuration);
        speedMultiplier = 1;
    }
}
