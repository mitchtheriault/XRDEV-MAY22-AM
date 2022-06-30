using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XRInputReader : MonoBehaviour
{
    XRIDefaultInputActions inputActions;

    public InputAction myAction;

    

    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new XRIDefaultInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }


    // Update is called once per frame
    void Update()
    {

        float triggerVal = inputActions.XRIRightHandInteraction.ActivateValue.ReadValue<float>();
        print(triggerVal);

        if (triggerVal > 0.5f)
        {
            //do some stuff
        }


        bool trigger = inputActions.XRIRightHandInteraction.Activate.triggered;
        print(trigger);

        if (trigger == true)
        {
            //do more stuff
        }

    }

}
