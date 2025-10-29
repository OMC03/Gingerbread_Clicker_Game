using UnityEngine;

public class HighlightTrigger : MonoBehaviour
{
    public Animator externalAnimator;

    public void TriggerHightlight()
    {
        externalAnimator.SetTrigger("Highlighted");
    }
}
