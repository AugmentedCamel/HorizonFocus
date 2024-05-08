using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SignPost : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private ControllerDirection _controllerDirection;

    [SerializeField] private Material _materialAiming;
    [SerializeField] private Material _materialShot;

    [SerializeField] private GameObject _CorrectArrow;
    
    private bool _AimingAt;
    // Start is called before the first frame update
    public bool _isSaved;
    
    public void ActivateSignPost(GameObject aim, string text) //used for the correct arrow
    {
        
        _AimingAt = aim;
        _text.text = text;
        _isSaved = false;
    }
    
    public void StartAimSignPost(string text)
    {
        gameObject.SetActive(true);
        _AimingAt = true;
        _isSaved = false;
        _text.text = text;
        _renderer.material = _materialAiming;
    }
    
    public void SetText(string text)
    {
        _text.text = text;
    }
    
    public void AimPosition(GameObject obj)
    {
        _AimingAt = obj;
    }

    private void ActivateCorrectArrow(float angle)
    {
        //the angle here is the score of the shot, so the correct angle is the actual angle of the arrow - the score
        
        if (_CorrectArrow != null)
        {
            _CorrectArrow.SetActive(true);
            _CorrectArrow.transform.localRotation = Quaternion.Euler(-90, 0, angle);
        }
    }
    
    public void Save(float correctLocalAngle)
    {
        _isSaved = true;
        _renderer.material = _materialShot;
        ActivateCorrectArrow(correctLocalAngle);
        //should activate the correct arrow later
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!_isSaved && _AimingAt)
        {
            transform.rotation = Quaternion.Euler(0, _controllerDirection.controllerDirectionYAngle, 0);
            
        }
    }
}
