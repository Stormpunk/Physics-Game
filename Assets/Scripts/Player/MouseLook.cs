using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    #region Public Variables
    [Header ("Mouse Lock")] public bool isMouseLockEnabled = true;
    [Header("Camera FOV")] public bool isFieldofViewEnabled = true;
    public float cameraFovMin;
    public float cameraFovMax;
    public float cameraFovIncrement;
    [Header("Camera Rotate X")] public float xRotateMin;
    public float xRotateMax;
    [Header("Mouse Smoothing")] public float mouseSmooth;
    #endregion
    #region Private Variables
    private float m_mouseX;
    private float m_mouseY;
    private float m_rotateX;
    private float m_mouseScroll;
    private Transform m_Parent;
    private float m_fieldOfView;
    private Camera m_camera;
    #endregion
    // Start is called before the first frame update
    private void Awake()
    {
        m_camera = Camera.main;
        m_Parent = transform.parent;
        if (m_camera != null)
        {
            m_fieldOfView = m_camera.fieldOfView;
        }
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MouseInputs();
        RotatePlayerY();
        RotatePlayerX();
    }
    private void MouseInputs()
    {
        #region Collect the Mouse Inputs
        m_mouseX = Input.GetAxis("Mouse X") * mouseSmooth;
        m_mouseY = Input.GetAxis("Mouse Y") * mouseSmooth;
        m_mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        #endregion
    }
    private void RotatePlayerY()
    {
        #region Rotate Player on the Y Axis
        m_Parent.Rotate(Vector3.up * m_mouseX);
        #endregion
    }
    private void RotatePlayerX()
    {
        #region Rotate Player on the X Axis
        m_rotateX += m_mouseY;
        m_rotateX = Mathf.Clamp(m_rotateX, xRotateMin, xRotateMax);
        m_camera.transform.localRotation = Quaternion.Euler(-m_rotateX, 0, 0);
        #endregion
    }
}
