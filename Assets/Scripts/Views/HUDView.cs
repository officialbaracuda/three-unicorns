using UnityEngine;
using UnityEngine.UI;

public class HUDView : MonoBehaviour
{
    [SerializeField]
    private Text levelText;
    [SerializeField]
    private Text zombieText;
    [SerializeField]
    private Text foodText;
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private Text timeLimitText;
    [SerializeField]
    private Text goalText;
    [SerializeField]
    private Text collectedTargetText;

    [SerializeField]
    private GameObject restart;

    public void UpdateHUD(GameData gameData) {
        levelText.text = gameData.level.ToString();
        timeText.text = gameData.time.ToString("F1");
        timeLimitText.text = gameData.timeLimit.ToString("F0");
        goalText.text = gameData.goal.ToString();
        collectedTargetText.text = gameData.collectedTarget.ToString();
        zombieText.text = gameData.zombie.ToString();
        foodText.text = gameData.food.ToString();
    }

    public void GameOver() {
        restart.SetActive(true);
    }
}
