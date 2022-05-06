using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    [Header("Attack Sound")]
    public AudioClip[] attackSound;

    [Header("Input Command")]
    public AudioClip inputCmdSound;

    public AudioSource bgm;
    public AudioSource effect;

    public void PlayRandomAttackVfx()
    {
        int rand = Random.Range(0, attackSound.Length);
        effect.PlayOneShot(attackSound[rand]);
    }
    public void PlayInputSound()
    {
        effect.PlayOneShot(inputCmdSound);
    }

}
