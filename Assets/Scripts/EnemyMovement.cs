using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	public GameObject player;
	public Transform playerPos;

	public int health = 5; 
	public float speed = 0.0f;
	//public bool active = false;

	public GameObject meatPrefab = null;

	public BaseStatesOfPlayer bs;

    // Use this for initialization
    void Start () 
	{
		bs = FindObjectOfType<BaseStatesOfPlayer>();
		player = GameObject.Find ("Player");
		playerPos = player.transform;
        bs = FindObjectOfType<BaseStatesOfPlayer>();
    }


    public void Update()
    {
		//transform.LookAt (playerPos);
		if (health <= 0)
		{
			Instantiate(meatPrefab, gameObject.transform.position, gameObject.transform.rotation);
			Destroy(gameObject);
		}
		Follow ();
    }

	// Update is called once per frame
	void Follow () 
	{
		if (player) 
		{
			transform.position = Vector3.MoveTowards (transform.position, playerPos.position, speed * Time.deltaTime);
		}
	}

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.StartsWith("PlayerBullet"))
        {
			health -= 8;
			Destroy (other.gameObject);
        }
		if(other.gameObject.name == "Hand")
		{
			health -= 3;
		}

		if(other.gameObject.name.StartsWith ("SpearPrefab"))
		{
			health -= 6;
		}

		/*if (other.gameObject.name.StartsWith ("PlayerTool"))
		{
			health --;
		}*/

    }
}
