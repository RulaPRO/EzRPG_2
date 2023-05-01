using Core.Services.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popups
{
    public class ConfirmationPopup : UIPopup
    {
        [SerializeField] private Button acceptButton;
        [SerializeField] private Button cancelButton;

        private void Start()
        {
            acceptButton.onClick.AddListener(() =>
            {
                Hide();
                Debug.Log("ConfirmationPopup AcceptButton Click");
            });

            cancelButton.onClick.AddListener(() =>
            {
                Debug.Log("ConfirmationPopup CancelButton Click");
                Hide();
            });
        }
    }
}