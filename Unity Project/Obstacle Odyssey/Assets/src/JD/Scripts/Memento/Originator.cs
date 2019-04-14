using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The 'Originator' class
/// </summary>
public class Originator
{
    private string _state;

    // Property
    public string State
    {
        get { return _state; }
        set
        {
            _state = value;
            Debug.Log("State = " + _state);
        }
    }

    // Creates memento 
    public Memento CreateMemento()
    {
        return (new Memento(_state));
    }

    // Restores original state
    public void SetMemento(Memento memento)
    {
        Debug.Log("Restoring state...");
        State = memento.State;
    }
}