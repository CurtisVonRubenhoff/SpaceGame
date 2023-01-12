using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    [CreateAssetMenu(menuName = "Game/CharacterEvent")]
    public class CharacterEvent : GameEventBase<Character>
    {

    }

    public class CharacterUnityEvent : UnityEvent<Character> { }
}