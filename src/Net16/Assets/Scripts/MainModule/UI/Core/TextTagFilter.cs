using System;
using System.Linq;
using UnityEngine;

namespace MainModule
{
    internal class TextTagFilter
    {
        private readonly Inventory _inventory;

        public TextTagFilter(Inventory inventory)
        {
            _inventory = inventory;
        }
        
        public string Filter(string text)
        {
            text = FilterHasFile(text);
            
            return text;
        }

        private string FilterHasFile(string text)
        {
            const string startTag = "[HasFile:";
            int indexOfStart = text.IndexOf(startTag, StringComparison.InvariantCulture);
            if (indexOfStart == -1)
                return text;

            const string endTag = "]";
            int indexOfEnd = text.IndexOf(endTag, StringComparison.InvariantCulture);
            
            string data = text.Substring(indexOfStart + startTag.Length, indexOfEnd - indexOfStart - startTag.Length);

            string[] split = data.Split(':');
            if (split.Length != 3)
            {
                Debug.LogError($"Invalid data to parse HasData '{data}'");
                return text;
            }
            
            string result = text.Substring(0, indexOfStart);
            
            string dataId = split[0];
            if (_inventory.FileIds.Contains(dataId))
                result += split[1];
            else
                result += split[2];
            
            result += text.Substring(indexOfEnd + endTag.Length);
            
            return result;
        }
    }
}