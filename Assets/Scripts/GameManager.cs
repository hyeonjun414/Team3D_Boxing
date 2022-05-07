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
    public Text countcurRound;

    public float startTime = 1f;
    public float cmdTime = 2f;
    public bool isCmdTime;

    public int countdownTime;
    public Text countdownDisplay;



    public void BattleResult()
    {
        //UI랑 연동



    }


    IEnumerator Round()
    {
        while (true)
        {
            if(p1.playerHp  <= 0 || p2.playerHp <= 0 )
            {
                //TODO :: 플레이어 죽었을 때 
                break;
            }

            yield return StartCoroutine("RoundStartRountine");
            yield return StartCoroutine("InputRoutine");
            yield return new WaitForSeconds(2f);
            yield return StartCoroutine(BattleManager.instance.StartBattle());
            //애니메이션 출력

        }
        // TODO :: 플레이어 죽었을 때
        yield return null;

    }

    IEnumerator RoundStartRoutine()
    {
        while (curRound > 5)
        {
            countcurRound.text = countcurRound.ToString();

            yield return new WaitForSeconds(1f);

            curRound++;

        }
        yield return new WaitForSeconds(1f);

        countcurRound.gameObject.SetActive(false);
        //round ui deacive
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


    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;

        }

        countdownDisplay.text = "Go!";

        yield return new WaitForSeconds(1f);


        countdownDisplay.gameObject.SetActive(false);

    }

}
