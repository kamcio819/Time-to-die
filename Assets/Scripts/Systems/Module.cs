using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : MonoBehaviour
{
    protected virtual void Awake()
    {
        
    }

    protected virtual void Start()
    {

    }

    protected virtual void OnEnable()
    {

    }

    protected virtual void OnDisable()
    {
        
    }

    protected virtual void Update()
    {

    }

    public abstract void GetUnits();
}
