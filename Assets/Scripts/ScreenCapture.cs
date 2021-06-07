using UnityEngine;
using System.Collections;
using System;
using static UnitySystemConsoleRedirector;

public class ScreenCapture : MonoBehaviour
{
    public RenderTexture overviewTexture;
    public string path = "D:\\work\\rm\\temp\\";
    GameObject current;
    Camera camOV;
    Texture2D imageOverview;
    public int cameraWidth = 1280;
    public int cameraHeight = 1024;

    void Start()
    {
        //System.Console.WriteLine(Screen.height);
        //System.Threading.Thread.Sleep(1000);
        //Screen.SetResolution(cameraWidth, cameraHeight, Screen.fullScreen);
        //System.Threading.Thread.Sleep(1000);
        //System.Console.WriteLine("after changes " + Screen.height);
        UnitySystemConsoleRedirector.Redirect();
        current = GameObject.FindGameObjectWithTag("CV_camera_object");
        camOV = GetCamera();

        // displayer id start from 0
        //camOV.targetDisplay = 3;
        //Screen.SetResolution(cameraWidth, cameraHeight, Screen.fullScreen);
        //System.Threading.Thread.Sleep(1000);
        System.Console.WriteLine("changed screen "+Screen.height);
        //float x = (100f - 100f / (Screen.width / cameraWidth)) / 100f;
        //float y = (100f - 100f / (Screen.height / cameraHeight)) / 100f;
        //camOV.rect = new Rect(x, y, 1, 1);

        //StartCoroutine(TargetDisplayHack(camOV.targetDisplay));
        imageOverview = new Texture2D(camOV.pixelWidth, camOV.pixelHeight, TextureFormat.RGB24, false);
        

    }

    //private IEnumerator TargetDisplayHack(int targetDisplay)
    //{
    //    // Get the current screen resolution.
    //    int screenWidth = Screen.width;
    //    int screenHeight = Screen.height;

    //    // Set the target display and a low resolution.
    //    PlayerPrefs.SetInt("UnitySelect$$anonymous$$onitor", targetDisplay);
    //    Screen.SetResolution(cameraWidth, cameraHeight, Screen.fullScreen);

    //    // Wait a frame.
    //    yield return null;

    //    // Restore resolution.
    //    Screen.SetResolution(screenWidth, screenHeight, Screen.fullScreen);
    //}


    void LateUpdate()
    {
        if (Input.GetKeyDown("f9"))
        {
            StartCoroutine(TakeScreenShot());
        }
    }

    // return file name
    string fileName(int width, int height)
    {
        return string.Format("screen_{0}x{1}_{2}.png",
                              width, height,
                              System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    public IEnumerator TakeScreenShot()
    {
        yield return new WaitForEndOfFrame();
        RenderTexture currentRT = RenderTexture.active;
        //RenderTexture.active = camOV.targetTexture;
        camOV.Render();
        
        imageOverview.ReadPixels(new Rect(0, 0, camOV.pixelWidth, camOV.pixelHeight), 0, 0);
        imageOverview.Apply();
        RenderTexture.active = currentRT;

        // Encode texture into PNG
        byte[] bytes = imageOverview.EncodeToPNG();

        // save in memory
        string filename = fileName(Convert.ToInt32(imageOverview.width), Convert.ToInt32(imageOverview.height));
        string target_path = path + "/Snapshots/" + filename;
        System.IO.File.WriteAllBytes(target_path, bytes);
    }

    //private Texture2D GetTexture2D()
    //{
        
    //    System.Console.WriteLine("cam pixel height" + camOV.pixelHeight);
    //    System.Console.WriteLine("cam pixel width" + camOV.pixelWidth);
    //    System.Console.WriteLine("cam texture" + TextureFormat.RGB24);
    //    Texture2D texture2D =
    //    return texture2D;
    //}

    private Camera GetCamera()
    {
        return current.GetComponent<Camera>();
    }
}