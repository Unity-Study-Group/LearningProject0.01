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






    IEnumerator TimeLeap()
        {
        player.isActive = false;
        Debug.Log("Time Leap activated!");
        player.currentShadowSpawn = transform.position + (player.timeLeapTarget - transform.position) * .2f;
        Instantiate(player.PlayerShadow, player.currentShadowSpawn, transform.rotation);
        yield return new WaitForSecondsRealtime(0.1f);
        player.currentShadowSpawn = transform.position + (player.timeLeapTarget - transform.position) * .4f;
        Instantiate(player.PlayerShadow, player.currentShadowSpawn, transform.rotation);
        yield return new WaitForSecondsRealtime(0.1f);
        player.currentShadowSpawn = transform.position + (player.timeLeapTarget - transform.position) * .6f;
        Instantiate(player.PlayerShadow, player.currentShadowSpawn, transform.rotation);
        yield return new WaitForSecondsRealtime(0.1f);
        player.currentShadowSpawn = transform.position + (player.timeLeapTarget - transform.position) * .8f;
        Instantiate(player.PlayerShadow, player.currentShadowSpawn, transform.rotation);
        yield return new WaitForSecondsRealtime(0.1f);
        player.currentShadowSpawn = transform.position + (player.timeLeapTarget - transform.position) * 1f;
        Instantiate(player.PlayerShadow, player.currentShadowSpawn, transform.rotation);
        transform.position = Vector3.Lerp(transform.position, (transform.position + (player.timeLeapTarget - transform.position) * 1f), 2f);
        player.isActive = true;
        StopCoroutine(TimeLeap());
        yield return null;
        }
}
