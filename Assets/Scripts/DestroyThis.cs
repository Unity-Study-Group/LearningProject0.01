using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour {
	public float timeUntilDestroy = 1f;
	// Use this for initialization
	void Start () {
		Invoke("DestroyThisObj", timeUntilDestroy);
	}
	
	void DestroyThisObj(){
		Destroy(this.gameObject);
	}
}
