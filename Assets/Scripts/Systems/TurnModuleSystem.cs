using System.Collections.Generic;

public class TurnModuleSystem : ITEModuleSystem
{
    private static List<ITurnable> turnables;

    public override void Exit()
    {

    }

    public override void Initialize()
    {
        turnables = new List<ITurnable>();

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

    public void EndTurn()
    {
        for (int i = 0; i < turnables.Count; ++i)
        {
            ITurnable c = turnables[i];
            c.Execute();
        }
    }

    public override void Execute()
    {
    }
}
