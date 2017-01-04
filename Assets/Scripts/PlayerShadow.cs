using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour {
	public float despawn = 0.4f;

	void Start(){
		Invoke("DestoyThis",despawn);
	} 

	void DestoyThis(){
		Destroy(this.gameObject);
	}
}
