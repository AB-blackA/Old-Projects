using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControls : MonoBehaviour
{
    
    private void Start()
    {
        if (SystemInfo.supportsGyroscope) //check if device supports gyro
        {
            Input.gyro.enabled = true;//tells the unity engine to use gyroscope.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.supportsGyroscope)
        {
            transform.rotation = GyroToUnity(Input.gyro.attitude);//take gyro input and turn to quaternion
        }
    }

    private Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w); //Unity is a left handed engine while Gyroscopes are right handed, hence the negative z and w
    }
}

