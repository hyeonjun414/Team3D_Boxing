using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//쨉 > 어퍼    어퍼 > 훅   , 훅 >쨉 
public class BattleManager : MonoBehaviour
{
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
                    CameraManager.instance.ActiveCam(CamType.DrawCam);
                }
                else if(CommandManager.instance.p2Attack[i] == AttackStyle.UPPER)
                {
                    p1.gameResult  = GameResult.WIN;
                    p2.gameResult = GameResult.LOSE;
                    CameraManager.instance.ActiveCam(CamType.P1Cam);
                }
                else
                {
                    p1.gameResult  = GameResult.LOSE;
                    p2.gameResult = GameResult.WIN;
                    CameraManager.instance.ActiveCam(CamType.P2Cam);
                }
            }
            if(CommandManager.instance.p1Attack[i] == AttackStyle.HOOK)
            {
                if(CommandManager.instance.p2Attack[i] == AttackStyle.JAP)
                {
                    p1.gameResult  = GameResult.WIN;
                    p2.gameResult = GameResult.LOSE;
                    CameraManager.instance.ActiveCam(CamType.P1Cam);
                }
                else if(CommandManager.instance.p2Attack[i] == AttackStyle.UPPER)
                {
                    p1.gameResult  = GameResult.LOSE;
                    p2.gameResult = GameResult.WIN;
                    CameraManager.instance.ActiveCam(CamType.P2Cam);
                }
                else
                {
                    p1.gameResult  = GameResult.DRAW;
                    p2.gameResult = GameResult.DRAW;
                    CameraManager.instance.ActiveCam(CamType.DrawCam);
                }
            }
            if(CommandManager.instance.p1Attack[i] == AttackStyle.UPPER)
            {
                if(CommandManager.instance.p2Attack[i] == AttackStyle.JAP)
                {
                    p1.gameResult  = GameResult.LOSE;
                    p2.gameResult = GameResult.WIN;
                    CameraManager.instance.ActiveCam(CamType.P2Cam);
                }
                else if(CommandManager.instance.p2Attack[i] == AttackStyle.UPPER)
                {
                    p1.gameResult  = GameResult.DRAW;
                    p2.gameResult = GameResult.DRAW;
                    CameraManager.instance.ActiveCam(CamType.DrawCam);
                }
                else
                {
                    p1.gameResult  = GameResult.WIN;
                    p2.gameResult = GameResult.LOSE;
                    CameraManager.instance.ActiveCam(CamType.P1Cam);
                }
            }
            p1.PlayAnimation(CommandManager.instance.p1Attack[i]);
            p2.PlayAnimation(CommandManager.instance.p2Attack[i]);
            yield return new WaitForSeconds(1f);
            CameraManager.instance.ActiveCam(CamType.Normal);
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }

    public void EndBattle()
    {
        
    }
}
