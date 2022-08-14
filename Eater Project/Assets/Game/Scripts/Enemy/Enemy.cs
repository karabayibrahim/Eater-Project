using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour,IPlayerCollectable
{
    [SerializeField] private EnemyType myType;
    [SerializeField] private float walkRadius;
    private NavMeshAgent agent;
    private NavMeshHit hit;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        RandomPosFind();
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
                if (Vector3.Distance(transform.position,hit.position)>1f)
                {
                    agent.SetDestination(hit.position);
                    Debug.Log(hit.position);
                }
                else
                {
                    RandomPosFind();
                    Debug.Log(hit.position);
                }
                break;
            case EnemyType.FRONTCUTTER:
                Vector3 targetPos = new Vector3(GameManager.Instance.Player.transform.position.x+0.1f, GameManager.Instance.Player.transform.forward.y, GameManager.Instance.Player.transform.forward.z);
                agent.SetDestination(targetPos);
                break;
            default:
                break;
        }
    }

    private void RandomPosFind()
    {
        //Vector3 randomPos = Random.insideUnitSphere * walkRadius+transform.position;
        //NavMesh.SamplePosition(randomPos, out hit, Random.Range(0, walkRadius), NavMesh.AllAreas);
        Vector3 randomPos = new Vector3(Random.Range(8, -8f), transform.position.y, Random.Range(8, -8f));
        hit.position = randomPos;
        NavMeshPath path = new NavMeshPath();
        while (!agent.CalculatePath(randomPos, path)||Vector3.Distance(transform.position,hit.position)<1.5f)
        {
            randomPos = Random.insideUnitSphere * walkRadius;
            NavMesh.SamplePosition(randomPos, out hit, Random.Range(0, walkRadius), NavMesh.AllAreas);
            if (agent.CalculatePath(randomPos, path)&& Vector3.Distance(transform.position, hit.position) < 1f)
            {
                hit.position = randomPos;
                break;
            }
        }
    }

    public void DoPlayerCollect()
    {
        if (GameManager.Instance.Player.EatStatus)
        {
            Destroy(gameObject);
        }
    }
}
