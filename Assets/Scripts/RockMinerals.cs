using UnityEngine;
using System.Collections;

public class RockMinerals : MonoBehaviour {


    public int health = 6;

    public BaseStatesOfPlayer bs;

    // Use this for initialization
    void Start()
    {
        bs = FindObjectOfType<BaseStatesOfPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameObject dest = (GameObject)Instantiate(Resources.Load("Ore"), transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("PlayerBullet") || other.gameObject.name.StartsWith("Spear") || other.gameObject.name.StartsWith("Hand"))
        {
            health -= bs.weaponStrength;
        }
    }
}