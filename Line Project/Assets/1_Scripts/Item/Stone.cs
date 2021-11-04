using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stone : DropItem
{

    private void Start()
    {
        switch(GameManager.Instance.mode)
        {
            case 0:
                transform.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
                break;
            case 1:
                transform.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
                break;
            case 2:
                transform.GetComponent<Rigidbody2D>().gravityScale = 0.4f;
                break;
        }
    }
    private void Update()
    {
        if (gameObject.transform.position.y < -14f)
        {
            PoolManager.Instance.Despawn(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("돌");
            //호랑이따라오기
            GameManager.Instance.Judgment();
            SoundManager.Instance.SoundOn(2);
        }
    }
 

}
