using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandUnit : MonoBehaviour
{
    public Text curCmdText;

    public void SetCommand(AttackStyle cmd)
    {
        switch(cmd)
        {
            case AttackStyle.JAP:
                curCmdText.text = "J";
                break;
            case AttackStyle.HOOK:
                curCmdText.text = "H";
                break;
            case AttackStyle.UPPER:
                curCmdText.text = "U";
                break;
        }
    }

    public void ResetUnit()
    {
        curCmdText.text = "";
    }

}
