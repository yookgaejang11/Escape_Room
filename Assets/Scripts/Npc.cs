using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [TextArea]
    SpriteRenderer spriteRenderer;
    public string chat;
    public float minDistance;
    public Transform Player;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, Player.position) < minDistance)
        {
            spriteRenderer.color = Color.black;
        }
        else
        {
            spriteRenderer.color = Color.cyan;
        }
    }
}
