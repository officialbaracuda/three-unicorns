using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConfig : MonoBehaviour
{
    [SerializeField]
    private List<Level> levels;

    private Dictionary<int, Level> levelMap;

    void Awake()
    {
        levelMap = new Dictionary<int, Level>();
        foreach (Level level in levels)
        {
            levelMap.Add(level.number, level);
        }
    }

    public Level GetLevel(int num) {
        if (levelMap.ContainsKey(num)) {
            return levelMap[num];
        }
        return null;
    }
}
