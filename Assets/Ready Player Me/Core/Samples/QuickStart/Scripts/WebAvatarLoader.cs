using UnityEngine;
using ReadyPlayerMe.Core.WebView;
using ReadyPlayerMe.Core;
using Newtonsoft.Json;

public class WebAvatarLoader : MonoBehaviour
{
    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        WebInterface.SetupRpmFrame("https://metaground.readyplayer.me/avatar?frameApi", name);
#endif
    }

    // Called from JS when avatar is exported
    public void FrameMessageReceived(string message)
    {
        var msg = JsonConvert.DeserializeObject<WebMessage>(message);

        if (msg.eventName == WebViewEvents.AVATAR_EXPORT)
        {
            string url = msg.GetAvatarUrl();
            AvatarData.Url = url;
            UnityEngine.SceneManagement.SceneManager.LoadScene("QuickStartScene");
        }
    }

    public void OnCreateAvatarButton()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        WebInterface.SetIFrameVisibility(true);
#endif
    }
}
