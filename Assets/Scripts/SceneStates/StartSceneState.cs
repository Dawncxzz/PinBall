using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneState : SceneState
{
    public StartSceneState(SceneStateManager ssc) : base(ssc)
    {
        this.StateName = "StartSceneState";
    }
    public override void StateBegin()
    {
        base.StateBegin();
    }
    public override void StateUpdate()
    {
        m_Controller.SetState(new GameSceneState(m_Controller), "GameScene ");
        base.StateUpdate();
    }
    public override void StateEnd()
    {
        base.StateEnd(); 
    }
}
