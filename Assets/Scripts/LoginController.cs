using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    [SerializeField] private TMP_InputField _loginInput;
    [SerializeField] private TMP_InputField _passwordInput;
    [SerializeField] private Button _loginButton;
    [SerializeField] private TextMeshProUGUI _errorText;

    private ServerManager _serverManager;

    private void Start()
    {
        _loginButton.onClick.AddListener(Login);
    }

    private void Awake()
    {
        _serverManager = new ServerManager();
    }

    private async void Login()
    {
        var login = _loginInput.text;
        var password = _passwordInput.text;

        var response = await _serverManager.Login(login, password);

        if (response == null)
        {
            _errorText.gameObject.SetActive(true); 
            Debug.Log("Login or password is incorrect");
        }
        else
        {
            _errorText.gameObject.SetActive(false); 
            Debug.Log($"Access Token: \n" +
                      $" token: {response.accessToken.token} \n" +
                      $" expiresIn: {response.accessToken.expiresIn}");
        }
    }
}
