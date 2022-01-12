using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupClass : MonoBehaviour
{
    [SerializeField] private bool canPick;
    [SerializeField] GameObject pickedObject;
    [SerializeField] private Transform Hand;
    [SerializeField] float ThrowingForce;

    private Rigidbody pickedObjectRigidbody;
    private Collider pickedObjectCollider;

    private void Update()
    {
        RaycastHit hitif;
        //Get hit point.
        bool MyCollider = Physics.Raycast(transform.position, transform.forward, out hitif);
        if (MyCollider)//Determine if the ray collides the target.
        {
            //Determine if the target satisfies both "in the
            //ray range of 20" and tag of the target is "Item".
            if (hitif.distance < 20 && hitif.collider.gameObject.tag == "Item")
            {
                canPick = true;
                //If it can be picked, press E on the keyboard, and the target
                //will be assigned the new collier and rigidbody with the raycast.
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickedObjectCollider = hitif.collider;
                    pickedObjectRigidbody = hitif.rigidbody;
                    return;
                }

            }
            else
            {
                canPick = false;
            }
            //Press E on the keyboard to drop the object, which will
            //lose the collier and rigidbody with the raycast.
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //Apply a force.
                pickedObjectRigidbody.AddForce(transform.forward * ThrowingForce, ForceMode.Impulse);
                pickedObjectCollider = null;
                pickedObjectRigidbody = null;
                return;
            }

        }
        if (pickedObjectRigidbody)
        {
            //Pick up the object to the position of "Hand", which is a cube
            //in front of the player. 
            pickedObjectRigidbody.position = Hand.position;
            pickedObjectRigidbody.rotation = Hand.rotation;
        }

    }

    //A text box displays on the screen when the target can be picked.
    private void OnGUI()
    {
        if (canPick)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 70, 70), "Can Pick");
        }

    }

}
