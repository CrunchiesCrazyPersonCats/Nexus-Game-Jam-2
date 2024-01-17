using UnityEngine;

namespace Pictomancer.Elements
{
    public class MagiaBoard : MonoBehaviour
    {
        public static MagiaBoard Instance { get; private set; }
        [SerializeField] ElementDetection[] elementsDetector;
        [SerializeField] MagicMixer _magicMike;
        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void UnlockElement(SpellObject_SO detected)
        {
            foreach (ElementDetection detector in elementsDetector)
            {
                detector.ResetBoard();
            }
            _magicMike.AddElement(detected._element);
            _magicMike.AddForm(detected._form);
            // TODO give this spell to the altar
        }
    }
}
