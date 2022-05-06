using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackStyle
{
    UPPER,
    HOOK,
    JAP,
}
public class CommandManager : MonoBehaviour
{
    public static CommandManager instance {get;private set;}

    public List<AttackStyle> p1Attack;
    public List<AttackStyle> p2Attack;

    public int p1CurCount;
    public int p2CurCount;
    public int maxCount;

    public CommandUI p1CmdUI;
    public CommandUI p2CmdUI;



    private void Awake()
    {
        instance = this;


    }
    private void Start()
    {
        p1CmdUI = UIManager.instance.p1CmdUI;
        p2CmdUI = UIManager.instance.p2CmdUI;
    }

    private void Update()
    {
        //InputCommand();
    }
    public void InputCommand()
    {
        //if (!GameManager.instance.isCmdTime) return;

        if (p1CurCount < maxCount)
        {
            // 1P 키입력 ( Q : 잽, W : 훅, E : 어퍼 )
            if (Input.GetKeyDown(KeyCode.Q))
            {
                UIManager.instance.p1CmdText.text = "JAP";
                p1Attack.Add(AttackStyle.JAP);
                p1CmdUI.UpdateUI();
                p1CurCount++;
                SoundManager.instance.PlayInputSound();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                UIManager.instance.p1CmdText.text = "HOOK";
                p1Attack.Add(AttackStyle.HOOK);
                p1CmdUI.UpdateUI();
                p1CurCount++;
                SoundManager.instance.PlayInputSound();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                UIManager.instance.p1CmdText.text = "UPPER";
                p1Attack.Add(AttackStyle.UPPER);
                p1CmdUI.UpdateUI();
                p1CurCount++;
                SoundManager.instance.PlayInputSound();
            }
        }
        else
        {
            UIManager.instance.p1CmdText.text = "END";
            //p1Attack.Clear();
            //p1CurCount = 0;
        }

        
        if(p2CurCount < maxCount)
        {
            // 2P 키입력 ( I : 잽, O : 훅, P : 어퍼 )
            if (Input.GetKeyDown(KeyCode.I))
            {
                UIManager.instance.p2CmdText.text = "JAP";
                p2Attack.Add(AttackStyle.JAP);
                p2CmdUI.UpdateUI();
                p2CurCount++;
                SoundManager.instance.PlayInputSound();
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                UIManager.instance.p2CmdText.text = "HOOK";
                p2Attack.Add(AttackStyle.HOOK);
                p2CmdUI.UpdateUI();
                p2CurCount++;
                SoundManager.instance.PlayInputSound();
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                UIManager.instance.p2CmdText.text = "UPPER";
                p2Attack.Add(AttackStyle.UPPER);
                p2CmdUI.UpdateUI();
                p2CurCount++;
                SoundManager.instance.PlayInputSound();
            }
        }
        else
        {
            UIManager.instance.p2CmdText.text = "END";
            //p2Attack.Clear();
            //p2CurCount = 0;
        }

        if(Input.GetKeyDown(KeyCode.F2))
        {
            RandomCommand();
        }
        if(Input.GetKeyDown(KeyCode.F3))
        {
            ResetCommand();
        }


    }
    public void RandomCommand()
    {
        int rand = 0;
        for(int i=p1CurCount; i<maxCount; ++i)
        {
            rand = Random.Range(0, 3);
            switch(rand)
            {
                case 0: p1Attack.Add(AttackStyle.JAP); break;
                case 1: p1Attack.Add(AttackStyle.HOOK); break;
                case 2: p1Attack.Add(AttackStyle.UPPER); break;
            }
        }
        for(int i=p2CurCount; i<maxCount; ++i)
        {
            rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0: p2Attack.Add(AttackStyle.JAP); break;
                case 1: p2Attack.Add(AttackStyle.HOOK); break;
                case 2: p2Attack.Add(AttackStyle.UPPER); break;
            }
        }
        p1CmdUI.UpdateUI();
        p2CmdUI.UpdateUI();
    }

    public void ResetCommand()
    {
        p1Attack.Clear();
        p1CurCount = 0;
        p1CmdUI.UpdateUI();

        p2Attack.Clear();
        p2CurCount = 0;
        p2CmdUI.UpdateUI();


    }
}
