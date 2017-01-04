using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnableAction : MonoBehaviour {
	
	public Ability ability;

	void OnTriggerEnter(Collider col){
		if(col.gameObject.layer == LayerMask.NameToLayer ("Player")){
			col.GetComponent<Interactable>().options.Add(ability);
			Debug.Log("You have learned " + ability.title);
			Destroy(this.gameObject);
		}
	}
}
