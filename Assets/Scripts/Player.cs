using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int playerMaxHp = 10;
    private int _playerHp = playerMaxHp;
    public Animator anim;

    public GameObject[] customs;
    public GameResult gameResult;

    public AttackStyle curAttack;

    private bool isDead = false;

    public int playerHp
    {
        get
        {
            return _playerHp;
        }
        set
        {
            _playerHp = value;
            if(_playerHp == 0 )
            {
                anim.SetTrigger("Die");
                isDead = true;
            }
        }
    }


    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        SetCharacter();
    }



    private void SetCharacter()
    {
        int rand = Random.Range(0, customs.Length);
        customs[rand].SetActive(true);
    }


    public void PlayAnimation(AttackStyle cmd)
    {

        if(isDead == true)
        {
            return;
        }
        float loseDeley;
        curAttack = cmd;
        SoundManager.instance.PlayRandomAttackVfx();
        if(gameResult != GameResult.WIN)
        {    
            loseDeley = 0.2f;
        }
        else
        {
            loseDeley = 0f;
        }
        switch(curAttack)
        {
            case AttackStyle.JAP:
                Invoke("PlayAnimJap",loseDeley);
                break;
            case AttackStyle.HOOK:
                Invoke("PlayAnimHook",loseDeley);
                break;
            case AttackStyle.UPPER:
                Invoke("PlayAnimUpper",loseDeley);
                break;
        }
        if(gameResult != GameResult.WIN)
        {
            if(curAttack == AttackStyle.UPPER)
                Invoke("DelayAnim",0.7f);
            else
                Invoke("DelayAnim",0.5f);
        }

        anim.SetInteger("Result",(int)gameResult);

    }


    public void PlayAnimWin()
    {
        Invoke("SetWinTrigger",1f);
    }
    public void PlayAnimJap()
    {
        anim.SetTrigger("Jap");
    }

    public void PlayAnimHook()
    {
        anim.SetTrigger("Hook");
    }
    public void PlayAnimUpper()
    {
        anim.SetTrigger("Upper");
    }

    public void SetWinTrigger()
    {
        anim.SetTrigger("Win");
    }

    public void DelayAnim()
    {
        int randNum = (int)Random.Range(1,4);
        Debug.Log(randNum);
        switch((int)Random.Range(1,4))
        {
        case 1:
            anim.SetTrigger("Hit1");
            break;
        case 2:
            anim.SetTrigger("Hit2");
            break;
        case 3:
            anim.SetTrigger("Hit3");
            break;

        }
    }

}
