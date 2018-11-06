using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public GameObject ball;
    private Vector3 start;
    private Vector3 end;
    private float distance = 15f;
    private float lerpTime = .2f;
    private float currentLerpTime = 0;

    private bool keyHit = false;

    void Update()
    {
        //check to see if space is hit, and reset values
        if (keyHit == false)
        {
            currentLerpTime = 0;
        }

        //if space is hit for the first time, send ball to other side
        if (Input.GetKeyDown(KeyCode.Space) && currentLerpTime == 0)
        {
            keyHit = true;

            if (ball.transform.position.x < 7.5)
            {
                start = ball.transform.position;
                end = ball.transform.position + Vector3.right * distance;
            }
            else if (ball.transform.position.x > -7.5)
            {
                start = ball.transform.position;
                end = ball.transform.position + Vector3.left * distance;
            }
        }

        //if space is hit, lerp the ball from start to end
        if (keyHit == true)
        {
            currentLerpTime += Time.deltaTime;

            if (currentLerpTime >= lerpTime)
            {
                currentLerpTime = lerpTime;
                keyHit = false;
            }

            float Perc = currentLerpTime / lerpTime;
            ball.transform.position = Vector3.Lerp(start, end, Perc);
        }
    }
}