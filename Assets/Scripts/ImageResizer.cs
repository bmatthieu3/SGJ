using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ImageResizer : MonoBehaviour
{
    [SerializeField] private Image image;
    public int size1 = 10;
    public int size2 = 10;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

        // Load image from file
        Texture2D texture = new Texture2D(1, 1);
        byte[] bytes = File.ReadAllBytes(Application.dataPath + "/sprites/assets-graphics/noeunoeuil/OeilBase/Base.png");
        texture.LoadImage(bytes);

        // Resize image
        Texture2D resizedTexture = Resize(texture, size1, size2);

        // Save resized image to file
        // byte[] resizedBytes = resizedTexture.EncodeToPNG();
        // File.WriteAllBytes(Application.dataPath + "/test.png", resizedBytes);

        Sprite sprite = Sprite.Create(resizedTexture, new Rect(0, 0, resizedTexture.width, resizedTexture.height), new Vector2(0.5f, 0.5f));
        image.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        Texture2D texture = new Texture2D(1, 1);
        byte[] bytes = File.ReadAllBytes(Application.dataPath + "/sprites/assets-graphics/noeunoeuil/OeilBase/Base.png");
        texture.LoadImage(bytes);

        Texture2D resizedTexture = Resize(texture, size1, size2);

        Sprite sprite = Sprite.Create(resizedTexture, new Rect(0, 0, resizedTexture.width, resizedTexture.height), new Vector2(0.5f, 0.5f));
        image.sprite = sprite;
    }


    private Texture2D Resize(Texture2D texture, int width, int height)
    {
        RenderTexture rt = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.ARGB32);
        rt.filterMode = FilterMode.Bilinear;

        RenderTexture.active = rt;
        Graphics.Blit(texture, rt);
        Texture2D result = new Texture2D(width, height);
        result.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        result.Apply();

        RenderTexture.active = null;
        RenderTexture.ReleaseTemporary(rt);

        return result;
    }
}
