using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
    public EnemyData enemyData;

    public float speed;
    public float rSpeed;
    public float delay;
    public EnemyType eType;

    public Transform player;

    private NavMeshAgent agentAI;
    public int tarPoint;
    public Transform[] points;

    public GameObject sensor;
    // Use this for initialization
    void Start () {
        delay = enemyData.delay;
        eType = enemyData.enemyType;

        tarPoint = 0;
        agentAI = GetComponent<NavMeshAgent>();
        agentAI.autoBraking = false;
        agentAI.speed = enemyData.speed;
        agentAI.angularSpeed = enemyData.rotationSpeed;
        agentAI.acceleration = enemyData.acceleration;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        if(eType == EnemyType.Patrol)
        {
            GoToNextPoint();
        }
	}
	
	// Update is called once per frame
	void Update () {
        Movement(eType);
	}

    void Movement(EnemyType enemytype)
    {
        switch(enemytype)
        {
            case EnemyType.Idle:
               
                break;
            case EnemyType.Patrol:
                if (!agentAI.pathPending && agentAI.remainingDistance < 0.5f)
                {
                    GoToNextPoint();
                }
                    break;
          
            case EnemyType.Attack:
                agentAI.destination = player.position;
                break;
        }
    }

    void GoToNextPoint()
    {
        if(points.Length == 0)
        {
            eType = EnemyType.Idle;
            return;
        }
            agentAI.destination = points[tarPoint].position;
            tarPoint = (tarPoint + 1) % points.Length;
            return;
    }



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Player detected");
            eType = EnemyType.Attack;
        }
    }
}
