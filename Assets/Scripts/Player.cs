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
