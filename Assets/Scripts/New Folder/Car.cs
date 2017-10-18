using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    WheelJoint2D[] wheelJoin;
    JointMotor2D forontWheel;
    JointMotor2D backWheel;

   public float maxSpeed = -1000f;
   private float maxSpeedBack = 1500f;
   private float acceleration  = 250f;
   private float deAcceleration = -100f;
   public float backForce = 3000f;
   private float gravi = 9.8f;
   private float angleCar = 0;
   public Clic[] ControlCar;
	// Use this for initialization
	void Start () {
        wheelJoin = gameObject.GetComponents<WheelJoint2D>();
        forontWheel = wheelJoin[0].motor;
        backWheel = wheelJoin[1].motor;
	}

    void FixedUpdate()
    {
        forontWheel.motorSpeed = backWheel.motorSpeed;
        if(angleCar>=180)
        {
            angleCar = angleCar - 380;
        }
        angleCar = transform.localEulerAngles.z;
        if (ControlCar[0].cliced == true)
        {
            backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed - (acceleration - gravi * (angleCar / 180) * 80) * Time.deltaTime, maxSpeed, maxSpeedBack);
        }
        if ((ControlCar[0].cliced == false && backWheel.motorSpeed < 0) || 
            (ControlCar[0].cliced == false && backWheel.motorSpeed == 0&&angleCar<0))
        {
            backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed - (deAcceleration - gravi * (angleCar / 180) * 80) * Time.deltaTime, 0, 0);
        }
        else if((ControlCar[0].cliced == false && backWheel.motorSpeed>0)||
            (ControlCar[0].cliced == false && backWheel.motorSpeed == 0&&angleCar>0))
        {
            backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed - (-deAcceleration - gravi * (angleCar / 180) * 80) * Time.deltaTime, 0, maxSpeedBack);
        }
        wheelJoin[0].motor=forontWheel;
        wheelJoin[1].motor = backWheel;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
