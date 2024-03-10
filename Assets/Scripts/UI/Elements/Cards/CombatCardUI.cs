using System;
using Core.Services.CombatService.Interfaces;
using UI.Elements.Cards.CombatCardView;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Elements.Cards
{
    public class CombatCardUI : MonoBehaviour, IPointerDownHandler ,IPointerUpHandler
    {
        public Action OnDefaultClickAction;
        public Action OnLongPressAction;

        [SerializeField] private CombatCardElementUI[] cardElementsUI;
        
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float longPressTimeConstant;

        private bool isPressed;
        private float pressedTime;
        private bool interactable = true;

        private void Update()
        {
            if (isPressed)
            {
                pressedTime += Time.deltaTime;

                if (pressedTime >= longPressTimeConstant)
                {
                    isPressed = false;
                    pressedTime = 0.0f;

                    Debug.LogError("Long Click");
                    
                    OnLongPressAction?.Invoke();
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (isPressed)
            {
                isPressed = false;
                pressedTime = 0.0f;
            
                Debug.LogError("Default Click");
            
                OnDefaultClickAction?.Invoke();
            }
        }

        public void InitializeUI(ICombatCard combatCard)
        {
            foreach (var cardElementUI in cardElementsUI)
            {
                cardElementUI.InitializeUI(combatCard);
            }
        }

        public void SetInteractableStateActive(bool value)
        {
            interactable = value;

            canvasGroup.alpha = value ? 1.0f : 0.5f;
        }
    }
}