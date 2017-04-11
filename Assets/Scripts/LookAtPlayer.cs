using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour 
{
	public GameObject player;
	public Transform playerPos;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("Player");
		playerPos = player.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt (playerPos);
	}
}
