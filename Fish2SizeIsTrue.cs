using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using HarmonyLib;
using BepInEx;
using UnityEngine.Audio;
using System.Runtime.Serialization.Formatters;
using System.IO;
using UnityEngine.SceneManagement;

namespace Fish2SizeIsTrue
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Fish2SizeIsTrue : BaseUnityPlugin
    {
        public const string pluginGuid = "swish.ultrakill.fish2sizeistrue";
        public const string pluginName = "Fish 2 size is true?";
        public const string pluginVersion = "1.0.0";

        private GameObject sizeTextContainer;

        private float sizeMin = 0.5f;
        private float sizeMax = 2.5f;
        private float size;

        private bool isAllObjectsFinded = false;

        public void Awake()
        {
            Logger.LogInfo("Fish2SizeIsTrue Awaked");
        }

        public void Update()
        {
            if (!isAllObjectsFinded)
            {
                sizeTextContainer = GameObject.Find("Fish Size Text");
                if (sizeTextContainer != null)
                {
                    Logger.LogInfo("Text finded, starting mod");
                    sizeTextContainer.GetComponent<Text>().horizontalOverflow = HorizontalWrapMode.Overflow;
                    isAllObjectsFinded = true;
                }
            }
            else
            {
                if (sizeTextContainer.activeSelf)
                {
                    if (size == 0)
                    {
                        size = Random.Range(sizeMin, sizeMax);
                        string sizeText = "SIZE:" + size.ToString();
                        sizeTextContainer.GetComponent<Text>().text = sizeText.Remove(9, 4);
                        //SIZE: 1.608681
                    }
                }
                else
                {
                    size = 0;
                }
            }
        }
    }
}
