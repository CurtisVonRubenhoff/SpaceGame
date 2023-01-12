using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum InteractableActions
{
    TALK,
    USE,
}

interface IInteractable
{
    public void Use()
    {

    }
}

public class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent _onUse;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseEnter()
    {
        Debug.Log($"Mouse over {gameObject.name}");
    }

    public void OnMouseExit()
    {
        Debug.Log($"Mouse left {gameObject.name}");
    }

    public void Use()
    {
        Debug.Log($"Using {gameObject.name}");
        _onUse.Invoke();
    }
}
