using UnityEngine;
using VContainer;

namespace Core.Services.UI
{
    public class BaseUIUnit : MonoBehaviour
    {
        public bool IsShowing => gameObject.activeSelf;

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}