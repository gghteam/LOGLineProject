using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : DropItem
{
    private void Update()
    {
        if (gameObject.transform.position.y < -6f)
        {
            PoolManager.Instance.Despawn(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("��");
            //ȣ���̵������
        }
    }
 

}
