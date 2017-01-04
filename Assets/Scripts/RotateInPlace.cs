using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInPlace : MonoBehaviour {

	void FixedUpdate(){
		this.transform.Rotate(1,0,1);
	}
}
