using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnImpact : MonoBehaviour {
	public GameObject onImpactFX;
	
	void OnCollisionEnter(Collision col){
		Instantiate(onImpactFX, transform.position, Quaternion.identity);
		Destroy(this.gameObject);
	}

}
