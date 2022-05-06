using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHp = 10;
    public Animator anim;

    public GameObject[] customs;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        //SetCharacter();
    }

    private void Update()
    {
        //InputCmd();
    }
    
    public void InputCmd()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            anim.SetTrigger("Jap_L");
            anim.SetBool("IsRight", false);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            anim.SetTrigger("Hook_L");
            anim.SetBool("IsRight", false);

        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            anim.SetTrigger("Upper_L");
            anim.SetBool("IsRight", false);

        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            anim.SetTrigger("Jap_R");
            anim.SetBool("IsRight", true);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("Hook_R");
            anim.SetBool("IsRight", true);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("Upper_R");
            anim.SetBool("IsRight", true);
        }
    }

    private void SetCharacter()
    {
        int rand = Random.Range(0, customs.Length);
        customs[rand].SetActive(true);
    }

    public void PlayAnimation(AttackStyle cmd)
    {
        switch(cmd)
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
    }

}
