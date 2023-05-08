using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject[] Templates = new GameObject[10];
    public GameObject Template;
    public GameObject TemplateEmpty;
    public GameObject SpawnTo;
    public int current_index = 0;

    private float lastSpawnTime;
    public float timeBetSpawn = 2f;

    private Vector3 Poolposition = new Vector3(0, 0, -200f);

    private GameObject gameobj;
    private void Awake()
    {
        Create_Platform();
    }

    private void Start()
    {
        /*for(int i = 0; i < Templates.Length; i++)
        {

        }*/
        GameObject Spawned = Instantiate(TemplateEmpty, SpawnTo.transform);
        Spawned.transform.parent = transform;
        SpawnTo.transform.position += new Vector3(0, 0, -20);
        GameObject Spawned1 = Instantiate(TemplateEmpty, SpawnTo.transform);
        Spawned1.transform.parent = transform;
        SpawnTo.transform.position += new Vector3(0, 0, -20);
        GameObject Spawned2 = Instantiate(TemplateEmpty, SpawnTo.transform);
        Spawned2.transform.parent = transform;

        Destroy(Spawned, 15f);
        Destroy(Spawned1, 15f);
        Destroy(Spawned2, 15f);
    }

    private void Update()
    {

        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = 1.9f;
            Templates[current_index].SetActive(false);
            Templates[current_index].SetActive(true);
            GameObject.FindGameObjectWithTag("Item").GetComponent<ItemSpawn>().SelItem();

            Templates[current_index].transform.position = new Vector3(0, 0, -60);

            current_index++;
            if (current_index >= Templates.Length)
            {
                current_index = 0;
            }
        }

    }

    private void Create_Platform()
    {
        for (int i = 0; i < Templates.Length; i++)
        {
            Templates[i] = Instantiate(Template, Poolposition, Quaternion.identity);
            Templates[i].transform.parent = transform;
        }
        lastSpawnTime = 0;
        timeBetSpawn = 0;
    }
}
