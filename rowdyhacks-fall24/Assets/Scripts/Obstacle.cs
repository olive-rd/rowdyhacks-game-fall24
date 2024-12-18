using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Obstacle : ScriptableObject
{
    public enum ObstacleType
    {
        Slow,
        Spin
    }

    public string obstacleName;

    public ObstacleType obstacleType;
    public Sprite normalSprite;
    public Sprite futureSprite;

}