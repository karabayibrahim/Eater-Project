using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyType myType;
    [SerializeField] private float walkRadius;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementBehaviour();
    }

    private void MovementBehaviour()
    {
        switch (myType)
        {
            case EnemyType.FOLLOWER:
                agent.SetDestination(GameManager.Instance.Player.transform.position);
                break;
            case EnemyType.RANDOMER:
                Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
                randomDirection += transform.position;
                //if (Vector3.Distance(tempPos,randomDirection)<=10f)
                //{

                //}
                //Vector3 tempPos = randomDirection;
                NavMeshHit hit;
                NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
                Vector3 finalPosition = hit.position;
                agent.SetDestination(finalPosition);
                break;
            case EnemyType.FRONTCUTTER:
                break;
            default:
                break;
        }
    }
}
