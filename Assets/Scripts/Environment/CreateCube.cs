using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    public GameObject cube;
    public Transform dropLocation;
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
        if (other.gameObject.CompareTag("Grabbable"))
        {
            Object.Instantiate(cube, dropLocation.transform);
        }
    }
}
