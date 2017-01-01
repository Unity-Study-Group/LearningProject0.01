using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform Target;

    float camSmoothing;
    Vector3 camOffset;
    

	void Awake()
        {
        camSmoothing = 5f;
        camOffset = transform.position - Target.position;
        }
    void FixedUpdate()
        {
        Vector3 targetCamPosition = Target.position + camOffset;
        transform.position = Vector3.Lerp(transform.position, targetCamPosition, camSmoothing * Time.deltaTime);
        }
	void Start ()
        {
	
	    }
	
	
	void Update ()
        {
	
	    }
}
