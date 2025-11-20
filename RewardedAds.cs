using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidAdUnitID;
    [SerializeField] private string iOSAdUnitID;

    private string adUnitID;

        private void Awake()
    {
        
#if UNITY_ANDROID
    adUnitID = androidAdUnitID;
#elif UNITY_IOS
    adUnitID = iOSAdUnitID;
#endif

    }

    public void LoadRewardedAd()
    {
        Advertisement.Load(adUnitID, this);
    }

    public void ShowRewardedAd()
    {
        Advertisement.Show(adUnitID, this);
        LoadRewardedAd(); // (pre-)load immediately after showing an ad
    }


    #region LoadCallbacks

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Rewarded Ad Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Rewarded ad failed to load...");
    }

    #endregion

    #region ShowCallbacks

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == adUnitID && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Rewarded ads fully watched!");
        }
    }

    #endregion
}
