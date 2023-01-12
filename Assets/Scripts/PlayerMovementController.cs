using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

using ScriptableObjectArchitecture;

public class PlayerMovementController : MonoBehaviour
{
    private DefaultControls _inputMapping;
    private Camera _camera;
    [SerializeField] private CharacterEvent _characterSelectEvent;
    [SerializeField] private GameObject _pauseUI;

    [SerializeField] private List<Character> _party = new List<Character>();
    private Character _selectedCharacter;

    private void Awake() => _inputMapping = new DefaultControls();
    void Start()
    {
        _inputMapping.Game.Interact.performed += Interact;
        _inputMapping.Game.Pause.performed += Pause;


        _camera = Camera.main;

        _characterSelectEvent.AddListener(SelectCharacter);
    }
    private void Update()
    {

    }

    private void OnEnable() => _inputMapping.Enable();
    private void OnDisable() => _inputMapping.Disable();

    private void Pause(InputAction.CallbackContext context)
    {
        _pauseUI.SetActive(!_pauseUI.activeSelf);
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (_selectedCharacter is null)
        {
            return;
        }

        Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit, 50f))
        {
            if (NavMesh.SamplePosition(hit.point, out UnityEngine.AI.NavMeshHit navPos, .25f, 1 << 0))
            {
                _selectedCharacter.movementEvent.Raise(navPos.position);
            }

            if (hit.collider.gameObject.tag == "Interactable")
            {
                Debug.Log("do something.");
                var _interactableToUse = hit.collider.gameObject.GetComponent<Interactable>();
                //_agent.SetDestination(hit.point);
                _selectedCharacter.movementEvent.Raise(hit.point);
                _selectedCharacter.interactionEvent.Raise(_interactableToUse);

                //_isMoving = true;
            }
        }
    }

    public void SelectCharacter(Character i_character)
    {
        _selectedCharacter = i_character;
    }
}