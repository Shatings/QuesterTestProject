using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Animator ani;
    public GameObject effect;


    public void anibool(int _index)
    {

        ani.SetBool("Find", (_index > 0 ? true : false));

    }
    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<PlayerMove>().find)
            {
                GameStat.gamest.SetValue(1, -1);
                GameStat.gamest.obstaclecount--;
                Debug.Log(GameStat.gamest.GetValue(1));
                effect.SetActive(false);
                StartCoroutine(Anion());
            }

        }
    }
    IEnumerator Anion()
    {
        GameStat.gamest.FindOb(ani, this.gameObject);

        yield return new WaitUntil(() => !ani.GetBool("Find"));

        this.gameObject.SetActive(false);
    }
}
