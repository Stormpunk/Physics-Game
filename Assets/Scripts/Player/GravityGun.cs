using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public bool isBoosted = false;
    #region Numbers (Float and Ints)
    public float pullSpeed;
    public float currentPullGauge;
    [SerializeField] float maxDist = 10f, lerpSpeed = 30f, actDist = 20f, minForce = 20f, maxForce = 100f;
    public float throwForce = 20f;
    #endregion
    #region Game Objects
    public Transform hoverPoint;
    public Camera cam;
    Rigidbody grabbedBody;
    public GameObject player;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region Testing Gravity Function
        if (Input.GetKeyDown(KeyCode.I))
        {
            throwForce = maxForce;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            throwForce = minForce;
        }
        #endregion
        #region Gravity Gun System
        if (grabbedBody)
        {
            grabbedBody.MovePosition(Vector3.Lerp(grabbedBody.position, hoverPoint.transform.position, Time.deltaTime * lerpSpeed));
            //if there is a grabbedbody, it follows the hoverpoint.
            //this piece of shit doesn't stay away from the player if I move towards it. I might fix this but it's a non priority rn
            if (Input.GetMouseButtonDown(1))
            {
                grabbedBody.isKinematic = false;
                grabbedBody.AddForce(cam.transform.forward * throwForce, ForceMode.VelocityChange);
                grabbedBody = null;
                //if the RMB is pressed, the rigidbody takes control and detects the collisions, adds force and throws the object forward
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabbedBody && grabbedBody.gameObject.CompareTag("Grabbable"))
            {
                grabbedBody.isKinematic = false;
                grabbedBody = null;
                //if there is a held rigidbody, drop the rigidbody and give control of collisions back to the rigidbody.
            }
            else
            {
                RaycastHit hit;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if (Physics.Raycast(ray, out hit, maxDist))
                {
                    grabbedBody = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (grabbedBody && grabbedBody.gameObject.CompareTag("Grabbable"))
                    {
                        grabbedBody.isKinematic = true;
                    }
                    else
                    {
                        grabbedBody = null;
                    }
                }
                //if the rigidbody is hit by the raycast (with maximum length of maxDist, it is selected as the grabbedBody (and therefore will go to the hoverPoint, duh.)
                //if the hit object is currently in animation + doesn't have a rigidbody on the "base" body it doesn't register activity on the rigidbody. Wasn't a massive issue but I'll look into it in a bit.
                //if the gameobject has tag "grabbable" they become a grabbed body, otherwise they do not (so the player cannot grab random object like a wall. Not entirely sure this isn't complete garbage but what can you do

            }
        }
        #endregion
    }
    public void IncreaseForce(float force)
    {
        if(isBoosted == false)
        {
            throwForce += force;
            isBoosted = true;
        }
        else
        {
            Debug.Log("Already Boosted!");
        }
    }
    public void DecreaseForce()
    {
        if(isBoosted == true)
        {
            throwForce = 20;
            isBoosted = false;
        }
        else
        {
            Debug.Log("Throw Force Already at Minimum!");
        }

    }
}
