using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHp = 10;
    public Transform target;
    public float moveSpeed = 5f;
    public float rotateSpeed = 10f;
    public Animator anim;
    public Rigidbody rb;

    public GameObject[] customs;

    public Vector3 curPos;
    public Quaternion curRot;

    public Player attackTarget = null;
    private void Start()
    {
        //pv.RPC("SetCharacter", RpcTarget.AllBuffered);
        //SetCharacter();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputCmd();
        if(target != null)
            transform.LookAt(target.position);
        Move();
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
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, -1, 0)* rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime);
        }
    }

    private void SetCharacter()
    {
        int rand = Random.Range(0, customs.Length);
        customs[rand].SetActive(true);
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //rb.velocity = new Vector3(1,0,0);
        Vector3 dir = new Vector3(x, 0, z);

        transform.Translate(dir * moveSpeed * Time.deltaTime);

        

    }
}
