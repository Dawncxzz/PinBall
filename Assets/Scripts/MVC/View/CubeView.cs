using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeView : MonoBehaviour
{
    CubeController m_cubeController;

    // Start is called before the first frame update
    void Start()
    {
        m_cubeController = GetComponent<CubeController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
