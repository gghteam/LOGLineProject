using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stone : DropItem
{
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
            GameManager.Instance.EndGame();
            SceneManager.LoadScene("GameOverScene");
            SoundManager.Instance.OnSound(1, 0);
            GameManager.Instance.Judgment();
        }
    }
 

}
