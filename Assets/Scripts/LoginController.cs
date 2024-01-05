using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    [SerializeField] private TMP_InputField loginInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private Button loginButton;

    private ServerManager serverManager;

    private void Start()
    {
        loginButton.onClick.AddListener(Login);
    }

    private void Awake()
    {
        serverManager = new ServerManager();
    }

    public async void Login()
    {
        var login = loginInput.text;
        var password = passwordInput.text;

        var response = await serverManager.Login(login, password);

        if (response == null)
        {
            Debug.Log("Login or password is incorrect");
        }
        else
        {
            var json = JsonUtility.FromJson<LoginResponse>(response);
            Debug.Log($"Successful authorization!\n Access Token: {json.accessToken}");
        }
    }

    private class LoginResponse
    {
        public string accessToken;
    }
}
