using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    [Header("Player")]

    public Slider p1HpBar;
    public Text p1HpText;
    public Slider p2HpBar;
    public Text p2HpText;

    [Header("Command")]
    public Text p1CmdText;
    public Text p2CmdText;
    public CommandUI p1CmdUI;
    public CommandUI p2CmdUI;
    public Timer timer;

    [Header("Round")]
    public GameObject roundUI;
    public Text roundText;

    [Header("Result")]
    public GameObject resultUI;
    public Text resultText;
    
    private void Start() 
    {
        p2HpBar.maxValue = p1HpBar.maxValue = Player.playerMaxHp;
        p2HpBar.value = p1HpBar.value = Player.playerMaxHp;
    }
}
