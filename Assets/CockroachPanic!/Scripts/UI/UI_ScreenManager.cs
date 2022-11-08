using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CockroachPanic.UI
{
    public class UI_ScreenManager : MonoBehaviour
    {
        static UI_ScreenManager instance;
        [SerializeField] string firstScreenName;
        [SerializeField] List<UIScreen> screens;
        UIScreen currentScreen;
        UIScreen currentPopupScreen;

        private void OnEnable() { instance = this; }
        private void Start() 
        {
            HideAllScreens();
            ShowScreen(firstScreenName); 
        }

        #region Show/Hide Screen Functions
        // Screens
        public static void ShowScreen(UIScreen _screen) 
        { 
            if(instance.currentScreen != null) instance.currentScreen.Hide();
            _screen.Show(out instance.currentScreen);
        }
        public static void ShowScreen(string screenName)
        {
            if (instance == null) return;
            var screen = instance.screens.Find(x => x.GetName() == screenName);
            if(screen == null) { Debug.LogError($"Screen '{screenName}' wasn't found"); return; }
            ShowScreen(screen);
        }
        public static void HideAllScreens() { foreach (var screen in instance.screens) { screen.Hide(); } }

        // Popup Screens
        public static void ShowPopupScreen(UIScreen _screen)
        {
            _screen.Show(out instance.currentPopupScreen);
        }
        public static void ShowPopupScreen(string screenName)
        {
            if(instance == null) return;
            var screen = instance.screens.Find(x => x.GetName() == screenName);
            if (screen == null) { Debug.LogError($"Screen '{screenName}' wasn't found"); return; }
            ShowPopupScreen(screen);
        }
        public static void HideCurrentPopup() { if(instance.currentPopupScreen != null) instance.currentPopupScreen.Hide(); }
        #endregion

        [System.Serializable]
        public class UIScreen
        {
            [SerializeField] string screenName;
            [SerializeField] GameObject screenGameObject;

            public void Show(out UIScreen current)
            {
                screenGameObject.SetActive(true);
                current = this;
            }
            public void Hide() => screenGameObject.SetActive(false);
            public string GetName() => screenName;
        }
    }
}