using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncronizeGame : MonoBehaviour
{
    public bool _syncronizingGame = false;
    
    [SerializeField] private GameNorth _gameNorth;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_syncronizingGame)
        {
            _gameNorth.gameNorth.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
