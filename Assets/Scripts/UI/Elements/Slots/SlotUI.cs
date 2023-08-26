using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements.Slots
{
    public class SlotUI : MonoBehaviour
    {
        [SerializeField] protected Button button;
        [SerializeField] protected Image icon;
        [SerializeField] protected Image backgroundDеfault;
        [SerializeField] protected Image backgroundRarity;
        [SerializeField] protected Image border;
        [SerializeField] protected TextMeshProUGUI enhancementLevel;
        [SerializeField] protected TextMeshProUGUI stackSize;

        public void SetIcon(Sprite icon)
        {
            this.icon.sprite = icon;
            this.icon.gameObject.SetActive(true);
        }

        public void SetIconAlphaActive(bool active)
        {
            icon.CrossFadeAlpha(active ? 1.0f :0.5f, 0.0f, true);
        }

        public void SetText(string text)
        {
            stackSize.gameObject.SetActive(true);
            stackSize.text = text;
        }
    }
}