using System;

[Serializable]
public class GameData
{
    public int level;
    public int goal;
    public int collectedTarget;
    public float time;
    public float timeLimit;
    public int food;
    public int zombie;

    public GameData(Level currentLevel) {
        level = currentLevel.number;
        goal = currentLevel.goal;
        timeLimit = currentLevel.timeLimit;
        food = currentLevel.maxFoods;
        zombie = currentLevel.maxZombies;
        collectedTarget = 0;
        time = 0;
    }
}
