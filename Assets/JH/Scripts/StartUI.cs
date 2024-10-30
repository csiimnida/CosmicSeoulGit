using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartUI : MonoBehaviour
{
    private VisualElement _background;
    private VisualElement _setting;
    private VisualElement _startMenu;

    private Button _startButton;
    private Button _settingButton;
    private Button _exitButton;
    private Button _XButton;
    private Button _beginningButton;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _background = root.Q<VisualElement>("Background_StartScene");
        _startButton = root.Q<Button>("StartButton");
        _settingButton = root.Q<Button>("SettingButton");
        _exitButton = root.Q<Button>("ExitButton");

        _setting = root.Q<VisualElement>("Setting");
        _startMenu = root.Q<VisualElement>("StartMenu");

        _XButton = root.Q<Button>("XButton");

        _beginningButton = root.Q<Button>("BeginningButton");

        _startButton.RegisterCallback<ClickEvent>(OnStartButtonClicked);
        _settingButton.RegisterCallback<ClickEvent>(OnSettingButtonClicked);
        _exitButton.RegisterCallback<ClickEvent>(OnExitButtonClicked);
        _XButton.RegisterCallback<ClickEvent>(OnXButtonClicked);
        _beginningButton.RegisterCallback<ClickEvent>(OnBeginningButtonClicked);

        _setting.style.display = DisplayStyle.None;
        _startMenu.style.display = DisplayStyle.None;
    }

    private void OnBeginningButtonClicked(ClickEvent evt)
    {
        SceneManager.LoadScene("CM");
    }

    private void OnXButtonClicked(ClickEvent evt)
    {
        _setting.style.display = DisplayStyle.None;
    }

    private void OnExitButtonClicked(ClickEvent evt)
    {
        Application.Quit();
    }

    private void OnSettingButtonClicked(ClickEvent evt)
    {
        _setting.style.display = DisplayStyle.Flex;

    }

    private void OnStartButtonClicked(ClickEvent evt)
    {
        _startMenu.style.display = DisplayStyle.Flex;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
