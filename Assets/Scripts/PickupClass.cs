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
        bool MyCollider = Physics.Raycast(transform.position, transform.forward, out hitif);
        if (MyCollider)
        {
            if(hitif. distance<20 && hitif.collider.gameObject.tag == "Item")
            {
                canPick = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickedObjectCollider = hitif.collider;
                    pickedObjectRigidbody = hitif.rigidbody;
                    //pickedObject.transform.position = Hand.position;

                    //pickedObject.isKinematic = true;
                    return;
                }

            }

            else
            {
                canPick = false;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                pickedObjectRigidbody.AddForce(transform.forward * ThrowingForce, ForceMode.Impulse);

                pickedObjectCollider = null;
                pickedObjectRigidbody = null;
                return;
            }
        }

        if (pickedObjectRigidbody)
        {
            pickedObjectRigidbody.position = Hand.position;
            pickedObjectRigidbody.rotation = Hand.rotation;
        }

    }


    private void OnGUI()
    {
        if (canPick)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 60), "Can Pick");
            
        }
    }

   
}
