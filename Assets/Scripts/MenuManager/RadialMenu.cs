using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RadialMenu : MonoBehaviour {

    public RadialButton buttonPrefab;
    public Ability selected;

    public delegate void ClickAction(Ability ability);
    public static event ClickAction OnClicked;

	public void SpawnButtons(Interactable obj)
        {
        for (int i = 0; i < obj.options.Count; i++)
            {
            RadialButton newButton = Instantiate(buttonPrefab) as RadialButton;
            newButton.transform.SetParent(transform, false);
            //Debug.LogError("Radial Menu Start Function");
            float theta = (2 * Mathf.PI / obj.options.Count) * i;
            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector3(xPos, yPos, 0f) * 25f;
            newButton.circle.color = obj.options[i].iconColor;
            newButton.Icon.sprite = obj.options[i].sprite;
            newButton.title = obj.options[i].title;
            newButton.ability = obj.options[i];
            newButton.myMenu = this;
            //newButton.transform.localPosition = new Vector3(0f, 25f, 0f);
            }
	    }

	void Update ()
        {
	    if(Input.GetMouseButtonUp(0))
            {
            if(selected)
                {
                if(OnClicked != null)
                    OnClicked(selected);
                }
            Destroy(gameObject);
            }
	    }
}
