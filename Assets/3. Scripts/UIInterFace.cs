using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInterFace : MonoBehaviour
{
    public interface IData
    {
        Division divison { get; set; }

        float hogamdo { get; set; }
    }
}
