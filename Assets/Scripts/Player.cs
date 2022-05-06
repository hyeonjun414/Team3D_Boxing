using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHp = 10;
    public Animator anim;

    public GameObject[] customs;
    public GameResult gameResult;

    public AttackStyle curAttack;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        //SetCharacter();
    }

    private void Update()
    {

    }



    private void SetCharacter()
    {
        int rand = Random.Range(0, customs.Length);
        customs[rand].SetActive(true);
    }

    public void PlayAnimation(AttackStyle cmd)
    {
        curAttack = cmd;

        switch(curAttack)
        {
            case AttackStyle.JAP:
                anim.SetTrigger("Jap");
                break;
            case AttackStyle.HOOK:
                anim.SetTrigger("Hook");
                break;
            case AttackStyle.UPPER:
                anim.SetTrigger("Upper");
                break;
        }
        if(gameResult != GameResult.WIN)
        {
            if(curAttack == AttackStyle.UPPER)
                Invoke("DelayAnim",0.3f);
            else
                Invoke("DelayAnim",0.5f);
        }
        //if(gameResult == GameResult.LOSE )
        //{
        //}
        //이기거나 비길떄 공격

        //else 트리거 , 인티저

        anim.SetInteger("Result",(int)gameResult);
    }

    public void DelayAnim()
    {
        anim.SetTrigger("Hit");
        
    }

}
