using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorTrigger : MonoBehaviour
{
    public GameObject finalDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            finalDoor.GetComponent<Door>().OpenDoor();
        }
    }
    
}
