using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SyncronizeGame _syncronizeGame;
    [SerializeField] private ControllerDirection _controllerDirection;
    [SerializeField] private ControllerActive _controllerActive;
    [SerializeField] private TargetGenerator _targetGenerator;
    [SerializeField] private DesiredAngleController _desiredAngleController;
    [SerializeField] private TextUpdater _textUpdater;
    [SerializeField] private SceneActivator _sceneActivator;
    [SerializeField] private PoleManager _poleManager;
    // Start is called before the first frame update
    
    public int turnCounter = 0;
    private bool _isCoordinated = false;
    void Start()
    {
        
        //start with cordinating game
        //StartCoordinatingGame();
        //StartSyncGame();
    }
    
    
    public void StartCoordinatingGame() //happens after spawning of all MRUK objects
    {
        _isCoordinated = false;
        _controllerActive.DeactivateAllControllers();
        _sceneActivator.ActivateObjectsOne();
        Invoke("SetPoleActive", 3); //delay so that the all th scene objecst can spawn?
        

    }

    private void SetPoleActive()
    {
        _poleManager.SetPoleActive();
    }
    
    public void OnGameCoordinated()
    {
        if (!_isCoordinated)
        {
            _isCoordinated = true;
            StartSyncGame();
        }
        
    }
    public void StartSyncGame()
    {
        _syncronizeGame._syncronizingGame = true;
        _controllerActive.ChangeControllerToActive(0);
        _sceneActivator.ActivateObjectsTwo();
        
    }
    
    public void OnSyncGame()
    {
        _controllerActive.ChangeControllerToActive(1);
        StartGame();
        
    }
    
    private void StartGame()
    {
        turnCounter = 0;
        NewTurn();
        
    }
    
    private void NewTurn()
    {
        
        float newTarget = _targetGenerator.GenerateTarget();
        string newTargetstring = _targetGenerator.currentTarget;
        
        _desiredAngleController.SetTargetAngle(newTarget);
        _textUpdater.UpdateTargetText(newTargetstring);
    }
    
    public void OnPlayerShoot(float score)
    {
        turnCounter++;
        _textUpdater.UpdateScoreText((int)score);
        
        //do something with turn counter
        //start newturn after seconds
        Invoke("NewTurn", 5);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
