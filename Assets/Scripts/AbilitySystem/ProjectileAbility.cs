using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Abilities/ProjectileAbility")]
public class ProjectileAbility : Ability {

    public DamageType damageType;
    public TargetType targetType;
    public float projectileForce = 500f;
    public Rigidbody projectile;
    public GameObject onImpactFX;

    private ProjectileShootTriggerable launcher;

    public override void Initialize(GameObject obj)
    {
        launcher = obj.GetComponent<ProjectileShootTriggerable> ();
        launcher.projectileForce = projectileForce;
        ExplodeOnImpact Explode = projectile.gameObject.GetComponent<ExplodeOnImpact>();
        Explode.onImpactFX = this.onImpactFX;
        launcher.projectile = projectile;
    }

    public override void TriggerAbility()
    {
        launcher.Launch ();
    }
}