using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using System;

public class GoogelAddManager : MonoBehaviour
{
    private InterstitialAd interstitial_Ad;
    private RewardedAd rewardedAd;

    private string interstitial_Ad_ID;
    private string rewardedAd_ID;
    BannerView bannerView;

    void Start()
    {
        interstitial_Ad_ID = "ca-app-pub-3940256099942544/1033173712";
        rewardedAd_ID = "ca-app-pub-3940256099942544/5224354917";

        MobileAds.Initialize(initStatus => { });

        RequestInterstitial();
        RequestRewardedVideo();
        RequestBanner();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-2865492388471033/5730743132";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);

        // Called when an ad request has successfully loaded.
        bannerView.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        bannerView.OnAdOpening +=HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        bannerView.OnAdClosed += HandleOnAdClosed;
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.ToString().ToString());
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    private void RequestInterstitial()
    {
        interstitial_Ad = new InterstitialAd(interstitial_Ad_ID);
        interstitial_Ad.OnAdLoaded += HandleOnAdLoaded;
        AdRequest request = new AdRequest.Builder().Build();
        interstitial_Ad.LoadAd(request);
    }

    private void RequestRewardedVideo()
    {
        rewardedAd = new RewardedAd(rewardedAd_ID);
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
    }

    public void ShowInterstitial()
    {
        if (interstitial_Ad.IsLoaded())
        {
            interstitial_Ad.Show();
            RequestInterstitial();
        }

    }

    public void ShowRewardedVideo()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        RequestRewardedVideo();
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        RequestRewardedVideo();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        RequestRewardedVideo();
    }
}
