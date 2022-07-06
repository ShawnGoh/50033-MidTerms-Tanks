using UnityEngine;

[CreateAssetMenu(fileName = "BooleanVariable", menuName = "ScriptableObjects/BooleanVariable", order = 2)]
public class BooleanVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    [System.NonSerialized]
    private bool _value = false;
    public bool Value
    {
        get
        {
            return _value;
        }
    }

    public void SetValue(bool value)
    {
        _value = value;
    }

    // overload
    public void SetValue(BooleanVariable value)
    {
        _value = value._value;
    }
}
