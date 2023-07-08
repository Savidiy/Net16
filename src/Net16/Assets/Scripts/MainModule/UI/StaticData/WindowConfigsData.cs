using System;
using System.Collections.Generic;
using UnityEngine;

namespace MainModule
{
    [CreateAssetMenu(fileName = nameof(WindowConfigsData), menuName = nameof(WindowConfigsData), order = 0)]
    public class WindowConfigsData : AutoSaveScriptableObject, IWindowConfigProvider
    {
        [SerializeField] private List<WindowConfig> Configs;

        public WindowConfig GetConfig(WindowId windowId)
        {
            foreach (WindowConfig windowConfig in Configs)
            {
                if (windowConfig.Id == windowId)
                {
                    return windowConfig;
                }
            }

            throw new Exception($"Window config with id'{windowId}' not found");
        }
    }
}