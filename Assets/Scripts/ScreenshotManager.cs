using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class ScreenshotManager : MonoBehaviour
    {
        // Static instance required to trigger screenshots
        // through a static function 
        public static ScreenshotManager instance; 

        private Camera mainCamera;
        private bool takingScreenshot;
        private int depth; 

        private void Awake()
        {
            instance = this;
            mainCamera = GetComponent<Camera>();
        }

        private void TakeScreenshot(int width, int height)
        {
            // Render texture allows for specific width/height values
            // instead of the entire screen 
            mainCamera.targetTexture = RenderTexture.GetTemporary(width, height, depth);
        }

        private void OnPostRender()
        {
            if (takingScreenshot)
            {
                RenderTexture renderTexture = mainCamera.targetTexture;

                Texture2D renderResult = new Texture2D
                (
                    renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false
                );

                Rect rectangle = new Rect(0, 0, renderTexture.width, renderTexture.height);
                renderResult.ReadPixels(rectangle, 0, 0);

                byte[] byteArray = renderResult.EncodeToPNG();
                string filename = "Screenshot.png"; 
                System.IO.File.WriteAllBytes(Application.dataPath + filename, byteArray);
                Debug.Log(filename + " saved.");

                RenderTexture.ReleaseTemporary(renderTexture);
                mainCamera.targetTexture = null;
                takingScreenshot = false; 
            }
        }

        public static void TakeScreenshot_Static(int width, int height)
        {
            instance.TakeScreenshot(width, height); 
        }

    }
}
