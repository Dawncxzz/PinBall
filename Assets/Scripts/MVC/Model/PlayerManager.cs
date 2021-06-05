using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : BaseManager<PlayerManager>
{
    Player m_Player;

    public PlayerManager()
    {
        if (m_Player == null)
        {
            m_Player = new Player();
            m_Player.health = 10;
            m_Player.velocity = 0;
            m_Player.dir = new Vector2(0, 0);
        }
    }

    public Player GetPlayer()
    {
        return m_Player;
    }

    public int GetHealth()
    {
        return m_Player.health;
    }

    public void SetHealth(int health)
    {
        m_Player.health = health;
    }

    public float GetVelocity()
    {
        return m_Player.velocity;
    }

    public void SetVelocity(float velocity)
    {
        m_Player.velocity = velocity;
    }

    public Vector2 GetDir()
    {
        return m_Player.dir;
    }

    public void SetDir(Vector2 dir)
    {
        m_Player.dir = dir;
    }
}

public class Player
{
    public Player() { }
    public int health { get; set; }
    public float velocity { get; set; }
    public Vector2 dir { get; set; }
}
