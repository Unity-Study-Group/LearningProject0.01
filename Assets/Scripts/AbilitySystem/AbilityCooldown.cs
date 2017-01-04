using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour {

    public string abilityButtonAxisName = "Fire1";
    public Image darkMask;
    public Text coolDownTextDisplay;

    [SerializeField] private Ability ability;
    [SerializeField] private GameObject weaponHolder;
    private Image myButtonImage;
    private AudioSource abilitySource;
    private float coolDownDuration;
    private float nextReadyTime;
    private float coolDownTimeLeft;
    
    void Start(){
        RadialMenu.OnClicked += OnAbilitySelect;
        Initialize (ability, weaponHolder); 
    }

    void OnAbilitySelect(Ability selected) 
    {
        ability = selected;
        Initialize (ability, weaponHolder); 
    }

    public void Initialize(Ability selectedAbility, GameObject weaponHolder)
    {
        ability = selectedAbility;
        myButtonImage = GetComponent<Image> ();
        myButtonImage.enabled = true;
        abilitySource = GetComponent<AudioSource> ();
        myButtonImage.sprite = ability.sprite;
        darkMask.sprite = ability.sprite;
        coolDownDuration = ability.baseCoolDown;
        ability.Initialize (weaponHolder);
        AbilityReady ();
    }
    
    // Update is called once per frame
    void FixedUpdate () 
    {
        bool coolDownComplete = (Time.time > nextReadyTime);
        if (coolDownComplete) 
        {
            AbilityReady ();
            if (Input.GetButtonDown (abilityButtonAxisName)) 
            {
                ButtonTriggered ();
            }
        } else 
        {
            CoolDown();
        }
    }

    private void AbilityReady()
    {
        coolDownTextDisplay.enabled = false;
        darkMask.enabled = false;
    }

    private void CoolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCd = Mathf.Round (coolDownTimeLeft);
        coolDownTextDisplay.text = roundedCd.ToString ();
        darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);
    }

    private void ButtonTriggered()
    {
        nextReadyTime = coolDownDuration + Time.time;
        coolDownTimeLeft = coolDownDuration;
        darkMask.enabled = true;
        coolDownTextDisplay.enabled = true;

        if(abilitySource){
        abilitySource.clip = ability.sound;
        abilitySource.Play ();
        }

        ability.TriggerAbility ();
    }
}