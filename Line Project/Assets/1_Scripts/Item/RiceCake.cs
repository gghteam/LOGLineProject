using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceCake : MonoBehaviour
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
        if(collision.tag=="Player")
        {
            PoolManager.Instance.Despawn(gameObject);
        }
        else if(collision.tag=="STONE")
        {
            PoolManager.Instance.Despawn(gameObject);
        }
    }
}
