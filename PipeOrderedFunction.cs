using UnityEngine;
using UltimateXR.Manipulation;
using Utility;
using System.Collections.Generic;

public class PipeOrderedFunction : OrderedFunction

{
    [SerializeField] private UxrGrabbableObject pipe;
    [SerializeField] private UxrGrabbableObject m201;
    [SerializeField] private UxrGrabbableObject m202;
    [SerializeField] private UxrGrabbableObject washer1;
    [SerializeField] private UxrGrabbableObject washer2;
    [SerializeField] private UxrGrabbableObjectAnchor pipeanchor;
    [SerializeField] private bool isPipeMounted;
    [SerializeField] private List<Renderer> renderers;
    [SerializeField] private Color color = Color.white;
    
    private bool _wasPlacedInPreviousFrame = false;
    private List<Material> materials;


    public void Init()
    {
        DisableAllGrabbables();
        SetGrabbable(pipe, true, false);
        isPipeMounted = false;
        Debug.Log("test");
    }

    public void DisableAllGrabbables()
    {
        SetGrabbable(pipe, false, true);
        SetGrabbable(m201, false, true);
        SetGrabbable(m202, false, true);
        SetGrabbable(washer1, false, true);
        SetGrabbable(washer2, false, true);
    }

    private static void SetGrabbable(UxrGrabbableObject _grabbable, bool _isGrabbable, bool _isLocked)
    {
        _grabbable.IsGrabbable = _isGrabbable;
        _grabbable.IsLockedInPlace = _isLocked;
    }

    void Update()
    {
        /*if (isPipeMounted == false)
        {
                //material.EnableKeyword("_EMISSION");
                pipeanchor.material.SetColor("_EmissionColor", color);
        }
        else
        {
                material.DisableKeyword("_EMISSION");
        }*/

        if (pipe.CurrentAnchor == pipeanchor && _wasPlacedInPreviousFrame == false)
        {
            Debug.Log("Attaching Pipe");
            Debug.Log("Check");
            SetGrabbable(pipe, false, true);
            Debug.Log("Check1");
            isPipeMounted = true;
            Debug.Log("Check2");
            OnExit();
        }
        else if (pipe.CurrentAnchor == null && _wasPlacedInPreviousFrame == true)
        {
            Debug.Log("Pipe");
        }

        _wasPlacedInPreviousFrame = pipe.CurrentAnchor == pipeanchor;
    }

    public override void OnEntry()
    {
        Init();
        Debug.Log($"{gameObject.name} used its OnEntry method.");
        OnUpdate();
    }

    public override void OnUpdate()
    {
        Debug.Log($"{gameObject.name} used its OnUpdate method.");
        Update();
    }

    public override void OnExit()
    {
        Debug.Log($"{gameObject.name} used its OnExit method.");
        OrderedFunctionManager.NextFunction();
    }
}