using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Player in safe radius will prevent enemy spawn
    public float safeRange = 10f;
    public GameObject enemyPrefab;

    private GameObject playerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag(Constants.PLAYER);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(playerGameObject.gameObject.transform.position, gameObject.transform.position) > safeRange &&
           EntitiesManager.IsNewEnemyRespawnPossible())
        {
            SpawnNewEnemy();
        }
    }

    private void SpawnNewEnemy()
    {
        Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
        EntitiesManager.aliveEnemyCounter++;
    }    
}
