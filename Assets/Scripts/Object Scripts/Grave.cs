using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : Object
{

    public override string[] getMessage()
    {
        return stringToArray("You look at the grave. It's old and weathered, and the words etched into the stone are worn and faded. You don't even bother trying to make out what they say.");
    }
}
