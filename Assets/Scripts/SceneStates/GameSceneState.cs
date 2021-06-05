using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneState : SceneState
{
    public GameSceneState(SceneStateManager ssc) : base(ssc)
    {
        this.StateName = "GameSceneState";
    }
    public override void StateBegin()
    {
        base.StateBegin();
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
    }
    public override void StateEnd()
    {
        base.StateEnd();
    }
}
