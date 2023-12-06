using UnityEngine;

using UnityEngine.EventSystems;

namespace TankGame.Sound 
{
    public class UIElementSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        [SerializeField] private string mouseTouchedSfxName;

        [SerializeField] private string buttonClickedElementSfxName;

        public void OnPointerClick(PointerEventData eventData)
        {
            AudioManager.Instance.SetSfx(buttonClickedElementSfxName);

            AudioManager.Instance.PlaySfx();            
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            AudioManager.Instance.SetSfx(mouseTouchedSfxName);

            AudioManager.Instance.PlaySfx();
        }
    }
}