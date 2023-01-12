using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MovingPawn : MonoBehaviour
{
    private NavMeshAgent _agent;
    private float _rotateSpeed = 5f;
    private bool _needToRotate = false;
    private Vector3 _moveTarget = Vector3.zero;
    private Vector3 _direction = Vector3.zero;
    private Quaternion _lookRotation = Quaternion.identity;
    private bool _isMoving = false;

    private Interactable _interactableToUse;

    [SerializeField] private InteractableEvent _interactableEvent;


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _interactableEvent.AddListener(SetNextInteraction);
    }

    // Update is called once per frame
    void Update()
    {
        if (_needToRotate)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                 _lookRotation, Time.deltaTime * _rotateSpeed);
            if (Vector3.Dot(_direction, transform.forward) >= 0.97)
            {
                _needToRotate = false;
            }
        }

        if (_isMoving)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                _isMoving = false;
                TriggerEventOnDestination();
            }
        }
    }

    private void TriggerEventOnDestination()
    {
        if (_interactableToUse is not null)
        {
            _interactableToUse.Use();
            _interactableToUse = null;
        }
    }

    public void MoveToPoint(Vector3 i_moveTarget)
    {
        _moveTarget = i_moveTarget;
        _direction = (new Vector3(_moveTarget.x, 0, _moveTarget.z) - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        _needToRotate = true;

        _agent.SetDestination(_moveTarget);
        _isMoving = true;
    }

    public void SetNextInteraction(Interactable i_interactable)
    {
        _interactableToUse = i_interactable;
    }
}
