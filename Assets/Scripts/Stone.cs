using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public bool instone = false;
    Rigidbody2D rigid;
    public Player player; // Player ������Ʈ�� �����մϴ�.
    public GameObject Key;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        
        // Player�� �Ҵ�Ǿ����� Ȯ���մϴ�.
        if (player == null)
        {
            Debug.LogError("Player object is not assigned in Stone script.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CheckPoint") && instone == false)
        {
            if (player != null)
            {
                instone = true;
                player.keyCount++;
                Debug.Log("keyCount increased to: " + player.keyCount);
            }
            else
            {
                Debug.LogError("Player is not assigned.");
            }
        }
    }
    private void FixedUpdate()
    {
        rigid.angularVelocity = 0f;
    }

}
