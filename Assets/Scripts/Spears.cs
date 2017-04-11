using UnityEngine;
using System.Collections;

public class Spears : MonoBehaviour
{
	public float speed = 0.0f;
	public Vector3 vec;
	public Rigidbody rig;

	//public CharacterMovesLikeABoss val;

	// Use this for initialization
	void Start () 
	{
		speed = speed * Time.deltaTime;
		rig = GetComponent<Rigidbody> ();
		//val = FindObjectOfType<CharacterMovesLikeABoss>();
	}

	// Update is called once per frame
	void Update () 
	{
		vec = gameObject.transform.rotation * Vector3.forward;
		rig.velocity = vec * speed;
		Destroy (gameObject, 3);
	}

	public void OnCollisionEnter(Collision other)
	{
		/*if (other.gameObject.name.StartsWith("Enemy"))
		{
			Destroy(gameObject);
		}*/

		if (other.gameObject.name.StartsWith("Level"))
		{
			Destroy(gameObject);
		}
	}
	/*public Animator anim;

	public BaseStatesOfPlayer baseStates;

	public BoxCollider bc;
	public MeshRenderer mr;
	public CharacterMovesLikeABoss cb;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		baseStates = FindObjectOfType<BaseStatesOfPlayer>();
		cb = FindObjectOfType<CharacterMovesLikeABoss>();

		bc.enabled = false;
		mr.enabled = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Fire1") && baseStates.currentWeapon == Weapons.Spear)
		{
			anim.SetTrigger("SpearStab");
			cb.currentSpears -= 1;
		}
	}*/
}
