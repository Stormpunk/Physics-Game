using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//why did I name this basketball 
public class BasketBall : MonoBehaviour
{
    public GameObject player;
    public GameObject connectedTrap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Grabbable")
        {
            connectedTrap.GetComponent<SpinofDeath>().isActive = true;
            Destroy(other.gameObject);
        }
    }

}
