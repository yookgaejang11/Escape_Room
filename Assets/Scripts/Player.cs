using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject RealExit;
    public GameObject Die_Object1;
    public GameObject Die_Object2;
    public GameObject Die_Object3;
    public GameObject Chat;
    public bool openChat = false;
    public GameObject exitText;
    public GameObject signObject;
    public bool ActiveSign;
    public GameObject objectKey;
    public int keyCount = 0;
    public GameManager manager;
    public bool isTouchTop;
    public bool isTouchLeft;
    public bool isTouchRight;
    public bool isTouchBottom;
    public float speed;
    Rigidbody2D rigid;
    public float radius;
    [Header("Target Layers")]
    public LayerMask Key;
    public LayerMask door;
    public LayerMask Signs;
    public LayerMask Stones;
    public LayerMask Ghost;
    public LayerMask Real_Exit;
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
            Exit();
            getKeys();
            ActiveSigns();
            OpenDoors();
            chatGhost();
        }
        
    }

    private void Awake()
    {
        Time.timeScale = 1f;
        rigid = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rigid.velocity = MoveVector * speed;
    }
    public void getKeys()
    {
        RaycastHit2D[] hits = Physics2D.CapsuleCastAll(transform.position, Vector2.one * radius, 0, 0, Vector2.up, 0, Key);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] != null)
            {
                objectKey.SetActive(false);
                keyCount++;
                
            }
        }
    }
    public void ActiveSigns()
    {
        RaycastHit2D[] hits = Physics2D.CapsuleCastAll(transform.position, Vector2.one * radius, 0, 0, Vector2.up, 0, Signs);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] != null)
            {
                if (ActiveSign == true)
                {
                    signObject.SetActive(false);
                    ActiveSign = false;
                }
                else
                {
                    
                    signObject.SetActive(true);
                    ActiveSign = true;
                }

            }
        }
    }
    public void OpenDoors()
    {
        RaycastHit2D[] hits = Physics2D.CapsuleCastAll(transform.position, Vector2.one * radius, 0, 0, Vector2.up, 0, door);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] != null && manager.notOpenCheck == false)
            {
                exitText.SetActive(true);

            }
            else if(manager.notOpenCheck == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("°¨Áö");
                    manager.notOpen.SetActive(false);
                    manager.notOpenCheck = false;
                }
            }
        }
    }
    public void chatGhost()
    {
        RaycastHit2D[] hits = Physics2D.CapsuleCastAll(transform.position, Vector2.one * radius, 0, 0, Vector2.up, 0, Ghost);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] != null && openChat == false)
            {

                openChat = true;
                Chat.SetActive(true);
                    
            } else if (openChat == true)
            {
                openChat = false;
                Chat.SetActive(false);
            }
        }
    }

    public void Exit()
    {
        RaycastHit2D[] hits = Physics2D.CapsuleCastAll(transform.position, Vector2.one * radius, 0, 0, Vector2.up, 0, Real_Exit);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] != null && keyCount == 30)
            {
                RealExit.SetActive(true);

            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trap")
        {
            manager.Trap();
        }

        if (other.gameObject.tag == "Clear_Point")
        {
            keyCount = 30;
        }
        else if (other.gameObject.name == "Die (1)")
        {
            speed = 0;
            Die_Object1.SetActive(true);
        }
        else if (other.gameObject.name == "Die (2)")
        {
            speed = 0;
            Die_Object2.SetActive(true);
        }
        else if (other.gameObject.name == "Die (3)")
        {
            speed = 0;
            Die_Object3.SetActive(true);
        }
    }
}
