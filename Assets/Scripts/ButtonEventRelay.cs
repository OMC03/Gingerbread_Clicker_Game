using UnityEngine;

public class ButtonEventRelay : MonoBehaviour
{
    public HighlightTrigger highlightSync;

    public void TriggerExternalHighlight()
    {
        if (highlightSync != null)
        {
            highlightSync.TriggerHightlight();
        }
    }
}
