using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesManager : MonoBehaviour
{

    // Editor GUI variables
    [Range(0, 10000)]
    public int numberOfEnemiesAvailableToSpawn = 1; 

    //


    public static EntitiesManager Instance { get; private set; }


  
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private static int avaibleEnemyNumber = 0;
    public static int aliveEnemyCounter = 0;

    public static bool IsNewEnemyRespawnPossible()
    {
        if (avaibleEnemyNumber > aliveEnemyCounter) return true;
        else return false;
    }




    // Start is called before the first frame update
    void Start()
    {
        avaibleEnemyNumber = numberOfEnemiesAvailableToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
