using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        colder = GetComponent<MeshCollider>();
        rigidy = GetComponent<Rigidbody>();
    }

    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            float fosx = Input.GetAxisRaw("Horizontal");
            float fosz = Input.GetAxisRaw("Vertical");
            rigidy.velocity += new Vector3(fosx * movespead, 0, fosz * movespead);
            RoteMove(fosx, fosz);
        }
    }
    void RoteMove(float fosx,float fosz)
    {
        Vector3 horvector= new Vector3(0,0,0);


        if (fosx != 0)
        {
             horvector += fosx > 0 ? Vector3.right : Vector3.left;
        }

        Debug.Log(fosx);
        this.trans.position=new Vector3(fosx, 1,1);
        Quaternion.LookRotation(trans.position);
        
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
        Jump();
        Move();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpbool = false;
        }
    }
}
