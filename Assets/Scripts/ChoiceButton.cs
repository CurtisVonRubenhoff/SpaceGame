using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

class ChoiceButton : MonoBehaviour
{
    public TMP_Text title;
    public Button button;
    public UnityEvent<int> clickEvent = new ActivateChoiceIndexEvent();

    private class ActivateChoiceIndexEvent : UnityEvent<int>
    {
    }

    private void Awake()
    {
        button.onClick.AddListener(() =>
        {
            clickEvent.Invoke(transform.GetSiblingIndex());
        });
    }
}