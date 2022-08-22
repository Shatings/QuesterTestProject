using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameStat
{
    public static float score;
    public static float heart=10;
    public static GameStat gamest= new GameStat();
    public  bool gameover=false;
    public int treasureboxcount = 0;
    public int obstaclecount = 0;

    public float RandomPot(float pot0, float pot1)
    {
        return Random.Range(pot1, pot0);
    }


    public float GetValue(int _index)
    {
        switch (_index)
        {
            case 0:
                return score;
            case 1:
                return heart;
        }
        return 404;//예외처리용 
    }
    public float SetValue(int _index, float value)
    {
        switch (_index)
        {
            case 0:
                return (score += value);

            case 1:
                return (heart += value);

        }
        return 404;//예외처리용
    }

    public void FindOb(Animator ani,GameObject _gameObject)
    {
         ani.SetBool("Find",true);
        _gameObject.GetComponent<BoxCollider>().enabled = false;
        _gameObject.transform.position = new Vector3(_gameObject.transform.position.x, 1, _gameObject.transform.position.z);
    }
    



}
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

       listobstacle=obstacle();
       listtreasurebox =Makingtreasure();
        for (int i=0; i < GameStat.gamest.obstaclecount; i++)
        {
            listobstacle.Add(obstacletransform.GetComponentsInChildren<Obstacle>()[i]);
            listobstacle[i].transform.position = GetMapTr();
        }
    }
    public List<Obstacle> obstacle()
    {
        List<Obstacle> trealist = new List<Obstacle>();
        GameStat.gamest.obstaclecount = obstacletransform.childCount;
        for (int i = 0; i < GameStat.gamest.obstaclecount; i++)
        {
            trealist.Add(obstacletransform.GetComponentsInChildren<Obstacle>()[i]);
            trealist[i].transform.position = GetMapTr();
            trealist[i].GetComponent<BoxCollider>().enabled = true;
            trealist[i].effect.SetActive(true);

        }
        return trealist;
    }
    public List<TreasureBox> Makingtreasure()
    {
        List<TreasureBox> trealist = new List<TreasureBox>();
        GameStat.gamest.treasureboxcount = parttreausrbox.childCount;
        Debug.Log(parttreausrbox.childCount);
        for (int i = 0; i < parttreausrbox.childCount; i++)
        {
            trealist.Add(parttreausrbox.GetComponentsInChildren<TreasureBox>()[i]);
            trealist[i].transform.position = GetMapTr();
            trealist[i].GetComponent<BoxCollider>().enabled = true;
            trealist[i].effect.SetActive(true);


        }
        return trealist;
    }
    public void treasuretrue()
    {
        for (int i = 0; i < listtreasurebox.Count; i++)
        {
            
            listtreasurebox[i].gameObject.SetActive(true);
        }
    }
    public void obstacletrue()
    {
        for(int i=0;i< listobstacle.Count; i++)
        {
            listobstacle[i].gameObject.SetActive(true);
        }
    }
    Vector3 GetMapTr()
    {
        float transx = GameStat.gamest.RandomPot(groundSet[0].transform.position.x,groundSet[1].transform.position.x);
        float transz = GameStat.gamest.RandomPot(groundSet[0].transform.position.z, groundSet[1].transform.position.z);
        return new Vector3(transx, 0, transz);
    }
}
