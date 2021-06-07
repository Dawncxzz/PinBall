using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ball¿ØÖÆÆ÷
/// </summary>
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
        if (tag == "Cube")
        {
            HitCube(CubeManager.GetInstance(), collision);
        }
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
            Debug.LogError("ÄãÊäÁË");
        }
    }

    public void HitPlayer(PlayerManager m_PlayManager)
    {
        Vector2 ballFactor = Vector2.Reflect(m_ballManager.GetDir(), new Vector2(0, 1)) * m_ballManager.GetVelocity();
        Vector2 playerFactor = m_PlayManager.GetDir() * m_PlayManager.GetVelocity();
        Vector2 newDir = (ballFactor + playerFactor).normalized;
        if ((ballFactor + playerFactor).y < 0)
        {
            newDir.y = ballFactor.y;
            newDir.Normalize();
        }
        m_ballManager.SetDir(newDir);
        float newVel = m_PlayManager.GetVelocity();
        m_ballManager.SetVelocity(newVel * velocity);
    }

    public void HitBoudary(Vector2 normal)
    {
        Vector2 newDir = Vector2.Reflect(m_ballManager.GetDir(), normal);
        m_ballManager.SetDir(newDir);
    }

    public void HitCube(CubeManager m_cubeManager, Collision2D cube)
    {
        Vector2 hitPos = cube.contacts[0].point;
        Vector2 cubePos = new Vector2(cube.transform.position.x, cube.transform.position.y);
        Vector2 dir = (hitPos - cubePos).normalized;
        float angleUp = Vector2.Angle(Vector2.up, dir);
        float angleDown = Vector2.Angle(Vector2.down, dir);
        float angleLeft = Vector2.Angle(Vector2.left, dir);
        float angleRight = Vector2.Angle(Vector2.right, dir);
        if (Mathf.Cos(Mathf.Deg2Rad * angleUp) >= (Mathf.Cos(Mathf.Deg2Rad * 45)))
        {
            m_ballManager.SetDir(Vector2.Reflect(m_ballManager.GetDir(), Vector2.up));
        }
        else if (Mathf.Cos(Mathf.Deg2Rad * angleDown) >= (Mathf.Cos(Mathf.Deg2Rad * 45)))
        {
            m_ballManager.SetDir(Vector2.Reflect(m_ballManager.GetDir(), Vector2.down));
        }
        else if (Mathf.Cos(Mathf.Deg2Rad * angleLeft) > (Mathf.Cos(Mathf.Deg2Rad * 45)))
        {
            m_ballManager.SetDir(Vector2.Reflect(m_ballManager.GetDir(), Vector2.left));
        }
        else if (Mathf.Cos(Mathf.Deg2Rad * angleRight) > (Mathf.Cos(Mathf.Deg2Rad * 45)))
        {
            m_ballManager.SetDir(Vector2.Reflect(m_ballManager.GetDir(), Vector2.right));
        }
        else
        {
            Debug.LogError("Åö×²´íÎó");
        }
    }
}
