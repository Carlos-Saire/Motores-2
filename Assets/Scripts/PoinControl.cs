using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoinControl : MonoBehaviour
{
    public GameObject NexPoint;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().SetObjetive(NexPoint);
        }
    }
}
