using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

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
    
    public IEnumerator StartBattle(List<AttackStyle> player1List, List<AttackStyle> player2List)
    {
        
        yield return null;
    }
    public void EndBattle()
    {
        
    }
}
