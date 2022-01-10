namespace MiamiDemo
{
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using VRTK.Controllables;

    public class SeaLevelRiseDial : MonoBehaviour
    {
        public VRTK_BaseControllable controllable;
        public TextMeshPro seaLevelReadout;
        public GameObject ocean;
        public string outputOnMax = "Maximum Reached";
        public string outputOnMin = "Minimum Reached";
        private float oceanUnitsToMetersScale = 0.09652509652f;

        protected virtual void OnEnable()
        {
            controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
            controllable.ValueChanged += ValueChanged;
            controllable.MaxLimitReached += MaxLimitReached;
            controllable.MinLimitReached += MinLimitReached;
        }

        protected virtual void ValueChanged(object sender, ControllableEventArgs e)
        {
            if (seaLevelReadout != null)
            {
                TextMeshPro mText = seaLevelReadout.GetComponent<TextMeshPro>();
                mText.text = e.value.ToString("F1") + " meters";
                
                float oceanHeight;
                oceanHeight = e.value * oceanUnitsToMetersScale;
                transform.position += new Vector3 (0.0f, oceanHeight, 0f);
 //               Vector3 newPosition = new Vector3(0, oceanHeight, 0);
   //             ocean.transform.position(newPosition);
            }
        }

        protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
        {
            if (outputOnMax != "")
            {
                Debug.Log(outputOnMax);
            }
        }

        protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
        {
            if (outputOnMin != "")
            {
                Debug.Log(outputOnMin);
            }
        }
    }
}