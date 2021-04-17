using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Material changeTo;
    private Material defaultMaterial;
    private Ray _ray;
    private RaycastHit _hit;

    private bool hasTarget;
    
    
    
    private void Awake()
    {
        _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
    }

    void FixedUpdate()
    {
        
        
        if (!hasTarget && Physics.Raycast(_ray, out _hit, Mathf.Infinity))
        {
            hasTarget = true;
            // Debug.Log(_hit.transform.name);
            Select(_hit.transform.gameObject);
            
        }
        else
        {
            hasTarget = false;
        }
    }

    private void Select(GameObject toSelect)
    {
        var mat = toSelect.GetComponent<MeshRenderer>().material;
        defaultMaterial = mat;
        mat = changeTo;
        toSelect.GetComponent<MeshRenderer>().material = mat;

    }
    
    
    private void Reset(GameObject toSelect)
    {
        var mat = toSelect.GetComponent<MeshRenderer>().material;
        mat = defaultMaterial;
        toSelect.GetComponent<MeshRenderer>().material = mat;

    }
}
