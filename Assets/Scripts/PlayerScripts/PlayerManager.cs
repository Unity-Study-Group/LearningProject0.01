using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerMovement))]
[RequireComponent (typeof (PlayerInteract))]

public class PlayerManager : MonoBehaviour {
	
	[HideInInspector]public bool canMove = true;
	[HideInInspector]public bool canInteract = true;

	private PlayerMovement pMovement;
	private PlayerInteract pInteract;

	void Awake(){
		pMovement = GetComponent<PlayerMovement>();
		pInteract = GetComponent<PlayerInteract>();
	}
	
	void FixedUpdate(){
		if(canMove)
			pMovement.Move();
		if(canInteract)
			pInteract.Interact();
	}
}
