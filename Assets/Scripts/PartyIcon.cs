using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ScriptableObjectArchitecture;

public class PartyIcon : MonoBehaviour
{
    [SerializeField] private Image _characterPortrait;
    [SerializeField] private Image _selectionIndicator;

    [SerializeField] private Character _character;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }


    public void SetCharacter(Character i_character)
    {
        _character = i_character;
        _characterPortrait.sprite = i_character.Portrait;
    }
}
