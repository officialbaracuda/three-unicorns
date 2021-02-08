using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    #region SINGLETON
    public static SpawnController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    public int zombies;
    public int foods;
    public int num;

    public Spawner spawner;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void SpawnTarget()
    {
        spawner.Spawn(Pool.Type.TARGET);
    }

    public void Remove(GameObject go, Pool.Type type)
    {
        spawner.Remove(type, go);
    }

    public void SetSpawnsForLevel(Level level)
    {
        spawner.RemoveZombies();
        StopAllCoroutines();
        foods = 0;
        zombies = 0;

        StartCoroutine(SpawnFood(level));
        StartCoroutine(SpawnZombie(level));
        SpawnTarget();
    }

    IEnumerator SpawnZombie(Level level)
    {
        while (zombies < level.maxZombies && gameManager.IsGameRunning())
        {
            zombies++;
            spawner.Spawn(Pool.Type.ZOMBIE);

            yield return new WaitForSeconds(level.zombieInterval);

        }
    }

    IEnumerator SpawnFood(Level level)
    {
        while (foods < level.maxFoods && gameManager.IsGameRunning())
        {
            foods++;
            spawner.Spawn(Pool.Type.FOOD);
            yield return new WaitForSeconds(level.foodInterval);
        }
    }

    IEnumerator SpawnGhost()
    {
        while (gameManager.IsGameRunning())
        {
            GameObject ghost = spawner.Spawn(Pool.Type.GHOST);
            yield return new WaitForSeconds(2f);
            spawner.Remove(Pool.Type.GHOST, ghost);
        }
    }

    public void StopGhostSpawn()
    {
        StopCoroutine(SpawnGhost());
    }

    public void StartGhostSpawn()
    {
        StartCoroutine(SpawnGhost());
    }
}
