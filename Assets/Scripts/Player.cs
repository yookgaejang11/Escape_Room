using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigid;
    public float radius;
    public LayerMask targetLayer;
    public Vector3 MoveVector
    {
        get
        {
            return new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            getNpcs();
        }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rigid.velocity = MoveVector * speed;
    }
    public void getNpcs()
    {
        RaycastHit2D[] hits = Physics2D.CapsuleCastAll(transform.position, Vector2.one * radius, 0, 0, Vector2.up, 0, targetLayer);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] != null)
            {
                if (hits[i].transform.TryGetComponent(out Npc npc))
                {
                    Debug.Log(npc.chat);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
