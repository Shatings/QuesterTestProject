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

    // Start is called before the first frame update
    void Start()
    {
        colder = GetComponent<MeshCollider>();
        rigidy = GetComponent<Rigidbody>();
    }

    void Move()
    {
        float fosx = Input.GetAxisRaw("Horizontal");
        float fosz = Input.GetAxisRaw("Vertical");

        Vector3 vect = new Vector3(fosx, 0, fosz);
        vect *= movespead;
        rigidy.velocity = vect;
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
        Move();
    }
    private void FixedUpdate()
    {
        
        Jump();
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpbool = false;
        }
    }
}
