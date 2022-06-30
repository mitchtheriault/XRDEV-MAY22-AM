using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyPart : MonoBehaviour
{
    public Image bodyPartUI;

    public void OnBodyPartFound()
    {
        bodyPartUI.color = new Color(1, 1, 1, 1);
    }

}
