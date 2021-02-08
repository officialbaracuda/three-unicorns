using System;
using UnityEngine;

[Serializable]
public class Pool
{
    public enum Type { FOOD, ZOMBIE, GHOST, TARGET };
    public Type tag;
    public int size;
    public GameObject[] objects;
}
