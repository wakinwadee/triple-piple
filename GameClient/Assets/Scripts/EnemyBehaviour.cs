using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBehaviour : MonoBehaviour
{
    private GameObject playerObject;
    private NavMeshAgent agent;
    public int hitPoints = 100;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag(Constants.PLAYER);
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerObject.transform.position);
        if (!IsStillAlive()) Destroy(gameObject);
    }

    public void CountHit(int amount)
    {
        hitPoints -= amount;
    }

    public bool IsStillAlive()
    {
        if (hitPoints <= 0) return false;
        else return true;
    }
}
