using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Vector3 playerMovement;
    Rigidbody playerRB;
    int floorMask;
    int objectMask;
    int allyMask;
    int shopKeeperMask;
    int enemyMask;
    int playerMask;
    float CamtoFloorRayLength = 1000f;
    float timeLeapLength = 100f;  
    public Vector3 timeLeapTarget;
    public Vector3 currentShadowSpawn;



    public bool isActive = true;
    public Interactable interactable;
    public float playerSpeed;
    public float playerTurnSpeed;
    public float speedConstant;
    public GameObject PlayerShadow;


	void Awake()
        {
        floorMask = LayerMask.GetMask("Floor");
        objectMask = LayerMask.GetMask("Object");
        allyMask = LayerMask.GetMask("Ally");
        shopKeeperMask = LayerMask.GetMask("ShopKeeper");
        enemyMask = LayerMask.GetMask("Enemy");
        playerRB = GetComponent<Rigidbody>();
        playerMask = LayerMask.GetMask("Player");
        }
	void Start ()
        {
        playerSpeed = 10f;
        speedConstant = 2f;
        playerTurnSpeed = 10f;
	    }
	void Update ()
        {
	
	    }
    void FixedUpdate()
        {
        if(Input.GetKey(KeyCode.LeftShift))
            {
            playerSpeed = 15f;
            }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
            {
            playerSpeed = 10f;
            }
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if(isActive)
            {
            Move(h, v);
            Turn();
            Interaction();
            }

    }
    void Move(float h, float v)
        {
        playerMovement.Set(h, 0f, v);
        playerMovement = playerMovement.normalized * playerSpeed * Time.deltaTime * speedConstant;
        playerRB.MovePosition(transform.position + playerMovement);
        }
    void Turn()
        {
        Ray CamtoFloorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(CamtoFloorRay, out floorHit, CamtoFloorRayLength, floorMask))
            {
            timeLeapTarget = floorHit.point;
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRoatation = Quaternion.LookRotation(playerToMouse);
            playerRB.rotation = Quaternion.Lerp(transform.rotation, newRoatation, Time.deltaTime * speedConstant * playerTurnSpeed);
            }
        }


    IEnumerator PoisonShot()
        {
        Debug.LogError("PoisonShot Activated");
        yield return null;
        }
    IEnumerator PinPointBolt()
        {
        Debug.LogError("PinPointBolt Activated");
        yield return null;
        }
    IEnumerator AreaBolt()
        {
        Debug.LogError("AreaBolt Activated");
        yield return null;
        }
    IEnumerator MagicBeam()
        {
        Debug.LogError("MagicBeam Activated");
        yield return null;
        }
    void Interaction()
        {
        Ray CamToFloorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit objectHit;
        if(Physics.Raycast(CamToFloorRay, out objectHit, CamtoFloorRayLength, enemyMask))
            {
            //Debug.LogError("Found an Enemy");
            }
        else if (Physics.Raycast(CamToFloorRay, out objectHit, CamtoFloorRayLength, objectMask))
            {
            //Debug.LogError("Found an Object");
            interactable = objectHit.transform.gameObject.GetComponent<Interactable>();
            interactable.ExecuteInteractable();
            }
        else if (Physics.Raycast(CamToFloorRay, out objectHit, CamtoFloorRayLength, allyMask))
            {
            //Debug.LogError("Found an Ally");
            interactable = objectHit.transform.gameObject.GetComponent<Interactable>();
            interactable.ExecuteInteractable();
            }
        else if (Physics.Raycast(CamToFloorRay, out objectHit, CamtoFloorRayLength, shopKeeperMask))
            {
            //Debug.LogError("Found a ShopKeeper");
            }
        else if (Physics.Raycast(CamToFloorRay, out objectHit, CamtoFloorRayLength, playerMask))
            {
            //Debug.Log("Found the Player");
            interactable = objectHit.transform.gameObject.GetComponent<Interactable>();
            interactable.ExecuteInteractable();
            }
        else if (Physics.Raycast(CamToFloorRay, out objectHit, CamtoFloorRayLength, floorMask))
            {
            //Debug.Log("Mouse over floor only");
            interactable = objectHit.transform.gameObject.GetComponent<Interactable>();
            interactable.ExecuteInteractable();
            }
    }


}
