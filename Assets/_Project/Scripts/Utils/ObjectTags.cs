using System.Collections.Generic;
using UnityEngine;

public class ObjectTags : MonoBehaviour {
    public enum Tags {
        Player,
    }

    public List<Tags> tags { get; private set; } = new List<Tags>();

    public bool HasTag(Tags tag) => tags.Contains(tag);
    public void AddTag(Tags tag) { if(!HasTag(tag)) tags.Add(tag); }
}
