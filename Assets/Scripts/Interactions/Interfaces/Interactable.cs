public interface Interactable
{

    float maxRange {get;}

    // float HoldDuration {get;}
    // bool HoldToInteract {get;}
    // bool MultipleUse {get;}
    // bool IsInteractable {get;}

    void OnHoverStart();
    void OnInteract();
    void OnHoverEnd();
    
}