using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Analytics;
using Debug = UnityEngine.Debug;
using Random = System.Random;

public class TerminalControll : MonoBehaviour
{
    // Start is called before the first frame update

    private int level; //Выбраный ур
    private string password;
    private string[] Level1Password = {"ключ", "книга", "ручка", "текст", "шкаф"};
    private string[] Level2Password = {"дубинка", "арест", "закон", "рапорт", "штраф"};
    private string[] Level3Password = {"комета", "звезда", "космонафт", "армагедон", "интерстеллар"};
    enum Screen
    {
        MainMenu,
        Password,
        Win,
    }

    private const string menuHint = "Вы можете вернуться назад написав меню";

    private Screen currentScreen;

    void Start()
    {
        ShowMainMenu("User");
    }
    
    // Update is called once per frame
    void Update() { }
    void ShowMainMenu(string PlayerName)
    {
        level = 0;
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine($"Привет {PlayerName}");
        Terminal.WriteLine("Какой терминал вы хотите взломать?\n");
        Terminal.WriteLine("Введите 1 - Городская Библиотека");
        Terminal.WriteLine("Введите 2 - Полицейский Участок");
        Terminal.WriteLine("Введите 3 - Космический Корабль");
        Terminal.WriteLine("Введите ваш выбор...");
    }


    void OnUserInput(string input)
    {
        if (input == "меню")
        {
            ShowMainMenu("рад видеть тебя снова");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        
    }

    

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = Convert.ToInt32(input);
            GameStart();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Добро Пожаловать Джеймс");
        }
        else if (input == "777")
        {
            Terminal.WriteLine("Вы выграли ДЖЕК ПОТ !!!");
        }
        else
        {
            Terminal.WriteLine("Введите правильное значение");
        }
        
        
    }

    private void CheckPassword(string input)
    {
        
        if (input == password)
        {
            ShowWinScreen();
        }
        else
        {
            GameStart();
        }
    }

    void ShowWinScreen()
    {
        Terminal.ClearScreen();
        Revard();
        
    }

    void Revard()
    {
        currentScreen = Screen.Win;
        switch (level)
        {
            case 1: 
                Terminal.WriteLine("Пароль верный! Держите вашу книгу");
                Terminal.WriteLine(@"
     ______ ______
    _/      Y      \_
   // ~~ ~~ | ~~ ~  \\
  // ~ ~ ~~ | ~~~ ~~ \\      
`----------`-'----------' "); break;
            case 2: 
                Terminal.WriteLine("Пароль верный! Вот ваше оружие");
                Terminal.WriteLine(@"
 +--^----------,------,-----,----^-,
 | |||||||||   `------'     |      O
   `\_,---------,------,----------'
    / XXXXX /  `\  /'
   / XXXXX /`-----'
  (_______("); break;
            case 3: 
                Terminal.WriteLine("Пароль верный! Вот ваша карта");
                Terminal.WriteLine(@"
           :       _
       .   !   '  (_)
          ,|.' 
-  -- ---(-O-`--- --  -
         ,`|'`.
       ,   !    .  :
           .     --+--"); break;
            
        }
        Terminal.WriteLine(menuHint);
    }
    
    void GameStart()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Random rnd = new Random();
        switch (level)
        {
                case 1:
                    password = Level1Password[rnd.Next(0, Level1Password.Length)];
                    Terminal.WriteLine("Вы зашли в городскую библиотеку");
                    break;
                
                case 2:
                    password = Level2Password[rnd.Next(0, Level2Password.Length)];
                    Terminal.WriteLine("Вы проникли в полицейский участок");
                    break;
                
                case 3:
                    password = Level3Password[rnd.Next(0, Level3Password.Length)];
                    Terminal.WriteLine("Вы путешествуете на космическом корабле");
                    break;
                default: 
                    Debug.LogError("Такого Уровня Не Существует!");
                    break;
                
        }
        
        Terminal.WriteLine($"Подсказка - {password.Anagram()}");
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Введите пароль");
    }

    
}