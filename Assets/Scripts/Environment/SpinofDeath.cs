using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinofDeath : MonoBehaviour
{
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive == true)
        {
            transform.Rotate(0f, 1f, 0f, Space.Self);
        }
    }
}
