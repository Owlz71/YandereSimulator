using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DebugUI : BaseUIState
{

    private Button EroSysEnterButton;
    public virtual void Awake()
    {
        base.Awake();

        EroSysEnterButton = _document.rootVisualElement.Q("AnimationButton") as Button;
        if (EroSysEnterButton == null)
        {
            Debug.LogError("AnimationButton not found in the UI Document.");
            return;
        }
        EroSysEnterButton.RegisterCallback<ClickEvent>(OnEroSystemClick);



    }

    public override void OnDisable()
    {
        base.OnDisable();   
        EroSysEnterButton.UnregisterCallback<ClickEvent>(OnEroSystemClick);
    }

    private void OnEroSystemClick(ClickEvent evt)
    {
        Debug.Log("Animation System Button Clicked");
        _UIStateMachine.ChangeState(UIStateMachine.UIState.EroSystem);
    }


}
