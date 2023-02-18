using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    public List<GameObject> level;

    [SerializeField] private int _index;

    private void Awake()
    {
        SpawnLevel();
    }

    private void SpawnLevel()
    {
        var currentLevel = Instantiate(level[_index], container);
        currentLevel.transform.localPosition = Vector3.zero;
    }
}
