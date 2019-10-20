using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsGUIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText = default;

    public void SetPointsText(string points)
    {
        timerText.text = points;
    }

    public void AddPointsText(int points)
    {
        ModifyPoints(points.ToString());
    }

    public void AddPointsText(string points)
    {
        ModifyPoints(points);
    }

    private void ModifyPoints(string points)
    {
        int currentPoints;

        try
        {
            currentPoints = int.Parse(timerText.text);
            currentPoints += int.Parse(points);
        } 
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
            return;
        }
     
        timerText.text = currentPoints.ToString();
    }

}
