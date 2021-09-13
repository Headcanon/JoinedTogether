using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    event Action<int> Move;
    event Action<float> Jump;
    event Action Fail;
}
