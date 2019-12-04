using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualitySettingsController : MonoBehaviour
{
    public void SetTextureSettings(Dropdown level)
    {
        switch (level.value)
        {
            case 0:
                QualitySettings.SetQualityLevel(2);
                break;
            case 2:
                QualitySettings.SetQualityLevel(1);
                break;
            case 1:
                QualitySettings.SetQualityLevel(0);
                break;
        }
    }

    public void SetAnisotrophicFiltering(Dropdown level)
    {
        switch (level.value)
        {
            case 3:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
                break;
            case 2:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
                break;
            case 1:
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
                break;
        }
    }

    public void SetAntialiasingSettings(Dropdown level)
    {
        switch (level.value)
        {
            case 0:
                QualitySettings.antiAliasing = 8;
                break;
            case 1:
                QualitySettings.antiAliasing = 4;
                break;
            case 2:
                QualitySettings.antiAliasing = 2;
                break;
            case 3:
                QualitySettings.antiAliasing = 0;
                break;
        }
    }

    public void SetVSync(Toggle toggle)
    {
        if (!toggle.isOn)
        {
            QualitySettings.vSyncCount = 0;
        } 
        else
        {
            QualitySettings.vSyncCount = 2;
        }
    }

    public void SetShadows(Toggle toggle)
    {
        if (!toggle.isOn)
        {
            QualitySettings.shadows = ShadowQuality.Disable;
        } 
        else
        {
            QualitySettings.shadows = ShadowQuality.All;
        }
    }

    public void SetSoftParticles(Toggle toggle)
    {
        if (!toggle.isOn)
        {
            QualitySettings.softParticles = false;
        } else
        {
            QualitySettings.softParticles = true;
        }
    }
}
