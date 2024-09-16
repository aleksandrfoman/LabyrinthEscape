using UnityEngine;

namespace Content.Scripts.SO
{
    [CreateAssetMenu(fileName = "KeySO", menuName = "GameData/KeySO", order = 0)]
    public class KeySO : ScriptableObject
    {
        [field: SerializeField] public EKeyType KeyType;
        [field: SerializeField] public Color Color;
    }
}
    
