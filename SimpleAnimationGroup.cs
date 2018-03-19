using UnityEngine;

[CreateAssetMenu(menuName = "PluggableItem/SimpleAnimationGroup")]
public class SimpleAnimationGroup : ScriptableObject
{
    [SerializeField]
    private SimpleAnimation.EditorState[] _animationStates;

    public SimpleAnimation.EditorState[] AnimationStates
    {
        get { return _animationStates; }
        set
        {
            if (value != null) _animationStates = value;
        }
    }
}
