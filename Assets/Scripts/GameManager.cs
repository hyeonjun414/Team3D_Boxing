using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set;}
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(Round());
    }

    public float commandInputTime;
    public Player p1;
    public Player p2;

    public void BattleResult()
    {
        //UI랑 연동
    }


    IEnumerator Round()
    {
        while(true)
        {
        ////
        //Round 1 -> UI, 혹은 사운드를 깔고 
        yield return new WaitForSeconds(3.0f);
        ////

        yield break; //StartCoroutine(CommandManager.instance.)
        }
    }

}
