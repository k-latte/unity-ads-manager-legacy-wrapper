using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAds : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string androidGameID;
    [SerializeField] private string iOSGameID;
    [SerializeField] private bool isTesting;

    private string gameID;

    private void Awake()
    {
        
#if UNITY_ANDROID
    gameID = androidGameID;
#elif UNITY_IOS
    gameID = iOSGameID;
#elif UNITY_EDITOR
    gameID = androidGameID;
#endif

        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameID, isTesting, this);
        }

    }

    public void OnInitializationComplete()
    {
        Debug.Log("Ads Initialized.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Ads initialization failed.");
    }
}
