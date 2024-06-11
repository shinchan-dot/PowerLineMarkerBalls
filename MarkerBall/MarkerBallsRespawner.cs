
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

[UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
public class MarkerBallsRespawner : UdonSharpBehaviour
{

    public Transform MarkerBallsParent;

    public override void Interact()
    {
        float x = 0;
        foreach(Transform ball in MarkerBallsParent)
        {
            Networking.SetOwner(Networking.LocalPlayer, ball.gameObject);
            ball.localPosition = new Vector3(x, 0, 0);
            x += 2;
        }
    }

}
