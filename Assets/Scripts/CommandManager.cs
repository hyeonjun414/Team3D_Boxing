using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackStyle
{
    UPPER,
    HOOK,
    JAP,
}
public class CommandManager : MonoBehaviour
{
    public static CommandManager instance {get;private set;}
    
    List<AttackStyle> p1Ataack;
    List<AttackStyle> p2Attack;
    uint nextCount;
    uint p1CurCount;
    uint p2CurCount;
    uint maxCount;

    private void Awake()
    {
        instance = this;
    }
    public void InputCommand()
    {
        //겟버튼 겟키  -> 플레이어1 3개 플레이어2 3개
    }
    public void RandomCommand()
    {
        for(uint i=p1CurCount; i<=maxCount; ++i)
        {
           // Random.Range()
           // p1Ataack.Add()
        }
        for(uint i=p2CurCount; i<=maxCount; ++i)
        {
            
        }
    }
}
