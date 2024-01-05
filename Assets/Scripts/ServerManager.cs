using UnityEngine;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;

public class ServerManager
{
    private const string BaseURL = "https://stage.arenagames.api.ldtc.space/api/v3/gamedev/client/auth/sign-in/";
    
        public async UniTask<string> Login(string login, string password)
        {
            var form = new WWWForm();
            form.AddField("login", login);
            form.AddField("password", password);
    
            using (var www = UnityWebRequest.Post(BaseURL, form))
            {
                try
                {
                    await www.SendWebRequest();
                }
                catch
                {
                    Debug.LogError($"Login failed:\n {www.error}");
                    return null;
                }

                var response = www.downloadHandler.text;
                return response;
            }
        }
}
