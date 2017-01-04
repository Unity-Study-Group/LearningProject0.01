using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
    int floorMask;
    int objectMask;
    int allyMask;
    int shopKeeperMask;
    int enemyMask;
    int playerMask;
	float CamtoFloorRayLength = 1000f;
	Interactable interactable;

	void Awake(){
        floorMask = LayerMask.GetMask("Floor");
        objectMask = LayerMask.GetMask("Object");
        allyMask = LayerMask.GetMask("Ally");
        shopKeeperMask = LayerMask.GetMask("ShopKeeper");
        enemyMask = LayerMask.GetMask("Enemy");
        playerMask = LayerMask.GetMask("Player");
	}

    public void Interact()
        {
        Ray CamToFloorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit objectHit;
        if(Physics.Raycast(CamToFloorRay, out objectHit, CamtoFloorRayLength, enemyMask))
            {
            //Debug.LogError("Found an Enemy");
            }
        else if (Physics.Raycast(CamToFloorRay, out objectHit, CamtoFloorRayLength, objectMask))
            {
            //Debug.LogError("Found an Object");
            interactable = objectHit.transform.gameObject.GetComponent<Interactable>();
            interactable.ExecuteInteractable();
            }
        else if (Physics.Raycast(CamToFloorRay, out objectHit, CamtoFloorRayLength, allyMask))
            {
            //Debug.LogError("Found an Ally");
            interactable = objectHit.transform.gameObject.GetComponent<Interactable>();
            interactable.ExecuteInteractable();
            }
        else if (Physics.Raycast(CamToFloorRay, out objectHit, CamtoFloorRayLength, shopKeeperMask))
            {
            //Debug.LogError("Found a ShopKeeper");
            }
        else if (Physics.Raycast(CamToFloorRay, out objectHit, CamtoFloorRayLength, playerMask))
            {
            //Debug.Log("Found the Player");
            interactable = objectHit.transform.gameObject.GetComponent<Interactable>();
            interactable.ExecuteInteractable();
            }
        else if (Physics.Raycast(CamToFloorRay, out objectHit, CamtoFloorRayLength, floorMask))
            {
            //Debug.Log("Mouse over floor only");
            interactable = objectHit.transform.gameObject.GetComponent<Interactable>();
            interactable.ExecuteInteractable();
            }
    }
}
