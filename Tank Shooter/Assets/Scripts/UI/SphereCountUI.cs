using UnityEngine;

using TMPro;

namespace TankGame.UI 
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class SphereCountUI : MonoBehaviour
    {
        private TextMeshProUGUI sphereText;
        
        private void Awake()
        {
            sphereText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            UpdateSphereText();

            SphereHealth.OnActiveSphereInstancesChanged += UpdateSphereText;
        }

        private void OnDestroy()
        {
            SphereHealth.OnActiveSphereInstancesChanged -= UpdateSphereText;
        }

        private void UpdateSphereText()
        {
            sphereText.text = SphereHealth.ActiveSphereInstances.ToString();
        }
    }
}