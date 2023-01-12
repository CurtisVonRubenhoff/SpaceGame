using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CleverCrow.Fluid.Dialogues;

using ScriptableObjectArchitecture;

[CreateAssetMenu(menuName = "Game/Character")]
[System.Serializable]
public class Character : ActorDefinition
{
    public enum Rank
    {
        ENSIGN,
        LIEUTENANT_JG,
        LIEUTENANT,
        LT_COMMANDER,
        COMMANDER,
        DOCTOR,
        CAPTAIN
    }
    public Rank rank;
    public GameObject characterPrefab;
    public Vector3GameEvent movementEvent;
    public CharacterEvent selectionEvent;
    public InteractableEvent interactionEvent;
}
