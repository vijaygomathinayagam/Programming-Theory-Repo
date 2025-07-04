using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer leftIndicator;
    [SerializeField]
    private MeshRenderer rightIndicator;
    [SerializeField]
    protected Material yellowLightMaterial;
    [SerializeField]
    protected Material noLightMaterial;

    private IEnumerator leftIndicatorRoutine;
    private IEnumerator rightIndicatorRoutine;
    protected List<Material> noLightMaterials = new List<Material>();
    protected List<Material> yellowLightMaterials = new List<Material>();

    protected void initIndicator()
    {
        noLightMaterials.Add(noLightMaterial);
        yellowLightMaterials.Add(yellowLightMaterial);
    }

    public void ShowLeftIndicator()
    {
        if (leftIndicatorRoutine != null)
        {
            return;
        }
        if (rightIndicatorRoutine != null)
        {
            stopRightIndicator();
        }
        leftIndicatorRoutine = startLeftIndicator();
        StartCoroutine(leftIndicatorRoutine);
    }

    public void ShowRightIndicator()
    {
        if (rightIndicatorRoutine != null)
        {
            return;
        }
        if (leftIndicatorRoutine != null)
        {
            stopLeftIndicator();
        }
        rightIndicatorRoutine = startRightIndicator();
        StartCoroutine(rightIndicatorRoutine);
    }

    public void TurnOffBothIndicator()
    {
        if (rightIndicatorRoutine != null)
        {
            stopRightIndicator();
        }
        if (leftIndicatorRoutine != null)
        {
            stopLeftIndicator();
        }
    }

    private IEnumerator startLeftIndicator()
    {
        while (true)
        {
            leftIndicator.SetMaterials(yellowLightMaterials);
            yield return new WaitForSeconds(Constants.IndicatorLightDuration);

            leftIndicator.SetMaterials(noLightMaterials);
            yield return new WaitForSeconds(Constants.IndicatorLightDuration);
        }
    }

    private IEnumerator startRightIndicator()
    {
        while (true)
        {
            rightIndicator.SetMaterials(yellowLightMaterials);
            yield return new WaitForSeconds(Constants.IndicatorLightDuration);

            rightIndicator.SetMaterials(noLightMaterials);
            yield return new WaitForSeconds(Constants.IndicatorLightDuration);
        }
    }

    private void stopLeftIndicator()
    {
        StopCoroutine(leftIndicatorRoutine);
        leftIndicatorRoutine = null;
        leftIndicator.SetMaterials(noLightMaterials);
    }

    private void stopRightIndicator()
    { 
        StopCoroutine(rightIndicatorRoutine);
        rightIndicatorRoutine = null;
        rightIndicator.SetMaterials(noLightMaterials);
    }
}
