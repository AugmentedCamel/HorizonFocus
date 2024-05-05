using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetGenerator : MonoBehaviour
{
    
    private List<string> _targets = new List<string> { "North", "North-East", "East", "South-East", "South", "South-West", "West", "North-West", "Amsterdam" };
    private List<float> _targetAngles = new List<float> { 0, 45, 90, 135, 180, 225, 270, 315, 35 };
    
    public string currentTarget = "N";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float GenerateTarget()
    {
        
        int newIndex = Random.Range(0, _targets.Count);
        currentTarget = _targets[newIndex];
        return _targetAngles[newIndex];
    }
}
