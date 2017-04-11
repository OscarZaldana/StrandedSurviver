using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour 
{

    public BaseStatesOfPlayer baseStates;

    public Text rawMeat;
    public Text cookedMeat;
    public Text minerals;
    public Text bullets;
    public Text currentWeapon;
    public Text spears;
    public Text rawFruit;
	public Text cookedFruit;
    public GameObject materialPanel;
    public bool panelOn;

    public CharacterMovesLikeABoss cb;
	// Use this for initialization
	void Start () 
	{
        cb = FindObjectOfType<CharacterMovesLikeABoss>();
        baseStates = FindObjectOfType<BaseStatesOfPlayer>();
        panelOn = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		bullets.text = "" + cb.currentAmmo;
        rawMeat.text = "" + cb.currentRawMeat;
		cookedMeat.text = "" + cb.currentCookedMeat;
		minerals.text = "" + cb.currentMinerals;
        currentWeapon.text = "" + baseStates.currentWeapon;
		spears.text = "" + cb.currentSpears;
		rawFruit.text = "" + cb.currentRawFruit;
		cookedFruit.text = "" + cb.currentCookedFruit;

        if(panelOn)
        {

            materialPanel.SetActive(true);
        }
        else
        {
            materialPanel.SetActive(false);
        }
	}

    /*public void ChangePanel()
    {
        panelOn = !panelOn;
    }

    /*public void EatRawMeat()
    {
        if(cb.currentRawMeat > 0)
        {
            cb.currentRawMeat -= 1;
            cb.energy.CurrentVal += 10;
            cb.health.CurrentVal -= 5; 
        }
    }

    public void EatMeat()
    {
        if (baseStates.cookedMeat > 0)
        {
            baseStates.cookedMeat -= 1;
            cb.energy.CurrentVal += 15;
            cb.health.CurrentVal += 10;
        }
    }

    public void EatTreeBark()
    {
        if (baseStates.treeBark > 0)
        {
            baseStates.treeBark -= 1;
            cb.energy.CurrentVal += 5;
        }
    }*/

}
