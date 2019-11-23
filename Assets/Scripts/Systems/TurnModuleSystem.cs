using System;
using System.Collections.Generic;

public class TurnModuleSystem : ITEModuleSystem
{
    private static List<ITurnable> turnables;

    public Action EndTrun;

    public override void Exit()
    {

    }

    public override void Initialize()
    {
        turnables = new List<ITurnable>();

        AddCommand(FindObjectOfType<PlayerDataHandler>());
        AddCommand(FindObjectOfType<UIBindSystem>());
        AddCommand(FindObjectOfType<MaterialsModuleSystem>());
    }

    public static void AddCommand(ITurnable command)
    {
        turnables.Add(command);
    }

    public override void Tick()
    {
        
    }

    public static void RemoveCommand(ITurnable command)
    {
        turnables.Remove(command);
    }

    public void EndTurn()
    {
        for (int i = 0; i < turnables.Count; ++i)
        {
            ITurnable c = turnables[i];
            c.TurnFinishUnit();
        }
        EndTrun?.Invoke();
    }

    public override void TurnFinishUnit()
    {
    }
}
