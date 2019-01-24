using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Idle,
    Patrol,
    Attack
}

[CreateAssetMenu (fileName = "EnemyData", menuName = "Enemies", order = 1)]
public class EnemyData : ScriptableObject {

    public float speed;
    public float rotationSpeed;
    public float delay;
    public float acceleration;
    public EnemyType enemyType;
    }
