using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreation : MonoBehaviour
{
    public int heightScale = 5;
    //public int heightOffset = 100;
    public float detailScale = 5.0f;
    public float baseOffSet;
    List<GameObject> agriculture = new List<GameObject>();
    List<GameObject> beast = new List<GameObject>();
    Vector3 vertices;
    Mesh mesh;

    public GameObject ship;
    public GameObject cookingStation;

    // Use this for initialization

    void Awake()
    {

    }

    void Start ()
    {
        GenerateLevel();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void GenerateLevel()
    {
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        for (int v = 0; v < vertices.Length; v++)
        {
                vertices[v].y = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x) / detailScale,(vertices[v].z + this.transform.position.z) / detailScale) * heightScale;

                if (vertices[v].y < 2.6 && Mathf.PerlinNoise((vertices[v].x + 5) / 10, (vertices[v].z + 5) / 10) * 10 > 4.6)
                {
                    GameObject newAgro = AgriculturePool.getAgri();
                    if (newAgro != null)
                    {
                        Vector3 agroPos = new Vector3(vertices[v].x + this.transform.position.x, vertices[v].y, vertices[v].z + this.transform.position.z);
                        newAgro.transform.position = agroPos;
                        newAgro.SetActive(true);
                        agriculture.Add(newAgro);

                    }
                }


            if (vertices[v].y < 2.6 && Mathf.PerlinNoise((vertices[v].x + 5) / 10, (vertices[v].z + 5) / 10) * 10 > 4.6)
            {
                GameObject newBeast = BeastPool.getBeast();
                if (newBeast != null)
                {
                    Vector3 beastPos = new Vector3(vertices[v].x + this.transform.position.x, vertices[v].y, vertices[v].z + this.transform.position.z);
                    newBeast.transform.position = beastPos;
                    newBeast.SetActive(true);
                    beast.Add(newBeast);

                }
            }

            if (vertices[v].x == 0 && vertices[v].z == 0 && gameObject.transform.position.x == 0 && gameObject.transform.position.z == 0)
            {
                Vector3 shipPos = new Vector3(vertices[v].x + this.transform.position.x, vertices[v].y, vertices[v].z + this.transform.position.z);
                GameObject s = (GameObject)Instantiate(ship, shipPos, Quaternion.identity);
                s.transform.parent = this.transform;
            }
            if (vertices[v].x == -3 && vertices[v].z == 4 && gameObject.transform.position.x == 10 && gameObject.transform.position.z == -10)
            {
                Vector3 cs = new Vector3(vertices[v].x + this.transform.position.x, vertices[v].y, vertices[v].z + this.transform.position.z);
                GameObject c = (GameObject)Instantiate(cookingStation, cs, Quaternion.identity);
                c.transform.parent = this.transform;
            }
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        this.gameObject.AddComponent<MeshCollider>();
    }
    void OnDestroy()
    {
        for (int i = 0; i < agriculture.Count; i++)
        {
            if (agriculture[i] != null)
                agriculture[i].SetActive(false);
        }
        agriculture.Clear();
    }
}
