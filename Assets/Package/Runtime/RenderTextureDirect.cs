using UnityEngine;

namespace dev.kemomimi.renderTextureDirect
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]

    public class RenderTextureDirect : MonoBehaviour
    {
        public RenderTexture RenderTexture;

        private Camera cam;
        private Material rtAttachedMat;

        private void Start()
        {
            cam = GetComponent<Camera>();
            cam.targetTexture = null;
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.backgroundColor = Color.clear;
            cam.cullingMask = 0;
            cam.nearClipPlane = 0.1f;
            cam.farClipPlane = 0.2f;

            if (rtAttachedMat != null)
                return;

            rtAttachedMat = new Material(Shader.Find("RenderTextureDirect/Attach"));
            rtAttachedMat.SetTexture("_RenderTex", RenderTexture);
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (rtAttachedMat == null)
                return;

            Graphics.Blit(source, destination, rtAttachedMat);
        }
    }
}
