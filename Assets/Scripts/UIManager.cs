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
    public Slider p2HpBar;

    [Header("Command")]
    public Text p1CmdText;
    public Text p2CmdText;
    public CommandUI p1CmdUI;
    public CommandUI p2CmdUI;
    public GameObject cmdTimeBar;

    [Header("Round")]
    public GameObject roundUI;
    public Text roundText;
}
