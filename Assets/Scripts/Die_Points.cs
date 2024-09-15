using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die_Points : MonoBehaviour
{
    public GameObject Die_Object;
    public Player player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.speed = 0;
            Die_Object.SetActive(true);
        }
    }
}
