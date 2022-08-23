using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI heart;
    public TextMeshProUGUI Counttext;
    public PlayerMove player;
    public GameObject gameoverImage;
    public GameM gameM;


    public void Start()
    {
        Application.targetFrameRate = 144;
        gameM = GetComponent<GameM>();
        StartCoroutine(Check());
        gameoverImage.SetActive(false);
       
    }

    // Start is called before the first frame update
    public bool Heart()
    {
        if (GameStat.gamest.GetValue(1) > 0)
        {
            Debug.Log("¤·¤·");
            return true;
        }
        GameStat.gamest.gameover = true;
        player.cinemachineVirtualCameras[0].GetComponent<Animator>().SetBool("GameStart", false);
        return false;

    }

    IEnumerator Check()
    {
        while (Heart())
        {
            scoretext.text = GameStat.gamest.GetValue(0).ToString();
            heart.text = GameStat.gamest.GetValue(1).ToString();
            Counttext.text = string.Format("BoxCount={0}   RockCount ={1}", GameStat.gamest.treasureboxcount, GameStat.gamest.obstaclecount);
           
            yield return null;
            if (GameStat.gamest.treasureboxcount == 0)
            {
                yield return new WaitForSeconds(1.5f);
                gameM.treasuretrue();
                gameM.listtreasurebox = new List<TreasureBox>();
                gameM.listtreasurebox = gameM.Makingtreasure();
                //GameStat.gamest.SetValue(1, 10 - GameStat.gamest.obstaclecount);
                gameM.obstacletrue();
                gameM.listobstacle = new List<Obstacle>();
                gameM.listobstacle = gameM.obstacle();
                
            }
        }
        gameoverImage.SetActive(true);

       
    }
    public void Retry(string _name)
    {
        GameStat.gamest.SetValue(1, 10);
        GameStat.gamest.SetValue(0, 0);
        GameStat.gamest.gameover = false;
        gameoverImage.SetActive(false);
        gameM.treasuretrue();
        gameM.listtreasurebox = new List<TreasureBox>();
        gameM.listtreasurebox = gameM.Makingtreasure();
        gameM.obstacletrue();
        gameM.listobstacle = new List<Obstacle>();
        gameM.listobstacle = gameM.obstacle();
        player.cinemachineVirtualCameras[0].GetComponent<Animator>().SetBool("GameStart", true);
        StartCoroutine(Check());
        player.transform.position = new Vector3(0, 1, 0);
        
        
    }
    
}
