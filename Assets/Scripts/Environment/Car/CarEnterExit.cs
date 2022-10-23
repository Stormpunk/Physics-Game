using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnterExit : MonoBehaviour
{
    #region Transforms
    public Transform thisCar;
    public Transform leaveArea;
    #endregion
    #region Camera and Player
    public GameObject carCam;
    public GameObject player;
    #endregion
    public MonoBehaviour Car;
    public bool isDriving;
    // Start is called before the first frame update
    void Start()
    {
        Car.enabled = false;
        isDriving = false;
        carCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDriving == true && Input.GetKeyDown(KeyCode.F))
        {
            Leave();
        }

    }
    public void Use()
    {
        player.transform.SetParent(thisCar);
        player.SetActive(false);
        Car.enabled = true;
        isDriving = true;
        carCam.SetActive(true);
    }
    public void Leave()
    {
        player.transform.SetParent(null);
        player.transform.position = leaveArea.position;
        player.SetActive(true);
        Car.enabled = false;
        isDriving = false;
        carCam.SetActive(false);
        Debug.Log("Boop");
        
    }
    
}
