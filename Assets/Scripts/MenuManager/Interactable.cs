using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

    [System.Serializable]
    public class Action
        {
        public Color color;
        public Sprite sprite;
        public string title;
        }

    public string title;
    public Action[] options;
    public PlayerController player;

    bool hasOpened = false;



    

    public void  ExecuteInteractable()
        {
        if(hasOpened == false)
            {
            if(Input.GetMouseButtonDown(0))
                {
                player.isActive = false;
                //Debug.LogError("On mouse down function");
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
	void Update ()
        {
        if(Input.GetMouseButtonUp(0))
            {
            player.isActive = true;
            hasOpened = false;
            }
	    }
}
