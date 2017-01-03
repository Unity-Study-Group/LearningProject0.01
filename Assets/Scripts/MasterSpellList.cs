using UnityEngine;
using System.Collections;

public class MasterSpellList : MonoBehaviour {

    public static MasterSpellList instance = null;
    public PlayerController player;

    void Singleton()
        {
        if (instance == null)
            {
            instance = this;
            }
        else if (instance != this)
            {
            Destroy(gameObject);
            }

        DontDestroyOnLoad(gameObject);
        }
    void Awake()
        {
        Singleton();
        }
    void Start ()
        {
	
	    }
	void Update ()
        {
	
	    }

    public void UseActiveSpell()
        {
        StartCoroutine(TimeLeap());
        }




    IEnumerator TimeLeap()
        {
        player.isActive = false;
        Debug.Log("Time Leap activated!");
        player.currentShadowSpawn = player.transform.position + (player.timeLeapTarget - player.transform.position) * .2f;
        Instantiate(player.PlayerShadow, player.currentShadowSpawn, player.transform.rotation);
        yield return new WaitForSecondsRealtime(0.1f);
        player.currentShadowSpawn = player.transform.position + (player.timeLeapTarget - player.transform.position) * .4f;
        Instantiate(player.PlayerShadow, player.currentShadowSpawn, player.transform.rotation);
        yield return new WaitForSecondsRealtime(0.1f);
        player.currentShadowSpawn = player.transform.position + (player.timeLeapTarget - player.transform.position) * .6f;
        Instantiate(player.PlayerShadow, player.currentShadowSpawn, player.transform.rotation);
        yield return new WaitForSecondsRealtime(0.1f);
        player.currentShadowSpawn = player.transform.position + (player.timeLeapTarget - player.transform.position) * .8f;
        Instantiate(player.PlayerShadow, player.currentShadowSpawn, player.transform.rotation);
        yield return new WaitForSecondsRealtime(0.1f);
        player.currentShadowSpawn = player.transform.position + (player.timeLeapTarget - player.transform.position) * 1f;
        Instantiate(player.PlayerShadow, player.currentShadowSpawn, player.transform.rotation);
        player.transform.position = Vector3.Lerp(player.transform.position, (player.transform.position + (player.timeLeapTarget - player.transform.position) * 1f), 2f);
        player.isActive = true;
        StopCoroutine(TimeLeap());
        yield return null;
        }
}
