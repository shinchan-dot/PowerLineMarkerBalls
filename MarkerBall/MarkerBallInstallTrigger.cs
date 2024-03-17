
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;

[UdonBehaviourSyncMode(BehaviourSyncMode.Continuous)]

public class MarkerBallInstallTrigger : UdonSharpBehaviour
{
    public VRCObjectSync MarkerBallObjectSync;
    public ParticleSystem ProgressParticle;
    public float OperationInitialDelay = 1;
    public float OperationDelay = 0.5f;
    public int WireLayer = 29;
    private float LastOperationTime = 0;
    private int NumTriggers = 0;
    private bool OnWire;
    private Collider ThisCollider;
    private bool Initialized = false;
    private float Progress = 0;
    private float ProgressMax = 10;
    private bool Installed = false;
    private void Initialize()
    {
        ThisCollider = gameObject.GetComponent<Collider>();
    }
    private void Update()
    {
        if (OnWire && !Installed)
        {
            if (Time.time - LastOperationTime > OperationDelay)
            {
                LastOperationTime = Time.time;
                Progress += OperationDelay;

                if (Progress > ProgressMax)
                {
                    MarkerBallObjectSync.SetKinematic(true);
                    Installed = true;
                    ProgressParticle.Stop();
                }
            }

            if (!ProgressParticle.isPlaying)
            {
                ProgressParticle.Play();
            }
        }

        if (!OnWire)
        {
            Progress = 0;
            ProgressParticle.Stop();
            ProgressParticle.Clear();

            if (Installed)
            {
                Installed = false;
                MarkerBallObjectSync.SetKinematic(false);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other && other.gameObject.layer == WireLayer)
        {
            float tim = Time.time;
            if (NumTriggers == 0) {
                LastOperationTime = Mathf.Min((tim + OperationDelay) - OperationInitialDelay, tim);
            }
            NumTriggers += 1;
            OnWire = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other && other.gameObject.layer == WireLayer)
        {
            NumTriggers -= 1;
            if (NumTriggers == 0)
            {
                OnWire = false;
            }
        }
    }
    //collider enabled and disabled so that it does ontriggerenter on enable
    private void OnEnable()
    {
        if (!Initialized) { Initialize(); }
        ThisCollider.enabled = true;
    }
    private void OnDisable()
    {
        ThisCollider.enabled = false;
        OnWire = false;
        NumTriggers = 0;
    }
    
}
