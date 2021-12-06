using UnityEngine;
using UnityEngine.UIElements;

public struct TimeFormat {
    public TimeFormat(float time) {
        minutes = Mathf.FloorToInt(time / 60);
        hours = minutes / 60;
    }

    public override string ToString() {
        return $"{hours:00}:{minutes:00}";
    }

    public int hours, minutes;
}
public struct TaskFullView {
    public VisualElement root;
    public Button closeButton;
    public Label title, description;

    public TaskFullView(VisualElement rootVE) {
        root        = rootVE;
        closeButton = root.Q<Button>("CloseButton");
        title       = root.Q<Label>("Title");
        description = root.Q<Label>("Description");

        closeButton.clicked += CloseButton;
    }

    void CloseButton() {
        root.style.display = DisplayStyle.None;
    }
}

public class UIManager : MonoBehaviour {
    public float timeSpeed = 20.0f;

    private Label timeLabel;
    private TaskFullView taskFullView;

    void Start() {
        var rootVE = GetComponent<UIDocument>().rootVisualElement;
        timeLabel = rootVE.Q<Label>("ClockText");
        taskFullView = new TaskFullView(rootVE.Q<VisualElement>("TaskFullView"));

        var tasksContainer = rootVE.Q<VisualElement>("NextTasks");
        tasksContainer.Query<Button>().ForEach((button) => {
            button.clicked += () => {
                taskFullView.title.text         = button.Q<Label>("TaskTitle").text;
                taskFullView.description.text   = button.Q<Label>("TaskDescription").text;
                taskFullView.root.style.display = DisplayStyle.Flex;
            };
        });
    }

    void Update() {
        timeLabel.text = $"{new TimeFormat(Time.timeSinceLevelLoad * timeSpeed)} am"; // @Incomplete: calculate am/pm
    }
}
