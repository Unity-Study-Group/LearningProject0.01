using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class Ability : ScriptableObject {

    public string title = "New Ability";
    public Color iconColor;
	public Sprite sprite;
    public AudioClip sound;
    public float baseCoolDown = 1f;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();
}