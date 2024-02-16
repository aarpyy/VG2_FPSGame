using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterClass
{
    private string characterClassName;
    private string characterClassDescription;

    //stats
    //private struct stats { }

    //abilities
    private bool doubleJump;
    private bool dash;

    public string CharacterClassName
    {
        get { return characterClassName; }
        set { characterClassName = value; }
    }
    public string CharacterClassDescription
    {
        get { return characterClassDescription; }
        set { characterClassDescription = value; }
    }

    public bool DoubleJump
    {
        get { return doubleJump; }
        set { doubleJump = value; }
    }

    public bool Dash
    {
        get { return dash; }
        set { dash = value; }
    }


    
}
