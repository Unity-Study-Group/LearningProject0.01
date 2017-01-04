using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLeapTriggerable : MonoBehaviour {
[HideInInspector] public float leapDistance;
[HideInInspector] public float leapSpeed;
[HideInInspector] public GameObject playerShadow;
Vector3 currentShadowSpawn;
Vector3 timeLeapTarget;
PlayerManager player;


public void Cast(PlayerManager player){
	this.player = player;
	timeLeapTarget = transform.position + (transform.forward * leapDistance);
	StartCoroutine(TimeLeap());
}

IEnumerator TimeLeap() 
	{
	player.canMove = false;
	Debug.Log("Time Leap activated!");
	currentShadowSpawn = transform.position + (timeLeapTarget - transform.position) * .2f;
	Instantiate(playerShadow, currentShadowSpawn, transform.rotation);
	yield return new WaitForSecondsRealtime(0.1f * leapSpeed);
	currentShadowSpawn = transform.position + (timeLeapTarget - transform.position) * .4f;
	Instantiate(playerShadow, currentShadowSpawn, transform.rotation);
	yield return new WaitForSecondsRealtime(0.1f * leapSpeed);
	currentShadowSpawn = transform.position + (timeLeapTarget - transform.position) * .6f;
	Instantiate(playerShadow, currentShadowSpawn, transform.rotation);
	yield return new WaitForSecondsRealtime(0.1f * leapSpeed);
	currentShadowSpawn = transform.position + (timeLeapTarget - transform.position) * .8f;
	Instantiate(playerShadow, currentShadowSpawn, transform.rotation);
	yield return new WaitForSecondsRealtime(0.1f * leapSpeed);
	currentShadowSpawn = transform.position + (timeLeapTarget - transform.position) * 1f;
	transform.position = Vector3.Lerp(transform.position, (transform.position + (timeLeapTarget - transform.position) * 1f), 2f);
	player.canMove = true;
	StopCoroutine(TimeLeap());
	yield return null;
	}
}
