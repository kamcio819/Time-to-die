using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class IModuleSystem : Module, IInitiable
{
    protected virtual void Awake()
    {
        Initialize();
    }

    public abstract void Initialize();
}

public abstract class EModuleSystem : Module, IExitable
{
    protected virtual void OnDestroy()
    {
        Exit();
    }

    public abstract void Exit();
}

public abstract class TModuleSystem : Module, ITickable
{
    protected virtual void Update()
    {
        Tick();
    }

    public abstract void Tick();
}

public abstract class IEModuleSystem : Module, IInitiable, IExitable
{
    protected virtual void Awake()
    {
        Initialize();
    }

    protected virtual void OnDestroy()
    {
        Exit();
    }

    public abstract void Initialize();
    public abstract void Exit();
}

public abstract class ITModuleSystem : Module, IInitiable, ITickable
{
    protected virtual void Awake()
    {
        Initialize();
    }

    protected virtual void Update()
    {
        Tick();
    }

    public abstract void Initialize();
    public abstract void Tick();
}

public abstract class TEModuleSystem : Module, ITickable, IExitable
{
    protected virtual void OnDestroy()
    {
        Exit();
    }

    protected virtual void Update()
    {
        Tick();
    }

    public abstract void Tick();
    public abstract void Exit();
}

public abstract class ITEModuleSystem : Module, IInitiable, ITickable, IExitable
{
    protected virtual void Awake()
    {
        Initialize();
    }

    protected virtual void OnDestroy()
    {
        Exit();
    }

    protected virtual void Update()
    {
        Tick();
    }

    public abstract void Initialize();
    public abstract void Tick();
    public abstract void Exit();
}

