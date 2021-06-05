using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneState
{
    private string m_StateName = "ISceneState";
    public string StateName
    {
        get { return m_StateName; }
        set { m_StateName = value; }
    }
    protected SceneStateManager m_Controller = null;
    public SceneState() { }
    public SceneState(SceneStateManager ssc)
    {
        m_Controller = ssc;
    }
    public virtual void StateBegin() { }
    public virtual void StateEnd() { }
    public virtual void StateUpdate() { }
}
