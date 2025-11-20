using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
{
    [SerializeField] private string androidAdUnitID;
    [SerializeField] private string iOSAdUnitID;
    [Space]
    [Tooltip("If 'on top' not checked, banner will show at the bottom by default")]
    [SerializeField] private bool showBannerOnTop = false;

    private string adUnitID;

        private void Awake()
    {
        
#if UNITY_ANDROID
    adUnitID = androidAdUnitID;
#elif UNITY_IOS
    adUnitID = iOSAdUnitID;
#endif

            if (showBannerOnTop)
            {
                Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            }
            else // default pos: bottom center
            {
                Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            }

    }

    public void LoadBannerAd()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = BannerLoaded,
            errorCallback = BannerLoadedError
        };
        Advertisement.Banner.Load(adUnitID, options);
    }

    public void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            showCallback = BannerShown,
            clickCallback = BannerClicked,
            hideCallback = BannerHidden
        };
        Advertisement.Banner.Show(adUnitID, options);
    }

    #region LoadCallbacks
    private void BannerLoaded()
    {
        Debug.Log("Banner successfully loaded.");
    }

    private void BannerLoadedError(string message)
    {
        
    }
    #endregion

    #region ShowCallbacks

    private void BannerShown()
    {
        
    }

    private void BannerHidden()
    {
        
    }

    private void BannerClicked()
    {
        
    }

    #endregion
}
