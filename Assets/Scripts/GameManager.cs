using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set;}


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine("Round");
    }

    public float commandInputTime;
    public Player p1;
    public Player p2;

    public int curRound = 1;
    public float startTime = 1f;
    public float cmdTime = 2f;
    public bool isCmdTime;

    public void BattleResult()
    {
        //UI랑 연동
    }


    IEnumerator Round()
    {
        while (true)
        {
            yield return StartCoroutine("InputRoutine");
            yield return new WaitForSeconds(2f);
        }
    }
    IEnumerator RoundStartRoutine()
    {
        GameObject ui = UIManager.instance.roundUI;
        ui.GetComponentInChildren<Text>().text = $"ROUND {curRound}";
        UIManager.instance.roundText.text = $"ROUND {curRound}";
        ui.gameObject.SetActive(true);
        yield return new WaitForSeconds(startTime);
        ui.gameObject.SetActive(false);
    }
    IEnumerator InputRoutine()
    {
        print("인풋 시작");
        float curTime = 0f;

        UIManager.instance.timer.gameObject.SetActive(true);    
        CommandManager.instance.ResetCommand();
        while(true)
        {
            if(curTime > cmdTime) break;

            print("인풋 중");
            curTime += Time.deltaTime;
            
            CommandManager.instance.InputCommand();
            yield return null;
        }

        CommandManager.instance.RandomCommand();
        print("인풋 종료");
        yield return null;
    }

}
