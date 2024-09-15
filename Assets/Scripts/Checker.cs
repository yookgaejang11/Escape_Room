using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public GameObject Trap;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            Trap.SetActive(false);
        }
    }
}
