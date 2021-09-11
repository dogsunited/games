using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Transform Player;
    public float Player_Distance_Spawn_Level_Part = 100f;
    public Transform levelPart_Start;
    public List<Transform> levelPartList;

    private Vector3 lastEndPosition;

    void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPos").position;

        int startingSpawnLevelParts = 5;

        for(int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    void Update()
    {
        if(Vector3.Distance(Player.position, lastEndPosition) < Player_Distance_Spawn_Level_Part)
        {
            SpawnLevelPart();
        }
    }

    void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPos").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
 