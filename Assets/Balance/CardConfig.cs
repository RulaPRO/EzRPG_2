using UnityEngine;

namespace Balance
{
    [CreateAssetMenu(fileName = "Card_", menuName = "Balance/Card/CreateConfig", order = 1)]
    public class CardConfig : ScriptableObject
    {
        [SerializeField] private int power;
        [SerializeField] private int attackType;
        [SerializeField] private Sprite icon;

        public int Power => power;
        public int AttackType => attackType;
        public Sprite Icon => icon;
    }
}
