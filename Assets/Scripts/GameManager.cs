using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region SINGLETON
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    private SpawnController spawnController;
    [SerializeField]
    private GameData gameData;
    private Level currentLevel;

    private bool isGameRunning;

    public LevelConfig levelConfig;
    public HUDView hud;

    void Start()
    {
        spawnController = SpawnController.Instance;
        StartGame();
    }

    void Update()
    {
        if (isGameRunning) {
            hud.UpdateHUD(gameData);
            gameData.time += Time.deltaTime;
            if (gameData.time > gameData.timeLimit) {
                GameOver();
            }
        }
    }

    void ResetGame() {
        currentLevel = levelConfig.GetLevel(1);
        gameData = new GameData(currentLevel);
        isGameRunning = false;
    }

    void StartGame() {
        ResetGame();
        isGameRunning = true;
        spawnController.SetSpawnsForLevel(currentLevel);
    }

    public void Pickup(Pickable pickable) {
        if (pickable.type == Pool.Type.TARGET) {
            gameData.collectedTarget++;
            if (gameData.collectedTarget == gameData.goal)
            {
                NextLevel();
            }
            else {
                spawnController.SpawnTarget();
            }
        } else if(pickable.type == Pool.Type.FOOD){
            gameData.timeLimit += pickable.value;
        }
    }

    public void NextLevel() {
        gameData.level++;
        currentLevel = levelConfig.GetLevel(gameData.level);
        if (currentLevel == null)
        {
            GameOver();
        }
        spawnController.SetSpawnsForLevel(currentLevel);
        gameData = new GameData(currentLevel);
        isGameRunning = true;
    }

    public void GameOver() {
        isGameRunning = false;
        hud.GameOver();
    }

    public bool IsGameRunning() {
        return isGameRunning;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
