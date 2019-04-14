using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The 'Memento' class
/// </summary>
public class Memento
{
    private string _state;
    // Constructor
    public Memento(string state)
    {
        this._state = state;
    }

    // Gets or sets state
    public string State
    {
        get { return _state; }
    }
}
