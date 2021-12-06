using UnityEngine;
using UnityEngine.Events;

public class InteractableLocation : MonoBehaviour {
    public Transform target;
    public UnityEvent triggerEvent;

    private PlayerController player;

    void Start() {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other) {
        if(!other.TryGetComponent(out ObjectTags tags) || !tags.HasTag(ObjectTags.Tags.Player)) return;
        triggerEvent.Invoke();
    }

    public void OnClicked() {
        player.InstantiateClickFeedback(target.position);
    }
}
