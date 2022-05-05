using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BattleManager : MonoBehaviour
{
    public int round;

    CinemachineVirtualCamera p1Cam;
    CinemachineVirtualCamera p2Cam;
    CinemachineVirtualCamera neutralCam;

    public static BattleManager instance{get;private set;}
    private void Awake()
    {
        instance = this;
    }
    
    IEnumerator StartBattle(List<int> player1List, List<int> player2List)
    {
        //for문으로
        {
            //player1List[i] player2List[i]
            //yield return 
        }
        yield break;
        
    }
    public void EndBattle()
    {
        
    }
}
