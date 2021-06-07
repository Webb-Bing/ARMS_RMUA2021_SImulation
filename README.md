# ARMS
## Ausdroid RoboMaster Simulation


![avatar](https://github.com/Team-Ausdroid-Unimelb/ARMS/blob/master/1.png)
![avatar](https://github.com/Team-Ausdroid-Unimelb/ARMS/blob/master/2.png)
![avatar](https://github.com/Team-Ausdroid-Unimelb/ARMS/blob/master/3.png)
![avatar](https://github.com/Team-Ausdroid-Unimelb/ARMS/blob/master/4.png)
![avatar](https://github.com/Team-Ausdroid-Unimelb/ARMS/blob/master/5.png)


# Release 1.0
It is ready for CV group to take picture in the simulation for training. Apriltag, robot armor board and robot orientation should be ready. The camera is moveable by pressing the key "W,A,S,D" and it is also rotatable by moving mouse to left or right. The picture can be taken by pressing "F9". But please be aware of the following steps before you use this:

1. Please update the path in the camera from Unity 3D, and create a folder named "Snapshots" under this path;
2. Please find "Game -> Display 1", and one the right dropdown box next to "Display 1" add a config with resolution "1280*1024" (which is the actual camera resolution that our robots will use).



# Important notes
1. source correct file before launch, as we are using customized messages:
```bash
cd your_workspace
source devel/setup.bash
roslaunch rosbridge_server rosbridge_websocket.launch 
```