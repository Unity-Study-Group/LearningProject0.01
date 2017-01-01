using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MasterGameManager : MonoBehaviour {


    public static MasterGameManager instance = null;
    public PlayerController player;


    void Awake()
        {
        Singleton();
        }
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
    void Start()
        {

        }
	void Update ()
        {
        Quit();
	    }
    void Quit()
        {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKey(KeyCode.Escape))
            {
            Application.Quit();
            }
        }





}
