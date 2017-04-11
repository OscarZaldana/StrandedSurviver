using UnityEngine;
using System.Collections;

public enum Weapons { Unarmed, Gun, Spear}

public class BaseStatesOfPlayer : MonoBehaviour
{
    public int wepCounter;

    public int weaponStrength;

    public Weapons currentWeapon;

    public bool canCookMeat;

	public bool canCookFruit;

	public bool doRockScience;
}
