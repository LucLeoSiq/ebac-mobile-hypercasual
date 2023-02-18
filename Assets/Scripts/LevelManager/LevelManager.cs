using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    public GameObject level;

    private void Awake()
    {
        SpawnLevel();
    }

    private void SpawnLevel()
    {
        var currentLevel = Instantiate(level, container);
    }
}
