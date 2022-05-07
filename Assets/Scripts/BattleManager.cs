using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
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
          

            // 쳐 맞음
            if(p1.gameResult != GameResult.WIN)
            {
                p1.playerHp--;
                UIManager.instance.p1HpBar.value = p1.playerHp;
            }
            if(p2.gameResult != GameResult.WIN)
            {
                p2.playerHp--;
                UIManager.instance.p2HpBar.value = p2.playerHp;
            }
            // UI 변경 HP 변경사항
            UIManager.instance.p1HpText.text = p1.playerHp.ToString();
            UIManager.instance.p2HpText.text = p2.playerHp.ToString();

            if(p1.playerHp == 0 && p2.playerHp == 0)
            {
                //비겼을때
                break;
            }
            else
            {

                if(p1.playerHp == 0)
                {
                    //p2가 이겼을때
                    p2.PlayAnimation(CommandManager.instance.p2Attack[i]);
                    p2.PlayAnimWin();
                    break;
                }
                if (p2.playerHp == 0)
                {
                    //p1이 이겼을때
                    p1.PlayAnimation(CommandManager.instance.p1Attack[i]);
                    p1.PlayAnimWin();
                    break;
                }
            }
            p1.PlayAnimation(CommandManager.instance.p1Attack[i]);
            p2.PlayAnimation(CommandManager.instance.p2Attack[i]);

            yield return new WaitForSeconds(2f);
        }
        yield return null;
    }

    public void EndBattle()
    {
        
    }
}
