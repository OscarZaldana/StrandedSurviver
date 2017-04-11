using UnityEngine;
using System.Collections;

public class MineralLab : MonoBehaviour 
{
	/*

	public BaseStatesOfPlayer baseState;
	public CharacterMovesLikeABoss cb;

	// Use this for initialization
	void Start ()
	{
		cb = GetComponent<CharacterMovesLikeABoss>();
		baseState = GetComponent<BaseStatesOfPlayer>();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "MineralLab" cb.currentMinerals> 0)
		{
			baseState.doRockScience = true;
		}
	}

	public void OnTriggerStay (Collider other)
	{
		if(other.gameObject.name == "MineralLab" && Input.GetKeyDown(KeyCode.E) && baseState.doRockScience)
		{
			if (baseState.oreHeld > 0)
			{
				baseState.oreHeld -=1;
				baseState.bulletsHeld +=1;
			}

			else
			{
				Debug.Log("No Ore is held To Craft Into Bullets");
			}
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "MineralLab")
		{
			baseState.doRockScience = false;
		}
	}*/
}