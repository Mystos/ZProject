﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact();

    public abstract void ShowInteractionInterface();

    public abstract void HideInteractionInterface();

}
