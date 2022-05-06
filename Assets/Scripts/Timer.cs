using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public int countdownTime;
    public Text countdownDisplay;

    private void Start()
    {
       
    }

    private void OnEnable()
    {
        StartCoroutine(CountdownToStart());
    }

    private void OnDisable()
    {
        countdownTime = (int)GameManager.instance.cmdTime;
    }

    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
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
