using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SyncronizeGame : MonoBehaviour
{
    public bool _syncronizingGame = false;
    
    [SerializeField] private GameNorth _gameNorth;
    [SerializeField] private ControllerDirection _controllerDirection;
    [SerializeField] private GameObject _horizonFocusTarget;
    public UnityEvent OnSyncGame;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetNorthRotation(float angle)
    {
        if (_syncronizingGame)
        {
            _gameNorth.gameObject.transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
    
    public void SetAimHorizonFocus(float angle)
    {
        if (!_syncronizingGame)
        {
            _horizonFocusTarget.transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
    
    public void SaveNorthDirection()
    {
        if (_syncronizingGame)
        {
            _syncronizingGame = false;
            OnSyncGame.Invoke();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_syncronizingGame)
        {
            if (_controllerDirection != null)
            {
                SetNorthRotation(_controllerDirection.controllerDirectionYAngle);
                SetAimHorizonFocus(_controllerDirection.controllerDirectionYAngle);
            }

        }
    }
}
