using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandUI : MonoBehaviour
{
    public bool isPlayer1;
    public CommandUnit[] cmdUnits;
    // Start is called before the first frame update
    void Start()
    {
        cmdUnits = GetComponentsInChildren<CommandUnit>();
    }

    public void UpdateUI()
    {
        List<AttackStyle> curCmdList = isPlayer1 ? CommandManager.instance.p1Attack : CommandManager.instance.p2Attack;

        for(int i = 0; i< cmdUnits.Length; i++)
        {
            if (i < curCmdList.Count)
                cmdUnits[i].SetCommand(curCmdList[i]);
            else
                cmdUnits[i].ResetUnit();
        }
    }

}
