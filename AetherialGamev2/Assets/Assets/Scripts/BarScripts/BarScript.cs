using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarScript : MonoBehaviour
{

    [SerializeField] // remove this after testing
    private float fillAmount;

    [SerializeField] // remove this after testing
    private float lerpSpeed;

    [SerializeField] // remove this after testing
    private Image content;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {

            fillAmount = Map(value, 0, MaxValue, 0, 1);

        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();

    }

    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }


    }
    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        //(78 - 0) * (1 - 0) / (230 - 0) + 0 
        // 80 * 1 / 100 = 0,8    example of how it works
    }

}
