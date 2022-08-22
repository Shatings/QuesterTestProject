using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public Animator ani;
    public GameObject effect;

    private void Start()
    {
      
        ani = GetComponent<Animator>();
    }
    public void anibool(int _index)
    {
        ani.SetBool("Find", (_index>0 ? true : false));

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<PlayerMove>().find)
            {
                GameStat.gamest.SetValue(0, Mathf.Ceil(GameStat.gamest.RandomPot(10, 100f)));
                GameStat.gamest.treasureboxcount--;
                Debug.Log(GameStat.gamest.GetValue(0));
                effect.SetActive(false);
                StartCoroutine(Anion());
            }
         
        }
    }
    IEnumerator Anion()
    {
        GameStat.gamest.FindOb(ani,this.gameObject);

        yield return new WaitUntil(() => !ani.GetBool("Find"));

        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update

}
