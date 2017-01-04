using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float playerSpeed = 1f;
	public float rotateSpeed = 1f;

	public void Move(){
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f * rotateSpeed;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f * playerSpeed;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
		}
}