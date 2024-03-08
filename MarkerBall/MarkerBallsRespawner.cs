
using UdonSharp;
using UnityEngine;

[UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
public class MarkerBallsRespawner : UdonSharpBehaviour
{

    public Transform MarkerBallsParent;

    public override void Interact()
    {
        float x = 0;
        foreach(Transform ball in MarkerBallsParent)
        {
            ball.localPosition = new Vector3(x, 0, 0);
            x += 2;
        }
    }

}
