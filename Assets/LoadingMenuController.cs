using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingMenuController : MonoBehaviour
{
    [SerializeField]
    private Image loadingProgressBar;

    public void SetLoadingProgress(float progress)
    {
        loadingProgressBar.fillAmount = progress;
    }
}
