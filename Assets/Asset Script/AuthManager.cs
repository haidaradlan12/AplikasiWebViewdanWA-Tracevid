using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;

using UnityEngine.UI;
using DG.Tweening;

public class AuthManager : MonoBehaviour
{
    //Firebase variabel
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;

    //Login variabel
    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text warningLoginText;
    public TMP_Text confirmLoginText;

    //Register variabel
    [Header("Register")]
    public TMP_InputField usernameRegisterField;
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField passwordRegisterVerifyField;
    public TMP_Text warningRegisterText;

    [Header("UI")]
    public RectTransform LogSig; public RectTransform Log, Sig, FM, CP, Kons, Buttn;
    [Header("Web View")]
    public GameObject webvie;
    public GameObject webvie1;

    public void Loginbutton()
    {
        LogSig.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Log.DOAnchorPos(new Vector2(0, 0), 1.0f);
        Sig.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Buttn.DOAnchorPos(new Vector2(0, -1000), 1.0f); // 0, 127.9, 0, 255.5332
        FM.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        CP.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Kons.DOAnchorPos(new Vector2(1500, 0), 1.0f);
    }
    public void FMbutton()
    {
        LogSig.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Log.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Sig.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Buttn.DOAnchorPos(new Vector2(0, 127.9f), 1.0f); // 0, 127.9, 0, 255.5332
        FM.DOAnchorPos(new Vector2(0, 0), 1.0f);
        CP.DOAnchorPos(new Vector2(1500, 0), 1.0f);
        Kons.DOAnchorPos(new Vector2(1500, 0), 1.0f);
    }
    

    private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase depencies: " + dependencyStatus);
            }
        });
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");

        auth = FirebaseAuth.DefaultInstance;
    }

    public void LoginButton()
    {
        StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));
    }
    
    public void RegisterButton()
    {
        StartCoroutine(Register(emailRegisterField.text, passwordRegisterField.text, passwordRegisterVerifyField.text));
    }

    private IEnumerator Login(string _email, string _password)
    {
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);

        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
            }
            warningLoginText.text = message;
            confirmLoginText.text = "";
        }
        else
        {
            User = LoginTask.Result;
            Debug.LogFormat("User signed in successfully : {0} ({1})", User.DisplayName, User.Email);
            warningLoginText.text = "";
            confirmLoginText.text = "Logged In";
            FMbutton();
            webvie.SetActive(true);
            webvie1.SetActive(true);
        }
    }

    private IEnumerator Register(string _email, string _password, string _username)
    {
        if (_username == "")
        {
            warningRegisterText.text = "Missing Username";
        }
        else if (passwordRegisterField.text != passwordRegisterVerifyField.text)
        {
            warningRegisterText.text = "Password Does Not Match!";
        }
        else
        {
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);

            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Register Failed!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Missing Email";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password";
                        break;
                    case AuthError.WeakPassword:
                        message = "Weak Password";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email Already In Use";
                        break;
                }
                warningRegisterText.text = message;
            }
            else
            {
                User = RegisterTask.Result;
                if (User != null)
                {
                    UserProfile profile = new UserProfile { DisplayName = _username };

                    var ProfileTask = User.UpdateUserProfileAsync(profile);

                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);
                    if (ProfileTask.Exception != null)
                    {
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        warningRegisterText.text = "Username Set Failed";
                    }
                    else
                    {
                        Loginbutton();
                        warningRegisterText.text = "";
                    }
                }
            }
        }
    }
}
