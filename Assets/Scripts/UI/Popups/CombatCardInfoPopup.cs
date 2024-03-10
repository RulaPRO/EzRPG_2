using Core.Services.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popups
{
    public class CombatCardInfoPopup : UIPopup
    {
        [SerializeField] private Button buttonClose;
        [SerializeField] private Button buttonBackground;
        [SerializeField] private Image icon;
        
        private void Start()
        {
            buttonClose.onClick.AddListener(Hide);
        }
    }
}