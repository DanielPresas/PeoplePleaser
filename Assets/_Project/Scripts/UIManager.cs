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

public class UIManager : MonoBehaviour {
    public Label timeLabel;

    void Start() {
        var root = GetComponent<UIDocument>().rootVisualElement;
        timeLabel = root.Q<Label>("ClockText");
    }

    void Update() {
        timeLabel.text = $"{new TimeFormat(Time.timeSinceLevelLoad)} am"; // @Incomplete: calculate am/pm
    }
}
