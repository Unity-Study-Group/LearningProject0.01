using UnityEngine;
using System.Collections.Generic;

public class Interactable : MonoBehaviour {

    public string title;
    public List<Ability> options;
    public PlayerManager player;

    bool hasOpened = false;

    public void  ExecuteInteractable()
        {
        if(hasOpened == false)
            {
            if(Input.GetMouseButtonDown(0))
                {
                player.canMove = false;
                player.canInteract = false;
                RadialMenuSpawner.ins.SpawnMenu(this);
                hasOpened = true;
                }
            }
        }

	void Start ()
        {
	    if(title == "" || title == null)
            {
            title = gameObject.name;
            }
	    }

	void FixedUpdate ()
        {
        if(Input.GetMouseButtonUp(0))
            {
            player.canMove = true;
            player.canInteract = true;
            hasOpened = false;
            }
	    }
}
