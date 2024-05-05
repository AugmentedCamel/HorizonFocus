using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SyncronizeGame _syncronizeGame;
    [SerializeField] private ControllerDirection _controllerDirection;
    [SerializeField] private ControllerActive _controllerActive;
    [SerializeField] private TargetGenerator _targetGenerator;
    [SerializeField] private DesiredAngleController _desiredAngleController;
    [SerializeField] private TextUpdater _textUpdater;
    // Start is called before the first frame update
    
    public int turnCounter = 0;
    
    void Start()
    {
        _syncronizeGame._syncronizingGame = true;
        _controllerActive.ChangeControllerToActive(0);
        //start with syncing the game
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
