using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [Header("���뷽����")]
    public string cubeName;

    CubeManager m_cubeManager;
    Cube m_cube;
    
    void Awake()
    {
        m_cubeManager = CubeManager.GetInstance();
        m_cube = m_cubeManager.AddCube(cubeName);
        if (m_cube == null)
        {
            Debug.LogError("����ķ���������ȷ");
        }
    }

    public void Injured()
    {
        m_cube.health -= 1;
        if (m_cube.health <= 0)
        {
            Die();
        }
        return;
    }

    public void Die()
    {
        m_cubeManager.DeleteCube(m_cube);
        Destroy(gameObject);
        if (m_cubeManager.isEmpty())
        {
            Debug.LogError("��Ӯ��");
        }
        return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Injured();
        }
    }
}
