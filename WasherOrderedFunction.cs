using UnityEngine;
using UltimateXR.Manipulation;
using Utility;

public class WasherOrderedFunction : OrderedFunction

{
    [SerializeField] private UxrGrabbableObject pipe;
    [SerializeField] private UxrGrabbableObject m201;
    [SerializeField] private UxrGrabbableObject m202;
    [SerializeField] private UxrGrabbableObject washer1;
    [SerializeField] private UxrGrabbableObject washer2;
    [SerializeField] private UxrGrabbableObjectAnchor washeraanchor;
    [SerializeField] private bool isWasheraMounted;
    private bool _wasPlacedInPreviousFrame = false;


    public void Init()
    {
        DisableAllGrabbables();
        SetGrabbable(washer1, true, false);
        isWasheraMounted = false;
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
        if (washer1.CurrentAnchor == washeraanchor && _wasPlacedInPreviousFrame == false)
        {
            Debug.Log("Attaching Washer1");
            Debug.Log("Check");
            SetGrabbable(washer1, false, true);
            Debug.Log("Check1");
            isWasheraMounted = true;
            Debug.Log("Check2");
            OnExit();
        }
        else if (washer1.CurrentAnchor == null && _wasPlacedInPreviousFrame == true)
        {
            Debug.Log("Washera");
        }
        _wasPlacedInPreviousFrame = washer1.CurrentAnchor == washeraanchor;
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