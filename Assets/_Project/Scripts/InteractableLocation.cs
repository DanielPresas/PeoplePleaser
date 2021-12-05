using UnityEngine;

public class InteractableLocation : MonoBehaviour {
    public Transform target;

    private PlayerController player;

    void Start() {
        player = FindObjectOfType<PlayerController>();
    }

    public void OnClicked() {
        player.InstantiateClickFeedback(target.position);
    }
}
