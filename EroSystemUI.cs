using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cinemachine;
using UnityEngine.Rendering;

public class EroSystemUI : BaseUIState
{
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private GameObject player;
    public GameObject mainCam;
    public GameObject eroCam;


    private List<Button> PoseButtons;
    private Button FirstPersonViewButton;
    private Button ThirdPersonViewButton;

    public override void Awake()
    {
        base.Awake();


        // Pose按钮
        PoseButtons = new List<Button>
        {
            _document.rootVisualElement.Q<Button>("Pose1"),
            _document.rootVisualElement.Q<Button>("Pose2"),
            _document.rootVisualElement.Q<Button>("Pose3")
        };
        // 注册按钮点击事件
        for (int i = 0; i < PoseButtons.Count; i++)
        {
            var button = PoseButtons[i];
            int capturedID = i + 1; // 从1开始编号，每个按钮对应一个动画 ID

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


        //View按钮
        FirstPersonViewButton = _document.rootVisualElement.Q("FirstPersonView") as Button;
        FirstPersonViewButton.RegisterCallback<ClickEvent>(evt =>
        {
            Debug.Log("First Person View Button Clicked");
        });

        ThirdPersonViewButton = _document.rootVisualElement.Q("ThirdPersonView") as Button;
        ThirdPersonViewButton.RegisterCallback<ClickEvent>(evt =>
        {
            Debug.Log("Third Person View Button Clicked");
            eroCam.GetComponent<CinemachineFreeLook>().Follow = character.transform;
            eroCam.GetComponent<CinemachineFreeLook>().LookAt = character.transform;
        });

    }

    public override void Start()
    {
        base.Start();
        character.GetComponent<Animator>().SetTrigger("ero");
        //player.GetComponent<PlayerMove>().enabled=false;
        player.gameObject.SetActive(false);
        eroCam.SetActive(true);
        mainCam.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed, changing state to Main");
            _UIStateMachine.ChangeState(UIStateMachine.UIState.Main);
        }
    }
    public virtual void OnDisable()
    {
        base.OnDisable();
        //恢复相机
        player.gameObject.SetActive(true);
        eroCam.SetActive(false);
        mainCam.SetActive(true);
    }

}
