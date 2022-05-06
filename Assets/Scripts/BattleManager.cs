using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//쨉 > 어퍼    어퍼 > 훅   , 훅 >쨉 
public class BattleManager : MonoBehaviour
{
    public CinemachineVirtualCamera p1Cam;
    public CinemachineVirtualCamera p2Cam;
    public CinemachineVirtualCamera neutralCam;

    public static BattleManager instance{get;private set;}
    private void Awake()
    {
        instance = this;
    }
    
    public IEnumerator StartBattle()
    {
        Player p1 = GameManager.instance.p1;
        Player p2 = GameManager.instance.p2;
        for (int i =0 ; i < CommandManager.instance.p1Attack.Count ; i++)
        {
            if(CommandManager.instance.p1Attack[i] == AttackStyle.JAP)
            {
                if(CommandManager.instance.p2Attack[i] == AttackStyle.JAP)
                {
                    p1.gameResult = GameResult.DRAW;
                    p2.gameResult = GameResult.DRAW;
                }
                else if(CommandManager.instance.p2Attack[i] == AttackStyle.UPPER)
                {
                    p1.gameResult  = GameResult.WIN;
                    p2.gameResult = GameResult.LOSE;
                }
                else
                {
                    p1.gameResult  = GameResult.LOSE;
                    p2.gameResult = GameResult.WIN;
                }
            }
            if(CommandManager.instance.p1Attack[i] == AttackStyle.HOOK)
            {
                if(CommandManager.instance.p2Attack[i] == AttackStyle.JAP)
                {
                    p1.gameResult  = GameResult.WIN;
                    p2.gameResult = GameResult.LOSE;
                }
                else if(CommandManager.instance.p2Attack[i] == AttackStyle.UPPER)
                {
                    p1.gameResult  = GameResult.LOSE;
                    p2.gameResult = GameResult.WIN;
                }
                else
                {
                    p1.gameResult  = GameResult.DRAW;
                    p2.gameResult = GameResult.DRAW;
                }
            }
            if(CommandManager.instance.p1Attack[i] == AttackStyle.UPPER)
            {
                if(CommandManager.instance.p2Attack[i] == AttackStyle.JAP)
                {
                    p1.gameResult  = GameResult.LOSE;
                    p2.gameResult = GameResult.WIN;
                }
                else if(CommandManager.instance.p2Attack[i] == AttackStyle.UPPER)
                {
                    p1.gameResult  = GameResult.DRAW;
                    p2.gameResult = GameResult.DRAW;
                }
                else
                {
                    p1.gameResult  = GameResult.WIN;
                    p2.gameResult = GameResult.LOSE;
                }
            }
            p1.PlayAnimation(CommandManager.instance.p1Attack[i]);
            p2.PlayAnimation(CommandManager.instance.p2Attack[i]);
            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }

    public void EndBattle()
    {
        
    }
}
