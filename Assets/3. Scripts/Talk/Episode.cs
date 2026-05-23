using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Episode : ScriptableObject
{
    public Speaker[] speakers;

    public string[] texts;
}
