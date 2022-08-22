using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float movespead = 0;
    [SerializeField]
    private float jumpspead = 0;

    [SerializeField]
    private bool jumpbool=false;
    public MeshCollider colder;
    public Rigidbody rigidy;

    
    public bool find = false;
    public List<CinemachineVirtualCamera> cinemachineVirtualCameras = new List<CinemachineVirtualCamera>();

    // Start is called before the first frame update
    void Start()
    {
        colder = GetComponent<MeshCollider>();
        rigidy = GetComponent<Rigidbody>();
        cinemachineVirtualCameras[0].GetComponent<Animator>().SetBool("GameStart", true);
    }
    
    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            float fosx = Input.GetAxisRaw("Horizontal");
            float fosz = Input.GetAxisRaw("Vertical");
            Vector3 move = new Vector3(fosx, 0, fosz);
            move = move.normalized * movespead * Time.deltaTime;
            rigidy.MovePosition (transform.position+move);
            RoteMove(fosx, fosz);
        }
    }
    void RoteMove(float fosx,float fosz)
    {
        Vector3 horvector= new Vector3(fosx,0,fosz);


        Quaternion newrotoin = Quaternion.LookRotation(horvector);
        rigidy.rotation = Quaternion.Slerp(rigidy.rotation, newrotoin, movespead * Time.deltaTime);
        
        //if (transform.rotation.eulerAngles.y>90)
        //{
        //    cinemachineVirtualCameras[0].Priority = 9;
        //}
        //else
        //{
        //    cinemachineVirtualCameras[0].Priority =11;
        //}

       
        
    }
    void Jump()
    {
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpbool)
            {
                return;
            }
            rigidy.AddForce(Vector3.up * jumpspead, ForceMode.Impulse);
            jumpbool = true;
        }
          
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameStat.gamest.gameover)
        {
            Jump();
            Move();
            if (Input.GetKeyDown(KeyCode.Z) && find == false)
            {
                StartCoroutine(FindThings());
            }
        }
    }

    IEnumerator FindThings()
    {
        find = true;
        yield return new WaitForSeconds(0.1f);
        find = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpbool = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Treasure"&&find)
        //{
        //    find = false;
        //}
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Treasure" && find)
        {
            find = false;
        }
    }


}
