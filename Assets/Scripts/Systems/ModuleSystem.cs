using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ModuleSystem<T> : Module
    where T : Unit
{
    [SerializeField]
    protected List<T> singleUnits;

    protected override void Awake()
    {
        base.Awake();

        for (int i = 0; i < singleUnits.Count; ++i)
        {
            InitUnit initUnit = singleUnits[i] as InitUnit;
            if (initUnit)
            {
                initUnit.Initialize();
            }
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        for (int i = 0; i < singleUnits.Count; ++i)
        {
            ExitUnit exitUnit = singleUnits[i] as ExitUnit;
            if (exitUnit)
            {
                exitUnit.Exit();
            }
        }
    }

    protected override void Update()
    {
        base.Update();
        for (int i = 0; i < singleUnits.Count; ++i)
        {
            TickUnit tickUnit = singleUnits[i] as TickUnit;
            if (tickUnit)
            {
                tickUnit.Tick();
            }
        }
    }

    public override void GetUnits()
    {
        singleUnits = GetComponentsInChildren<T>().ToList();
    }
}

public abstract class ModuleSystem<T1, T2> : Module 
    where T1 : TickUnit
    where T2 : Unit
{
    [SerializeField]
    protected List<T1> tickUnits;

    [SerializeField]
    protected List<T2> restUnits;


    protected override void Awake()
    {
        base.Awake();

        for (int i = 0; i < restUnits.Count; ++i)
        {
            InitUnit initUnit = restUnits[i] as InitUnit;
            if (initUnit)
            {
                initUnit.Initialize();
            }
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        for (int i = 0; i < restUnits.Count; ++i)
        {
            ExitUnit exitUnit = restUnits[i] as ExitUnit;
            if (exitUnit)
            {
                exitUnit.Exit();
            }
        }
    }

    protected override void Update()
    {
        base.Update();
        for (int i = 0; i < tickUnits.Count; ++i)
        {
            TickUnit tickUnit = tickUnits[i] as TickUnit;
            if (tickUnit)
            {
                tickUnit.Tick();
            }
        }
    }

    public override void GetUnits()
    {
        tickUnits = GetComponentsInChildren<T1>().ToList();
        T2[] units = GetComponentsInChildren<T2>();
        for(int i =0; i < units.Length; ++i)
        {
            Unit unit = tickUnits.Find(x => x.Equals(units[i]));
            if(!unit)
            {
                restUnits.Add(units[i]);
            }
        }
    }
}

public abstract class ModuleSystem<T1, T2, T3> : Module
    where T1: InitUnit
    where T2: TickUnit
    where T3: ExitUnit
{
    [SerializeField]
    protected List<T1> initUnits;

    [SerializeField]
    protected List<T2> tickUnits;

    [SerializeField]
    protected List<T3> exitUnits;

    protected override void Awake()
    {
        base.Awake();

        for (int i = 0; i < initUnits.Count; ++i)
        {
            InitUnit initUnit = initUnits[i] as InitUnit;
            if (initUnit)
            {
                initUnit.Initialize();
            }
        }
    }

    protected override void OnDisable()
    
{

        base.OnDisable();

        for (int i = 0; i < exitUnits.Count; ++i)
        {
            ExitUnit exitUnit = exitUnits[i] as ExitUnit;
            if (exitUnit)
            {
                exitUnit.Exit();
            }
        }
    }

    protected override void Update()
    {
        base.Update();
        for (int i = 0; i < tickUnits.Count; ++i)
        {
            TickUnit tickUnit = tickUnits[i] as TickUnit;
            if (tickUnit)
            {
                tickUnit.Tick();
            }
        }
    }

    public override void GetUnits()
    {
        initUnits = GetComponentsInChildren<T1>().ToList();
        tickUnits = GetComponentsInChildren<T2>().ToList();
        exitUnits = GetComponentsInChildren<T3>().ToList();
    }
}
