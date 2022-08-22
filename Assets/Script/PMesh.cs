using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMesh : MonoBehaviour
{
    public int colliders = 0;
    // Start is called before the first frame update
    void Start()
    {
        List<MeshFilter> meshFitle = new List<MeshFilter>();
        for (int i = 0; i < GetComponentsInChildren<MeshFilter>().Length; i++)
        {
            meshFitle.Add(GetComponentsInChildren<MeshFilter>()[i]);
        }
       
        CombineInstance[] combine = new CombineInstance[meshFitle.Count];
        for(int i = 0; i < meshFitle.Count; i++)
        {
            combine[i].mesh = meshFitle[i].sharedMesh;
            combine[i].transform = meshFitle[i].transform.localToWorldMatrix;
            meshFitle[i].gameObject.SetActive(false);
        }

        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        if (colliders==0)
        {
            transform.GetComponent<MeshCollider>().sharedMesh = transform.GetComponent<MeshFilter>().mesh;
        }
            transform.gameObject.SetActive(true);
    }

    // Update is called once per frame
   
}
