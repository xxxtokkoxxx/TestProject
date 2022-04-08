# Test project SDK
## Description

SDK for showing video advertisment and making purchases

## Development Environment

Unity3D editor 2019.4.9;
Target platform: PC (Windows)

## Getting started

- download and import Sdk (Unity package) from tags (version 0.0.1);
- open Assets/SDK/Sdk/ExampleScenes;
- open PurchaseSample or AdsSample scenes;
- run Unity Editor;

- if you want to test it in custom scene, add Assets/SDK/Sdk/Sdk.prefab to your scene 

## API
Use SDK API through the singleton Assets/SDK/Sdk/CodeBase/SdkCore/Sdk.cs

- ShowVideoAdvertisement - show video advertisement
- HideVideoAdvertisement - hide video advertisement
- ShowPurchase - show purchase view
- HidePurchase - hide purchase view
