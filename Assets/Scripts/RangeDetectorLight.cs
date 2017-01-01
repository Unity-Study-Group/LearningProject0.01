using UnityEngine;
using System.Collections;

public class RangeDetectorLight : MonoBehaviour {


    public Light rangeIndicatorLight;
    bool lightOn = false;


    void Awake()
        {
        rangeIndicatorLight = GetComponentInChildren<Light>();
        }

    void OnTriggerStay(Collider col)
        {
        if(col.gameObject.tag == "Player")
            {
            TurnLightOn();
            }
        }
    void OnTriggerExit(Collider col)
        {
        if (col.gameObject.tag == "Player")
            {
            TurnLightOff();
            }
        }

    void TurnLightOn()
        {
        if(lightOn == false)
            {
            rangeIndicatorLight.enabled = true;
            lightOn = true;
            }
        else
            {
            
            }
        }
    void TurnLightOff()
        {
        if (lightOn == true)
            {
            rangeIndicatorLight.enabled = false;
            lightOn = false;
            }
        else
            {

            }
        }
	void Start ()
        {
	
	    }
    void FixedUpdate()
        {

        }
	void Update ()
        {
	
	    }
}
