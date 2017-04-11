using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour {

    public Animator anim;

    public BaseStatesOfPlayer baseStates;

	//public BoxCollider bc;
	//public MeshRenderer mr;

    // Use this for initialization
    void Start () 
	{
        anim = GetComponent<Animator>();
        baseStates = FindObjectOfType<BaseStatesOfPlayer>();

		//bc.enabled = false;
		//mr.enabled = false;
    }
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Fire1") && baseStates.currentWeapon == Weapons.Unarmed)
        {
            anim.SetTrigger("HandChop");
        }

    }
}
