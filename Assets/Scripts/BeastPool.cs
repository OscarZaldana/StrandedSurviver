using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastPool : MonoBehaviour {

    static int numBeast = 10;
    public GameObject[] beastPrefab;
    static GameObject[] beast;

    // Use this for initialization
    void Start()
    {

        beast = new GameObject[numBeast];
        for (int i = 0; i < numBeast; i++)
        {
            int randomselect = Random.Range(0, beastPrefab.Length);
            beast[i] = (GameObject)Instantiate(beastPrefab[randomselect], Vector3.zero, Quaternion.identity);
            beast[i].SetActive(false);
        }

    }


    static public GameObject getBeast()
    {
        for (int i = 0; i < numBeast; i++)
        {
            if (!beast[i].activeSelf)
            {
                return beast[i];
            }
        }
        return null;
    }
}
