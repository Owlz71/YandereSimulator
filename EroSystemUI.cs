using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cinemachine;

public class EroSystemUI : BaseUIState
{
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private GameObject player;
    public CinemachineFreeLook cam;


    private List<Button> PoseButtons;
    private Button FirstPersonViewButton;
    private Button ThirdPersonViewButton;

    public override void Awake()
    {
        base.Awake();


        // Pose��ť
        PoseButtons = new List<Button>
        {
            _document.rootVisualElement.Q<Button>("Pose1"),
            _document.rootVisualElement.Q<Button>("Pose2"),
            _document.rootVisualElement.Q<Button>("Pose3")
        };
        // ע�ᰴť����¼�
        for (int i = 0; i < PoseButtons.Count; i++)
        {
            var button = PoseButtons[i];
            int capturedID = i + 1; // ��1��ʼ��ţ�ÿ����ť��Ӧһ������ ID

            if (button == null)
            {
                Debug.LogError($"Pose button {i + 1} not found in the UI Document.");
                continue;
            }

            button.RegisterCallback<ClickEvent>(evt =>
            {
                Debug.Log($"Pose Button {capturedID} Clicked");
                character.GetComponent<Animator>().SetInteger("ani_id", capturedID);
            });
        }

        FirstPersonViewButton = _document.rootVisualElement.Q("FirstPersonView") as Button;
        FirstPersonViewButton.RegisterCallback<ClickEvent>(evt =>
        {
            Debug.Log("First Person View Button Clicked");
        });

        ThirdPersonViewButton = _document.rootVisualElement.Q("ThirdPersonView") as Button;
        ThirdPersonViewButton.RegisterCallback<ClickEvent>(evt => {
            Debug.Log("Third Person View Button Clicked");
            cam.Follow = character.transform;
            cam.LookAt = character.transform;
        });

    }

    public override void Start()
    {
        base.Start();
        character.GetComponent<Animator>().SetTrigger("ero");


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed, changing state to Main");
            _UIStateMachine.ChangeState(UIStateMachine.UIState.Main);
        }
    }


}
