using UnityEngine;
using System.Collections;

public class PlayerShadowController : MonoBehaviour {

    public float shadowLife;
    float shadowLifeFrames;
    float currentframes;
	
    void Awake()
        {
        currentframes = 0f;
        shadowLife = .65f;
        shadowLifeFrames = shadowLife / 0.02f;
        //Debug.Log(shadowLifeFrames);
        }
    void FixedUpdate()
        {
        currentframes = currentframes+1f;
        //Debug.Log(currentframes);
        if(currentframes > shadowLifeFrames)
            {
            Destroy(gameObject);
            }
        }
	void Start ()
        {
	
	    }
	
	
	void Update ()
        {
	
	    }

}
