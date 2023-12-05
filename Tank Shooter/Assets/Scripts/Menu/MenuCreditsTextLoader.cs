using UnityEngine;

using TMPro;

namespace TankGame.Menu 
{
    public class MenuCreditsTextLoader : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI creditsText;

        [SerializeField] private string creditsFileName;

        private TextAsset creditsTextAsset;

        private void Awake()
        {
            creditsTextAsset = Resources.Load<TextAsset>(creditsFileName);

            if (creditsTextAsset == null) 
            {
                Debug.Log("Failed to load credits text asset!");
            }

            if (creditsText == null) 
            {
                Debug.Log("Credits text was not assigned!");
            }
        }

        private void Start()
        {
            if (creditsTextAsset != null && creditsText != null) 
            {
                creditsText.text = creditsTextAsset.text;
            }                    
        }
    }
}