using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_XZ : MonoBehaviour
{
    public float speed_walk, speed_run;
    private float speed_override;
    private const string AXIS_HORIZONTAL = "LS_Horizontal";
    private const string AXIS_VERTICAL = "LS_Vertical";
    private bool speedOverRideActive, running;

    public void Movement()
    {
        Vector3 input = new Vector3(Input.GetAxis(AXIS_HORIZONTAL), 0, Input.GetAxis(AXIS_VERTICAL));
        Quaternion targetRotation = Quaternion.LookRotation(input, Vector3.up);

        if (IsMoving() == 1)
        {
            transform.rotation = targetRotation;
            transform.Translate(Vector3.forward * Speed() * IsMoving() * Time.deltaTime);
        }

    }


    public int IsMoving()
    {
        return (Input.GetAxis(AXIS_HORIZONTAL) != 0 || Input.GetAxis(AXIS_VERTICAL) != 0) ? 1 : 0;
    }

    public void ChangeSpeed(float Speed)
    {
        speed_walk = Mathf.Clamp(Speed, 1, 10);
    }

    float Speed()
    {
        if(speedOverRideActive)
        {
            return speed_override;
        }
        else
        {
            return (running) ? speed_run : speed_walk;
        }
    }

    public void OverRideSpeedOn(float newSpeed)
    {
        speed_override = newSpeed;
        speedOverRideActive = true;
    }

    public void OverRideSpeedOff()
    {
        speed_override = 0;
        speedOverRideActive = false;
    }

    public void RunOn()
    {
        running = true;
    }
    public void RunOff()
    {
        running = false;
    }

}
