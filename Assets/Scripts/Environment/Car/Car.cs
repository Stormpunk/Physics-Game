using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody carBody;
    #region Floats
    private float horizontalInput;
    [SerializeField]private float verticalInput;
    private float curSteerAngle;
    private float curBrakeForce;
    private float brakeForce;
    private bool isBraking;
    [SerializeField] private float motorForce;
    #endregion

    #region Colliders and Such
    [SerializeField] private WheelCollider[] wheelCollider = new WheelCollider[4];
    //front left, front right = [0] [1], back left back right [2] [3]
    [SerializeField] private Transform[] wheelTransform = new Transform[4];
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        motorForce = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheel();
    }
    void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBraking = Input.GetKey(KeyCode.Space);
    }
    void HandleMotor()
    {
        wheelCollider[0].motorTorque = verticalInput * motorForce;
        wheelCollider[1].motorTorque = verticalInput * motorForce;
        curBrakeForce = isBraking ? brakeForce : 0f ;
        ApplyBrake();
    }
    void ApplyBrake()
    {
        foreach (WheelCollider i in wheelCollider)
        {
            i.brakeTorque = curBrakeForce;
        }
    }
    void HandleSteering()
    {

    }
    void UpdateWheel()
    {

    }
}
