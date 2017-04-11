using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/*
 * 
 * 
 * 
 * 
 * 
 * 
 *
 * I'm just using this script for reference on how to make some things work. 
 * This won't be part of this project
 *
 *
 *
 *
 *
 *
 *
 */


public class PlayerMovement2D : MonoBehaviour
{
    public GameObject playerWeapon = null;
    public GameObject playerWeaoponBarrell = null;
    public GameObject projectile = null;
    public GameObject tenticalProjectile = null;
	public GameObject bomb = null;
	public GameObject sprintText = null;

	public GameObject bombImage = null;
	public GameObject skull1 = null;
	public GameObject skull2 = null;
	public GameObject skull3 = null;


    private Rigidbody2D playerRigidBody;
    public float movementSpeed = 10.0f;

	public Stat health;
	public Stat shield;

    public float stamina = 0.0f;
    public float staminaCharger = 0.0f;
    public float shieldRechargeTimer = 0.0f;
    public float shieldRechargeTimerReseter = 0.0f;
    public float damageTimer = 0.0f;
    public bool isDead = false;
    public float sprintSpeed = 0;

    public float fireTimer = 1.0f;
    public float angle;
    public float scale = 1.0f;

    public bool stunned = false;
    public float stunTimer = 0.0f;
    public float timeSpentStunned = 0.0f;

    public bool specialAttack = false;
    public bool shieldStatus = false;

    private Animator playerAnimator;
    public AudioClip gunSound;
	public AudioClip[] specialSounds;
	public AudioClip[] hurtSounds;
	public AudioClip[] deathSounds;
	public AudioClip shieldGained;
	public AudioClip shieldLost;
	public AudioClip lossSound;
	public AudioClip holyWaterGained;
	public AudioClip holyWaterAttack;
	public AudioClip specialGained;
	public AudioClip healthPotionGained;
	public AudioClip skullPickup;
	public AudioClip doorUnlocked;

	public float gunVolume = 0.0f;
	public float specialVolume = 0.0f;
	public float hurtVolume = 0.0f;
	public float deathVolume = 0.0f;
	public float lossVolume = 0.0f;
	public float shieldVolume = 0.0f;
	public float holyWaterPickupVolume = 0.0f;
	public float holyWaterAttackVolume = 0.0f;
	public float specialPickupVolume = 0.0f;
	public float healthPotionVolume = 0.0f;
	public float skullVolume = 0.0f;
	public float unlockVolume = 0.0f;

	public int bombs;
	public Text bombCount;

	private void Awake()
	{
		health.Initialize ();
		shield.Initialize ();
		bombImage.SetActive (false);
		skull1.SetActive (false);
		skull2.SetActive (false);
		skull3.SetActive (false);
		sprintText.SetActive (false);
	}

	void SetBombCount ()
	{
		bombCount.text = bombs.ToString ();
	}


    void Start()
    {
        RigidBodyComponent();
        playerAnimator = GetComponent<Animator>();
		bombs = 0;
    }

    public void RigidBodyComponent()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        if (stunned == false && isDead == false)
        {
            PlayerMovement(horizontalMovement, verticalMovement);

            PlayerDirection(horizontalMovement);

            WeaponRotation();
            WeaponFire();
            PlayerAnimator(horizontalMovement, verticalMovement);

            PlayerDamageTimer();

            if (shieldStatus == true)
            {
                PlayerShield();
            }
        }

        if (stunTimer >= 0)
        {
            stunTimer -= Time.deltaTime;
            stunned = true;
        }
        else
        {
            stunned = false;
        }

		if (health.CurrentVal <= 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerMovement(float horizontalMovement, float verticalMovement)
    {
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            staminaCharger = 4.0f;

            if (stamina >= 0)
            {
                stamina -= Time.deltaTime;
            }
            movementSpeed = sprintSpeed;
        }
        else
        {
            movementSpeed = 2.5f;
        }

        if (staminaCharger <= 0 && stamina <= 4.0f)
        {
            stamina += Time.deltaTime;
        }

        if (stamina >= 4.0f)
        {
            stamina = 4.0f;
        }

        if (staminaCharger > 0)
        {
            staminaCharger -= Time.deltaTime;
        }
        
        playerRigidBody.velocity = new Vector2(horizontalMovement * movementSpeed, verticalMovement * movementSpeed);
    }

    public void PlayerDirection(float horizontalMovement)
    {
        if (gameObject.transform.eulerAngles.z < 180.0f)
        {
            gameObject.transform.localScale = new Vector3(-scale, scale, scale);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    public void WeaponFire()
    {
        if (fireTimer <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                fireTimer = 0.15f;
                if (-90.0f <= angle && angle < 90.0f)
                {
                    Instantiate(projectile, playerWeaoponBarrell.transform.position, Quaternion.Euler(playerWeaoponBarrell.transform.eulerAngles.x, playerWeaoponBarrell.transform.eulerAngles.y, -playerWeaoponBarrell.transform.eulerAngles.z));
                }
                else
                {
                    Instantiate(projectile, playerWeaoponBarrell.transform.position, Quaternion.Euler(playerWeaoponBarrell.transform.eulerAngles.x, playerWeaoponBarrell.transform.eulerAngles.y, playerWeaoponBarrell.transform.eulerAngles.z));
                }

                this.gameObject.AddComponent<AudioSource>();
				this.GetComponent<AudioSource>().clip = gunSound;
                this.GetComponent<AudioSource>().Play();
				this.GetComponent<AudioSource>().volume = gunVolume;
            }
        }

        if (specialAttack == true)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                if (-90.0f <= angle && angle < 90.0f)
                {
                    Instantiate(tenticalProjectile, playerWeaoponBarrell.transform.position, Quaternion.Euler(playerWeaoponBarrell.transform.eulerAngles.x, playerWeaoponBarrell.transform.eulerAngles.y, -playerWeaoponBarrell.transform.eulerAngles.z));
                }
                else
                {
                    Instantiate(tenticalProjectile, playerWeaoponBarrell.transform.position, Quaternion.Euler(playerWeaoponBarrell.transform.eulerAngles.x, playerWeaoponBarrell.transform.eulerAngles.y, playerWeaoponBarrell.transform.eulerAngles.z));
                }
			
				this.gameObject.AddComponent<AudioSource>();
				this.GetComponent<AudioSource>().clip = specialSounds [UnityEngine.Random.Range (0, specialSounds.Length)];
				this.GetComponent<AudioSource>().Play();
				this.GetComponent<AudioSource>().volume = specialVolume;

                specialAttack = false;
            }
        }
        
        if (fireTimer >= 0.0f)
        {
            fireTimer -= Time.deltaTime;
        }
    }

    public void WeaponRotation()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0.0f;

        Vector3 weaponPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition.x = mousePosition.x - weaponPosition.x;
        mousePosition.y = mousePosition.y - weaponPosition.y;

        angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        Debug.Log(angle);

        if (-90.0f <= angle && angle < 90.0f)
        {
            gameObject.transform.localScale = new Vector3(-scale, scale, scale);
            playerWeapon.transform.eulerAngles = new Vector3(0.0f, 0.0f, -angle + 90.0f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(scale, scale, scale);
            playerWeapon.transform.eulerAngles = new Vector3(0.0f, 0.0f, angle - 90.0f);
        }
    }

    void PlayerDamageTimer()
    {
        if (damageTimer >= 0.0f)
        {
            damageTimer -= Time.deltaTime;
        }
        if (damageTimer <= 0.0f)
        {
            damageTimer = 0.0f;
        }
    }

    void PlayerShield()
    {
        if (shieldRechargeTimer >= 0)
        {
            shieldRechargeTimer -= Time.deltaTime;
        }

		if (shieldRechargeTimer <= 0 && shield.CurrentVal < 4.0f)
        {
            shieldRechargeTimer = 0.0f;
			shield.CurrentVal += Time.deltaTime;
        }

		if (shield.CurrentVal > 4.0f)
        {
			shield.CurrentVal = 4.0f;
        }

        if (shieldRechargeTimer < 0)
        {
            shieldRechargeTimer = 0.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && damageTimer == 0.0f)
        {
            damageTimer = 0.6f;
			if (shield.CurrentVal > 0)
            {
				shield.CurrentVal -= 1;
                shieldRechargeTimer = shieldRechargeTimerReseter;
            }
            else
            {
				health.CurrentVal -= 1;
                shieldRechargeTimer = shieldRechargeTimerReseter;
				AudioSource.PlayClipAtPoint (hurtSounds [UnityEngine.Random.Range (0, hurtSounds.Length)], transform.position, hurtVolume);
            }
        }

        if (other.gameObject.tag == "EnemyProjectile" && damageTimer == 0.0f)
        {
            damageTimer = 0.6f;
			if (shield.CurrentVal > 0)
            {
				shield.CurrentVal -= 1;
                shieldRechargeTimer = shieldRechargeTimerReseter;
            }
            else
            {
				health.CurrentVal -= 1;
                shieldRechargeTimer = shieldRechargeTimerReseter;
				AudioSource.PlayClipAtPoint (hurtSounds [UnityEngine.Random.Range (0, hurtSounds.Length)], transform.position, hurtVolume);
            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "EnemyEyeBall" && damageTimer == 0.0f)
        {
            damageTimer = 0.6f;
			if (shield.CurrentVal > 0)
            {
				shield.CurrentVal -= 1;
                shieldRechargeTimer = shieldRechargeTimerReseter;
            }
            else
            {
				health.CurrentVal -= 1;
                shieldRechargeTimer = shieldRechargeTimerReseter;
				AudioSource.PlayClipAtPoint (hurtSounds [UnityEngine.Random.Range (0, hurtSounds.Length)], transform.position, hurtVolume);
            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "GiantEyeball" && damageTimer == 0.0f)
        {
            damageTimer = 0.6f;
			if (shield.CurrentVal > 0)
            {
				shield.CurrentVal -= 1;
                shieldRechargeTimer = shieldRechargeTimerReseter;
            }
            else
            {
				health.CurrentVal -= 1;
                shieldRechargeTimer = shieldRechargeTimerReseter;
				AudioSource.PlayClipAtPoint (hurtSounds [UnityEngine.Random.Range (0, hurtSounds.Length)], transform.position, hurtVolume);
            }
        }

        if (other.gameObject.tag == "BabySpider" && damageTimer == 0.0f)
        {
            damageTimer = 0.6f;
			if (shield.CurrentVal > 0)
            {
				shield.CurrentVal -= 1;
                shieldRechargeTimer = shieldRechargeTimerReseter;
            }
            else
            {
				health.CurrentVal -= 1;
                shieldRechargeTimer = shieldRechargeTimerReseter;
				AudioSource.PlayClipAtPoint (hurtSounds [UnityEngine.Random.Range (0, hurtSounds.Length)], transform.position, hurtVolume);
            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "SpiderWeb" && damageTimer == 0.0f)
        {
            damageTimer = 0.6f;
            stunTimer = timeSpentStunned;
        }

        if (other.gameObject.tag == "HealthPotion")
        {
			if (health.CurrentVal < 5 && health.CurrentVal >= 0)
            {
				health.CurrentVal += 1;
				AudioSource.PlayClipAtPoint (healthPotionGained, transform.position, healthPotionVolume);
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.tag == "HollyWater")
        {
			AudioSource.PlayClipAtPoint (holyWaterGained, transform.position, holyWaterPickupVolume);
			bombImage.SetActive(true);
			bombs = bombs + 1;
			SetBombCount();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "ShieldGem")
        {
            shieldStatus = true;
			AudioSource.PlayClipAtPoint (shieldGained, transform.position, shieldVolume);
            Destroy(other.gameObject);
        }

		if (other.gameObject.tag == "SprintGem")
		{
			//shieldStatus = true;
			AudioSource.PlayClipAtPoint (shieldGained, transform.position, shieldVolume);
			sprintText.SetActive (true);
			Destroy(other.gameObject);
		}

		if (other.gameObject.tag == "Skull1")
		{
			AudioSource.PlayClipAtPoint (skullPickup, transform.position, skullVolume);
			skull1.SetActive (true);
			Destroy(other.gameObject);
		}

		if (other.gameObject.tag == "Skull2")
		{
			AudioSource.PlayClipAtPoint (skullPickup, transform.position, skullVolume);
			skull2.SetActive (true);
			Destroy(other.gameObject);
		} 

		if (other.gameObject.tag == "Skull3")
		{
			AudioSource.PlayClipAtPoint (skullPickup, transform.position, skullVolume);
			skull3.SetActive (true);
			Destroy(other.gameObject);
		}
    }

    void PlayerAnimator(float horizontalMovement, float verticalMovement)
    {
        if (Mathf.Abs(horizontalMovement) > 0 || Mathf.Abs(verticalMovement) > 0)
        {
            playerAnimator.SetBool("PlayerWalking", true);
            playerAnimator.SetBool("PlayerIdle", false);
        }
        else
        {
            playerAnimator.SetBool("PlayerWalking", false);
            playerAnimator.SetBool("PlayerIdle", true);
        }
    }

    void PlayerDeath()
    {
        isDead = true;
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        playerAnimator.SetBool("PlayerWalking", false);
        playerAnimator.SetBool("PlayerIdle", false);
        playerAnimator.SetTrigger("PlayerDeath");
        Destroy(playerWeapon);
		health.CurrentVal = 10;

		AudioSource.PlayClipAtPoint (deathSounds [UnityEngine.Random.Range (0, deathSounds.Length)], transform.position, deathVolume);
		this.gameObject.AddComponent<AudioSource>();
		this.GetComponent<AudioSource> ().clip = lossSound;
		this.GetComponent<AudioSource>().Play();
		this.GetComponent<AudioSource>().volume = lossVolume;
		StartCoroutine (Die());
    }


	public IEnumerator Die()
	{
		yield return new WaitForSeconds (5);
		Application.LoadLevel ("Menu Screen");
	}
}
