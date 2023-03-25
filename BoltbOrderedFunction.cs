using UnityEngine;
using UltimateXR.Manipulation;
using Utility;

public class BoltbOrderedFunction : OrderedFunction

{
    [SerializeField] private UxrGrabbableObject pipe;
    [SerializeField] private UxrGrabbableObject m201;
    [SerializeField] private UxrGrabbableObject m202;
    [SerializeField] private UxrGrabbableObject washer1;
    [SerializeField] private UxrGrabbableObject washer2;
    [SerializeField] private UxrGrabbableObjectAnchor boltbanchor;
    [SerializeField] private bool isBoltbMounted;
    private bool _wasPlacedInPreviousFrame = false;


    public void Init()
    {
        DisableAllGrabbables();
        SetGrabbable(m202, true, false);
        isBoltbMounted = false;
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
        if (m202.CurrentAnchor == boltbanchor && _wasPlacedInPreviousFrame == false)
        {
            Debug.Log("Attaching Pipe");
            Debug.Log("Check");
            SetGrabbable(m202, false, true);
            Debug.Log("Check1");
            isBoltbMounted = true;
            Debug.Log("Check2");
            OnExit();
        }
        else if (m202.CurrentAnchor == null && _wasPlacedInPreviousFrame == true)
        {
            Debug.Log("Bolta");
        }
        _wasPlacedInPreviousFrame = m202.CurrentAnchor == boltbanchor;
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
