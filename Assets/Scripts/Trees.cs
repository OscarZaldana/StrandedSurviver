using UnityEngine;
using System.Collections;

public class Trees : MonoBehaviour
{

	public GameObject spearPickupPrefab = null;
    public int health = 4;

    public BaseStatesOfPlayer bs;

    // Use this for initialization
    void Start () 
	{
        bs = FindObjectOfType<BaseStatesOfPlayer>();
	}

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
			Instantiate (spearPickupPrefab, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.StartsWith("PlayerBullet") || other.gameObject.name.StartsWith("Spear") || other.gameObject.name.StartsWith("Hand"))
        {
            health -= bs.weaponStrength;
        }
    }
}