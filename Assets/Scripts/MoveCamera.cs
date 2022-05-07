using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class MoveCamera : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    public void OnClickSingle()
    {
        virtualCamera.Priority = 0;
        StartCoroutine(LoadMain());
        
    }
    public void OnClickDouble()
    {
        virtualCamera.Priority = 0;
        StartCoroutine(LoadMain());
    }
    IEnumerator LoadMain()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("MainScene");
    }
}
