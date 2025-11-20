# Unity Ads Manager (Legacy) Wrapper
A lightweight, singleton-based wrapper for the Unity Ads Legacy package. This system handles initialization, loading, and showing of Interstitial, Rewarded, and Banner ads with automatic reloading.

> ⚠️ **IMPORTANT:** This wrapper is designed for the **Legacy Unity Ads SDK** (`com.unity.ads`). It is **NOT** compatible with Unity LevelPlay (IronSource) or the newer Mediation packages without modification.

## 📦 Prerequisites

* **Unity Version:** 2021.3 or higher (recommended).
* **Package:** Unity Advertisement (Legacy).
    * **Version used:** `4.4.2` (Tested).
    * **Installation:** Go to `Window > Package Manager > Unity Registry > Advertisement` and click **Install**.

## 🛠️ Setup / Reconstruction Guide

Since this repository contains only the raw C# scripts, you must reconstruct the GameObject hierarchy in your scene.

### 1. Hierarchy Setup
1.  Create an **Empty GameObject** in your first scene (e.g., Main Menu).
2.  Name it `AdsManager`.
3.  Add the following components (scripts) to this single GameObject:
    * `AdsManager`
    * `InitializeAds`
    * `BannerAds`
    * `InterstitialAds`
    * `RewardedAds`

### 2. Wiring the Dependencies
In the Inspector for the **AdsManager** component, you will see empty slots. Drag and drop the components from the *same* GameObject into these slots:
* **Initialize Ads:** Drag the `InitializeAds` component here.
* **Banner Ads:** Drag the `BannerAds` component here.
* **Interstitial Ads:** Drag the `InterstitialAds` component here.
* **Rewarded Ads:** Drag the `RewardedAds` component here.

### 3. Configuration (Inspector)
You need to fill in your IDs from the [Unity Monetization Dashboard](https://dashboard.unity3d.com/).

#### `InitializeAds` Component
* **Android Game ID:** (e.g., `1234567`)
* **iOS Game ID:** (e.g., `1234568`)
* **Is Testing:** `CHECKED` for development, `UNCHECKED` for release.

#### `BannerAds` / `InterstitialAds` / `RewardedAds` Components
Fill in the specific **Ad Unit IDs** (created in the Dashboard):
* **Android Ad Unit ID:** (e.g., `Banner_Android`, `Interstitial_Android`)
* **iOS Ad Unit ID:** (e.g., `Banner_iOS`, `Interstitial_iOS`)

> **Note:** `BannerAds` has an extra checkbox `Show Banner On Top`. If unchecked, it defaults to Bottom-Center.

---

## 🚀 Usage

Access the system globally via the singleton `AdsManager.Instance`.

### Show Interstitial (Video)
```csharp
AdsManager.Instance.interstitialAds.ShowInterstitialAd();
```

### Show Rewarded Ad
```csharp
AdsManager.Instance.rewardedAds.ShowRewardedAd();
```
To handle the reward logic, go to RewardedAds.cs and modify the OnUnityAdsShowComplete method.

### Show/Hide Banner
```csharp
AdsManager.Instance.bannerAds.ShowBannerAd();
// To hide:
// Advertisement.Banner.Hide(); (Not currently wrapped in the script, add if needed)
```

## Logic Flow & Notes

Persistence: The AdsManager calls DontDestroyOnLoad(gameObject) on Awake. It will survive scene changes.

Auto-Load: Ads are automatically pre-loaded in the Awake() method of AdsManager and re-loaded immediately after being shown.

Editor Testing: The scripts are set up to use the Android Game ID when running inside the Unity Editor.


## File Structure

* AdsManager.cs - Main Entry point & Singleton logic.

* InitializeAds.cs - Handles SDK initialization.

* BannerAds.cs - Logic for Banner placement and display.

* InterstitialAds.cs - Logic for full-screen popups.

* RewardedAds.cs - Logic for rewarded videos & callbacks.
