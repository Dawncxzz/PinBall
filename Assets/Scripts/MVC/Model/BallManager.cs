using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : BaseManager<BallManager>
{
    Ball m_ball;

    public BallManager()
    {
        if (m_ball == null)
        {
            m_ball = new Ball();
            m_ball.velocity = 0;
            m_ball.dir = new Vector2(0, 0);
        }
    }

    public Ball GetBall()
    {
        return m_ball;
    }

    public float GetVelocity()
    {
        return m_ball.velocity;
    }

    public void SetVelocity(float velocity)
    {
        m_ball.velocity = velocity;
    }

    public Vector2 GetDir()
    {
        return m_ball.dir;
    }

    public void SetDir(Vector2 dir)
    {
        m_ball.dir = dir;
    }
}

public class Ball
{
    public Ball() { }
    public float velocity { get; set; }
    public Vector2 dir { get; set; }
}
