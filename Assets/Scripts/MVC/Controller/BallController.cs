using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Range(0, 1)]
    public float velocity;

    BallManager m_ballManager;
    BallView m_ballView;

    void Awake()
    {
        Time.timeScale = 3;
        m_ballManager = BallManager.GetInstance();
    }

    void FixedUpdate()
    {
       
        Move();
    }

    public void Move()
    {
        float vel = m_ballManager.GetVelocity();
        Vector2 dir = m_ballManager.GetDir();
        transform.Translate(dir * vel * velocity, Space.World);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Player")
        {
            HitPlayer(PlayerManager.GetInstance());
        }
        if (tag == "WallLeft")
        {
            HitBoudary(new Vector2(1, 0));
        }
        if (tag == "WallRight")
        {
            HitBoudary(new Vector2(-1, 0));
        }
        if (tag == "WallUp")
        {
            HitBoudary(new Vector2(0, -1));
        }
        if (tag == "WallDown")
        {
            Debug.LogError("ƒ„ ‰¡À");
        }
    }

    public void HitPlayer(PlayerManager m_PlayManager)
    {
        Vector2 ballFactor = Vector2.Reflect(m_ballManager.GetDir(), new Vector2(0, 1)) * m_ballManager.GetVelocity();
        Vector2 playerFactor = m_PlayManager.GetDir() * m_PlayManager.GetVelocity();
        Vector2 newDir = (ballFactor + playerFactor).normalized;
        m_ballManager.SetDir(newDir);
        float newVel = m_PlayManager.GetVelocity();
        m_ballManager.SetVelocity(newVel * velocity);
    }

    public void HitBoudary(Vector2 normal)
    {
        Vector2 newDir = Vector2.Reflect(m_ballManager.GetDir(), normal);
        m_ballManager.SetDir(newDir);
    }
}
