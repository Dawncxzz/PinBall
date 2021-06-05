using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : BaseManager<SceneStateManager>
{
    private SceneState m_State;
    bool isBegin = false;
    public SceneStateManager(){}
    public void SetState(SceneState state, string loadSceneName)
    {
        isBegin = false;
        LoadScene(loadSceneName);
        if (m_State != null)
        {
            m_State.StateEnd();
        }
    }
    private void LoadScene(string loadSceneName)
    {
        if (loadSceneName == null || loadSceneName.Length == 0)
        {
            return;
        }
        SceneManager.LoadScene(loadSceneName);
    }
    public void StateUpdate()
    {
        if (m_State != null && isBegin == false)
        {
            m_State.StateBegin();
            isBegin = true;
        }
        if (m_State != null)
        {
            m_State.StateUpdate();
        }
    }
}
