using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/TimeLeapAbility")]
public class TimeLeapAbility : Ability {

	private PlayerManager player;
	private TimeLeapTriggerable caster;
	public GameObject playerShadow;
	public float leapDistance = 5;
	public float leapSpeed = 1;

	public override void Initialize(GameObject obj){
		player = obj.GetComponent<PlayerManager>();
		caster = obj.GetComponent<TimeLeapTriggerable>();
		caster.playerShadow = this.playerShadow;
		caster.leapDistance = this.leapDistance;
		caster.leapSpeed = this.leapSpeed;
	}

	public override void TriggerAbility(){
		caster.Cast(player);
	}
}
