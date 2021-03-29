using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    public float jumpForce;
    public float forwardForce;
    public bool IsGrounded;
    private Rigidbody rb;
    bool isAlive;
    bool isDouble;
    bool isAvailable;
    Transform end;
    public GameObject die;
   // public Hook hook;
    //Transform player;

    void Start()
    {
     //   player.position = transform.position;
        isAlive = true;
        rb = GetComponent<Rigidbody>();
        die.SetActive(false);
    }

    void Update()
    {
        if (isAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            die.SetActive(true);
            isAlive = false;
        }
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Zacep"))
        {
            isAvailable = true;
            other.transform.position = end.position;
        }
    }
    public void Jump() 
    {
        Ray ray = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit rh;
        if (Physics.Raycast(ray, out rh, 0.5f))
        {
            IsGrounded = true;
            isDouble = false;
        }
        else { IsGrounded = false; }
        if (IsGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            rb.AddForce(Vector3.right * forwardForce);
            isDouble = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isDouble == true)
        {
            isDouble = false;
            isAvailable = false;
            //  Vector3 playerPos = new Vector3(player.position.x, player.position.y, player.position.z);
            //VEctro
            // hook.HookCreate(playerPos, end.position);
        }
    }
}
