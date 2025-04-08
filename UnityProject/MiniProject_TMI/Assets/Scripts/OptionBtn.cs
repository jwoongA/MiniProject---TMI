using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionBtn : MonoBehaviour
{
   
  
        public GameObject targetSlider;

        public void ToggleSlider()
        {
            if (targetSlider != null)
            {
                targetSlider.SetActive(!targetSlider.activeSelf);
            }
        }
}

