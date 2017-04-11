using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgriculturePool : MonoBehaviour {
    static int numAgro = 500;
    public GameObject[] agriPrefab;
    static GameObject[] agro;

    // Use this for initialization
    void Start()
    {

        agro = new GameObject[numAgro];
        for (int i = 0; i < numAgro; i++)
        {
            int randomselect = Random.Range(0, agriPrefab.Length);
            agro[i] = (GameObject)Instantiate(agriPrefab[randomselect], Vector3.zero, Quaternion.identity);
            agro[i].SetActive(false);
        }

    }


    static public GameObject getAgri()
    {
        for (int i = 0; i < numAgro; i++)
        {
            if (!agro[i].activeSelf)
            {
                return agro[i];
            }
        }
        return null;
    }
}

