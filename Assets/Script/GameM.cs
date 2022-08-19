using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameM : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> groundSet = new List<GameObject>();

    [SerializeField]
    private Transform parttreausrbox;
    public List<TreasureBox> listtreasurebox = new List<TreasureBox>(); 
    

    [SerializeField]
    private Transform obstacletransform;
    public List<Obstacle> listobstacle = new List<Obstacle>();

    // Start is called before the first frame update

    void Start()
    {
        for(int i = 0; i < parttreausrbox.childCount; i++)
        {
            listtreasurebox.Add(parttreausrbox.GetComponentsInChildren<TreasureBox>()[i]);
            listtreasurebox[i].transform.position = GetMapTr();
        }
        for(int i=0; i < obstacletransform.childCount; i++)
        {
            listobstacle.Add(obstacletransform.GetComponentsInChildren<Obstacle>()[i]);
            listobstacle[i].transform.position = GetMapTr();
        }
    }
    Vector3 GetMapTr()
    {
        float transx = RandomPot(groundSet[0].transform.position.x,groundSet[1].transform.position.x);
        float transz = RandomPot(groundSet[0].transform.position.z, groundSet[1].transform.position.z);
        return new Vector3(transx, 1, transz);
    }
    float RandomPot(float pot0,float pot1)
    {
        return Random.Range(pot1, pot0);
    }
    

    void Update()
    {
        
    }
}
