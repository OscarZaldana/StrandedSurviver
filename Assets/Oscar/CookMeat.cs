using UnityEngine;
using System.Collections;

public class CookMeat : MonoBehaviour
{


    public BaseStatesOfPlayer baseState;
	public CharacterMovesLikeABoss cb;

	// Use this for initialization
	void Start ()
    {
		cb = FindObjectOfType<CharacterMovesLikeABoss>();
        baseState = GetComponent<BaseStatesOfPlayer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.name == "Stove" && cb.currentRawMeat > 0)
        {
            baseState.canCookMeat = true;
        }

		if(other.gameObject.name == "Stove" && cb.currentRawFruit > 0)
		{
			baseState.canCookFruit = true;
		}

		if (other.gameObject.name == "MineralLab" && cb.currentMinerals > 0)
        {
			baseState.doRockScience = true;
        }
    }

    public void OnTriggerStay (Collider other)
    {
        if(other.gameObject.name == "Stove" && Input.GetKeyDown(KeyCode.E) && baseState.canCookMeat)
        {
			if (cb.currentRawMeat > 0)
            {
				cb.currentRawMeat -= 1;
				cb.currentCookedMeat += 1;
            }

            else
            {
                Debug.Log("No Raw Meat To Cook");
            }
        }

		if(other.gameObject.name == "Stove" && Input.GetKeyDown(KeyCode.E) && baseState.canCookFruit)
		{
			if (cb.currentRawFruit > 0)
			{
				cb.currentRawFruit -= 1;
				cb.currentCookedFruit += 1;
			}

			else
			{
				Debug.Log("No Raw Meat To Cook");
			}
		}

		if (other.gameObject.name == "MineralLab" && Input.GetKeyDown(KeyCode.Q) && baseState.doRockScience)
        {
			if (cb.currentMinerals > 0)
            {
				cb.currentMinerals -= 1;
				cb.currentAmmo += 1;
            }

            else
            {
                Debug.Log("No Minerals");
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Stove")
        {
            baseState.canCookMeat = false;
        }

        if(other.gameObject.name == "Wood")
        {
			baseState.doRockScience = false;
        }
    }
}
