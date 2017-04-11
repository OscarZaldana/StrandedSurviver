using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[Serializable]
public class CharacterMovesLikeABoss : MonoBehaviour
{
    public Vector3 pos;
    public Rigidbody rig;
	public float speed = 5;
    public float walkSpeed = 5;
	public float sprintSpeed = 15;

 //  public  Animator anim;
	public int currentRawMeat = 0;
	public int currentCookedMeat = 0;
	public int currentMinerals = 0;
	public int currentRawFruit = 0;
	public int currentCookedFruit = 0;
	public int currentSpears = 0;
	public int currentAmmo = 0;

	//public UIManager rawMeat;

	public Stat health;
	public Stat energy;

    public GameObject deathScreen = null;

    public GameObject bulletPrefab = null;

	public GameObject spearPrefab = null;
    public Vector3 vel;

    public GameObject spawnPoint;

    public KeyCode switchWepInput = KeyCode.Tab;

    public BaseStatesOfPlayer baseStates;

    void Start ()
    {
        rig = GetComponent<Rigidbody>();
		speed = speed * Time.deltaTime;
		sprintSpeed = sprintSpeed * Time.deltaTime;
		walkSpeed = walkSpeed * Time.deltaTime;
        baseStates = GetComponent<BaseStatesOfPlayer>();

        // loseText.SetActive(false);

    }

	public void Awake()
	{
		health.Initialize ();
		energy.Initialize ();
		deathScreen.SetActive(false);
	}
	
	void Update ()
    {
        baseStates.weaponStrength = 2;

		rig.velocity = pos * speed;
		vel = rig.velocity;

        if (Input.GetKeyDown(switchWepInput))
        {
            SwitchWeapon();
        }

		if (energy.CurrentVal <= 5) 
		{
			energy.CurrentVal = 4;
			health.CurrentVal -= Time.deltaTime;
		} else
			health.CurrentVal = health.CurrentVal;
			energy.CurrentVal -= Time.deltaTime;

		if (Input.GetKey (KeyCode.LeftShift)) 
		{
			speed = sprintSpeed;
			energy.CurrentVal -= Time.deltaTime * 1.5f;
		} else
			speed = walkSpeed;
			energy.CurrentVal = energy.CurrentVal;



		if (Input.GetButtonDown("Fire1") && currentAmmo > 0 && baseStates.currentWeapon == Weapons.Gun)
        {
            Instantiate(bulletPrefab, spawnPoint.transform.position, transform.rotation);
			currentAmmo -= 1;
        }

		if (Input.GetButtonDown("Fire1") && currentSpears > 0 && baseStates.currentWeapon == Weapons.Spear)
        {
            Instantiate(spearPrefab, spawnPoint.transform.position, transform.rotation);
			currentSpears -= 1;
        }

       //if (Input.GetButtonDown("Fire1") && baseStates.currentWeapon == Weapons.Punch)
       // {
        //    anim.SetTrigger("HandChop");
       // }

        if (Input.GetKey(KeyCode.W))
        {
            pos = gameObject.transform.rotation * Vector3.forward;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            pos = gameObject.transform.rotation * Vector3.left;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            pos = gameObject.transform.rotation * Vector3.back;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            pos = gameObject.transform.rotation * Vector3.right;
        }

        else
        {
            pos = Vector3.zero;
        }
   

		if (Input.GetKeyDown (KeyCode.Alpha1) && currentRawFruit > 0) 
		{
			health.CurrentVal += 5;
			energy.CurrentVal += 5;
			currentRawFruit -= 1;
		}

		if (Input.GetKeyDown (KeyCode.Alpha2) && currentRawMeat > 0) 
		{
			health.CurrentVal += 8;
			energy.CurrentVal += 8;
			currentRawMeat -= 1;
		}

		if (Input.GetKeyDown (KeyCode.Alpha1) && currentCookedFruit > 0) 
		{
			health.CurrentVal += 10;
			energy.CurrentVal += 10;
			currentCookedFruit -= 1;
		}

		if (Input.GetKeyDown (KeyCode.Alpha2) && currentCookedMeat > 0) 
		{
			health.CurrentVal += 15;
			energy.CurrentVal += 15;
			currentCookedMeat -= 1;
		}

		if (health.CurrentVal <=0)
		{
			speed = 0;
			walkSpeed = 0;
			sprintSpeed = 0;
			deathScreen.SetActive (true);
		}

		if (health.CurrentVal >= health.MaxVal) 
		{
			health.CurrentVal = health.MaxVal;
		}
		if (energy.CurrentVal >= energy.MaxVal) 
		{
			energy.CurrentVal = energy.MaxVal;
		}
    }

	public void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name.StartsWith ("Enemy")) 
		{
			health.CurrentVal -= 20;
		}
	}

	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.name.StartsWith ("Meat")) 
		{
			currentRawMeat++;
			Destroy (other.gameObject);
		}

		if (other.gameObject.name.StartsWith ("Fruit")) 
		{
			currentRawFruit += 1;
			Destroy (other.gameObject);
		}

		if (other.gameObject.name.StartsWith ("Minerals")) 
		{
			currentMinerals += 5;
			Destroy (other.gameObject);
		}

		if (other.gameObject.name.StartsWith ("SpearPickup")) 
		{
			currentSpears++;
			Destroy (other.gameObject);
		}
	
	}

    void SwitchWeapon()
    {
        baseStates.wepCounter++;

        if (baseStates.wepCounter >= 3)
        {
            baseStates.wepCounter = 0;
        }

        if (baseStates.wepCounter == 0)
        {
			baseStates.currentWeapon = Weapons.Unarmed;
            baseStates.weaponStrength = 1;
        }

        else if (baseStates.wepCounter == 1)
        {
            baseStates.currentWeapon = Weapons.Spear;
            baseStates.weaponStrength = 4;
        }

        else if (baseStates.wepCounter == 2)
        {
            baseStates.currentWeapon = Weapons.Gun;
            baseStates.weaponStrength = 8;
        }
    }
}
