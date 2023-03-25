using UnityEngine;
using UltimateXR.Manipulation;
using Utility;

public class WasherbOrderedFunction : OrderedFunction

{
    [SerializeField] private UxrGrabbableObject pipe;
    [SerializeField] private UxrGrabbableObject m201;
    [SerializeField] private UxrGrabbableObject m202;
    [SerializeField] private UxrGrabbableObject washer1;
    [SerializeField] private UxrGrabbableObject washer2;
    [SerializeField] private UxrGrabbableObjectAnchor washerbanchor;
    [SerializeField] private bool isWasherbMounted;
    private bool _wasPlacedInPreviousFrame = false;


    public void Init()
    {
        DisableAllGrabbables();
        SetGrabbable(washer2, true, false);
        isWasherbMounted = false;
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
        if (washer2.CurrentAnchor == washerbanchor && _wasPlacedInPreviousFrame == false)
        {
            Debug.Log("Attaching Washer2");
            Debug.Log("Check");
            SetGrabbable(washer2, false, true);
            Debug.Log("Check1");
            isWasherbMounted = true;
            Debug.Log("Check2");
            OnExit();
        }
        else if (washer2.CurrentAnchor == null && _wasPlacedInPreviousFrame == true)
        {
            Debug.Log("Washerb");
        }
        _wasPlacedInPreviousFrame = washer2.CurrentAnchor == washerbanchor;
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