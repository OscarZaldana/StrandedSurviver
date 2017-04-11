using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour 

{

	bool isSpawning = false;

	//public float minStartTime = 0.1f;
	//public float maxStartTime = 0.2f;

	public float minTime = 2.0f;
	public float maxTime = 15.0f;

    public int randomSpawnRangeX;
	public int randomSpawnRangeZ;

    public Vector3 randomRangeSpwan;

    public DayAndNight nightTime;

    public void Start()
    {
        nightTime = FindObjectOfType<DayAndNight>();
    }

	//Was working on a range for spawning area. Not sure what to do, could do an Array for this as well?
	/*public float MinX = -200;
	public float MaxX = 200;
	public float MinZ = -200;
	public float MaxZ = 200;*/

	//An Array to pick spawnable Enemies and/or Resources.
	//public GameObject[] environmentObjects;
	public GameObject[] spawnables; 


	IEnumerator SpawnObject(int index, float seconds)
	{
		Debug.Log ("Waiting for " + seconds + " seconds");

		yield return new WaitForSeconds(seconds);
		Instantiate (spawnables[index], randomRangeSpwan, transform.rotation);
		isSpawning = false;
	}

	/*IEnumerator SpawnEnvironment (int index, float seconds)
	{
		Instantiate (environmentObjects[index], randomRangeSpwan, transform.rotation);
		isSpawning = false;
		yield break;
	}*/

	void Update ()
	{
		if (! isSpawning) 
		{
			randomSpawnRangeX = Random.Range(-350, 350);
			randomSpawnRangeZ = Random.Range(-350, 350);

            randomRangeSpwan = new Vector3(randomSpawnRangeX, 0.002f, randomSpawnRangeZ);

            isSpawning = true;

			int spawnIndex = Random.Range(0, spawnables.Length);

			//int environmentIndex = Random.Range (0, environmentObjects.Length);

			StartCoroutine(SpawnObject(spawnIndex, Random.Range(minTime, maxTime)));
			//StartCoroutine(SpawnEnvironment(environmentIndex, Random.Range(minStartTime, maxStartTime)));

            if (nightTime.am == false && maxTime > 4)
            {
                maxTime = 4;
            }
            else if(nightTime.am)
            {
                maxTime = 15;
            }
        }
     
	}
		
	/*void SpawnableInstantiate() 
	{
		float x = Random.Range(MinX,MaxX);
		float z = Random.Range(MinZ,MaxZ);

		Instantiate (spawnables, new Vector3(x, 0.5, z), Quaternion.identity);
	}*/
}