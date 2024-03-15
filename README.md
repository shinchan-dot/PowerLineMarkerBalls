# PowerLineMarkerBalls

This is a VRChart world with helicopters.

## To create your project
#### Create a new world project with VRChat Creator Companion.

#### Import iwaSync3_v3.6.0.

#### Install SaccFlightAndVehicles 1.64.

#### Delete the following script files.
```
SaccAirVehicle
Assets/SaccFlightAndVehicles/Scripts/SaccAirVehicle/SaccAirVehicle.cs
Assets/SaccFlightAndVehicles/Udon/SaccAirVehicle.asset

SaccFlightVehicleMenu
Assets/SaccFlightAndVehicles/Scripts/Other/SaccFlightVehicleMenu.cs
Assets/SaccFlightAndVehicles/Udon/SaccFlightVehicleMenu.asset
```

#### Put the PowerLineMarkerBalls folder into your Assets folder.

#### Rename layers used in SaccFlight.
UNITY MENU -> SaccFlight -> RenameLayers

#### Rename layers used in marker balls.
Project Settings -> Tags and Layers -> Layers
```
User Layer 29 "Wire"
User Layer 30 "MarkerBall"
```

#### Turn off the following layer collision matrix.
Project Settings -> Physics -> Layer Collision Matrix
```
MarkerBall/OnBoardVehicleLayer
UI/MarkerBall
Player/MarkerBall
PlayerLocal/MarkerBall
UiMenu/MarkerBall
Walkthrough/MarkerBall
Wire/MarkerBall
```
