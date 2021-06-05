using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1,10)]
    public float velocity;

    Rigidbody2D rigidbody2d;
    PlayerView m_PlayerView;
    PlayerManager m_playerManager;
    Vector3 offset;
    bool isDragging;
    //边界字典（测试用）
    Dictionary<string, float> dirValue = new Dictionary<string, float>{ { "left",float.MinValue }, { "right", float.MaxValue },
        {  "up", float.MaxValue }, {  "down", float.MinValue }};

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        m_playerManager = PlayerManager.GetInstance();
    }

    private void FixedUpdate()
    {
        Move();
    }

    //物体移动
    public void Move()
    {
        if (isDragging)
        {
            Vector3 newPos;
            newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)) - offset;
            newPos.x = Mathf.Clamp(newPos.x, (float)-3.529546, (float)3.549547);
            newPos.y = Mathf.Clamp(newPos.y, (float)-5.512787, (float)0.530581);
            //newPos.x = Mathf.Clamp(newPos.x, dirValue["left"], dirValue["right"]);
            //newPos.y = Mathf.Clamp(newPos.y, dirValue["down"], dirValue["up"]);
            transform.position = Vector3.Lerp(transform.position, newPos, velocity * Time.deltaTime);
            Vector2 dir = new Vector2(newPos.x, newPos.y) - new Vector2(transform.position.x, transform.position.y);
            float vel = Mathf.Sqrt(Mathf.Pow(newPos.x - transform.position.x,2) + Mathf.Pow(newPos.y - transform.position.y, 2));
            m_playerManager.SetVelocity(vel);
            m_playerManager.SetDir(dir.normalized);
        }
    }

    //鼠标选取拖拽物体
    void OnMouseDown()
    {
        isDragging = true;
        offset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)) - transform.position;
    }
    void OnMouseUp()
    {
        isDragging = false;
    }

    //边缘碰撞检测（测试用）
    void OnCollisionStay2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "WallLeft")
        {
            if (dirValue["left"] < transform.position.x)
            {
                dirValue["left"] = transform.position.x;
            }
        }
        else if (collision2D.gameObject.tag == "WallRight")
        {
            if (dirValue["right"] > transform.position.x)
            {
                dirValue["right"] = transform.position.x;
            }
        }
        if (collision2D.gameObject.tag == "WallUp")
        {
            if (dirValue["up"] > transform.position.y)
            {
                dirValue["up"] = transform.position.y;
            }
        }
        else if(collision2D.gameObject.tag == "WallDown")
        {
            if (dirValue["down"] < transform.position.y)
            {
                dirValue["down"] = transform.position.y;
            }
        }
        Debug.Log("left:" + dirValue["left"] + " right:" + dirValue["right"] + " up:" + dirValue["up"] + " down:" + dirValue["down"]);
    }

    public void HitBoundary()
    { 
        
    }

}
