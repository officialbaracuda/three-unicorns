
using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private List<Pool> pools;

    private Dictionary<Pool.Type, Queue<GameObject>> dictionary = new Dictionary<Pool.Type, Queue<GameObject>>();
    private int spawnRadius = 1;

    private void Awake()
    {
        foreach (Pool pool in pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                int index = UnityEngine.Random.Range(0, pool.objects.Length);
                GameObject obj = Instantiate(pool.objects[index]);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }
            dictionary.Add(pool.tag, queue);
        }
    }

    public GameObject Spawn(Pool.Type tag)
    {
        if (!isPoolEmpty(tag))
        {
            Vector2 circle = UnityEngine.Random.insideUnitCircle * spawnRadius;
            Vector3 pos = new Vector3(transform.position.x + circle.x, 1, transform.position.z + circle.y);
            int spawnPoint = UnityEngine.Random.Range(0, spawnPoints.Length);

            GameObject obj = dictionary[tag].Dequeue();

            obj.SetActive(true);
            obj.transform.position = pos + spawnPoints[spawnPoint].position;
            
            return obj;
        }
        return null;
    }

    public void Remove(Pool.Type tag, GameObject obj)
    {
        obj.SetActive(false);
        dictionary[tag].Enqueue(obj);
        Debug.Log(tag + " is added to the pool with obj: " + obj.name);
    }

    public void RemoveZombies() {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag(Constants.ZOMBIE);
        foreach (GameObject go in zombies) {
            if (go.activeInHierarchy) {
                Remove(Pool.Type.ZOMBIE, go);
            }
        }
    }

    private bool isPoolEmpty(Pool.Type tag)
    {
        return dictionary[tag].Count <= 0;
    }
}
