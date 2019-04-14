using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The 'Caretaker' class
/// </summary>
public class Caretaker
{
    private Memento _memento;
    // Gets or sets memento
    public Memento Memento
    {
        set { _memento = value; }
        get { return _memento; }
    }


}