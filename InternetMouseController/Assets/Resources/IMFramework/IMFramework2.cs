using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IMFramework2
{
    static IMFramework2 Instance = new IMFramework2();
    static List<IMBeanFrameworkConfig> facades = GetFacade();

    public static IMFramework2 GetInstance()
    {
        return Instance;
    }

    public void Main(MonoBehaviour component, IMEnumEvent enumEvent)
    {
        try
        {
            var configs =
                from p in facades
                where p.GameObjectName == component.gameObject.name
                && p.EventName == enumEvent
                select p;
            foreach (var config in configs)
            {
                var coroutine = config.Facade.Main(component);
                if (coroutine != null)
                {
                    IMCoroutine.CoroutineList.Add(coroutine);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    static List<IMBeanFrameworkConfig> GetFacade()
    {
        var beanFramework = new IMBeanFramework();
        var list = new List<IMBeanFrameworkConfig>();
      //list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMenuMouse"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Menu(          beanFramework, "CanvasBack", "IMPrefab/IMSpriteMouse"   , "IMSpriteMouseQueueIdInput"       , "IMSpriteMouseQueueIdInput"       , "IMSpriteMouseQueuePwdInput"       , "IMSpriteMouseQueuePwdInput"       )));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMenuKeyboar"                 , IMEnumEvent.OnPointerDown    , new IMFacade2Menu(          beanFramework, "CanvasBack", "IMPrefab/IMSpriteKeyboard", "IMSpriteMouseQueueIdInput"       , "IMSpriteKeyboardQueueIdInput"    , "IMSpriteMouseQueuePwdInput"       , "IMSpriteKeyboardQueuePwdInput"    )));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMenuNumpad"                  , IMEnumEvent.OnPointerDown    , new IMFacade2Menu(          beanFramework, "CanvasBack", "IMPrefab/IMSpriteNumpad"  , "IMSpriteMouseQueueIdInput"       , "IMSpriteNumpadQueueIdInput"      , "IMSpriteMouseQueuePwdInput"       , "IMSpriteNumpadQueuePwdInput"      )));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMenuMouse"                , IMEnumEvent.OnPointerDown    , new IMFacade2Menu(          beanFramework, "CanvasBack", "IMPrefab/IMSpriteMouse"   , "IMSpriteKeyboardQueueIdInput"    , "IMSpriteMouseQueueIdInput"       , "IMSpriteKeyboardQueuePwdInput"    , "IMSpriteMouseQueuePwdInput"       )));
      //list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMenuKeybord"              , IMEnumEvent.OnPointerDown    , new IMFacade2Menu(          beanFramework, "CanvasBack", "IMPrefab/IMSpriteKeyboard", "IMSpriteKeyboardQueueIdInput"    , "IMSpriteKeyboardQueueIdInput"    , "IMSpriteKeyboardQueuePwdInput"    , "IMSpriteKeyboardQueuePwdInput"    )));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMenuNumpad"               , IMEnumEvent.OnPointerDown    , new IMFacade2Menu(          beanFramework, "CanvasBack", "IMPrefab/IMSpriteNumpad"  , "IMSpriteKeyboardQueueIdInput"    , "IMSpriteNumpadQueueIdInput"      , "IMSpriteKeyboardQueuePwdInput"    , "IMSpriteNumpadQueuePwdInput"      )));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadMenuMouse"                  , IMEnumEvent.OnPointerDown    , new IMFacade2Menu(          beanFramework, "CanvasBack", "IMPrefab/IMSpriteMouse"   , "IMSpriteNumpadQueueIdInput"      , "IMSpriteMouseQueueIdInput"       , "IMSpriteNumpadQueuePwdInput"      , "IMSpriteMouseQueuePwdInput"       )));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadMenuKeyboar"                , IMEnumEvent.OnPointerDown    , new IMFacade2Menu(          beanFramework, "CanvasBack", "IMPrefab/IMSpriteKeyboard", "IMSpriteNumpadQueueIdInput"      , "IMSpriteKeyboardQueueIdInput"    , "IMSpriteNumpadQueuePwdInput"      , "IMSpriteKeyboardQueuePwdInput"    )));
      //list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadMenuNumpad"                 , IMEnumEvent.OnPointerDown    , new IMFacade2Menu(          beanFramework, "CanvasBack", "IMPrefab/IMSpriteNumpad"  , "IMSpriteNumpadQueueIdInput"      , "IMSpriteNumpadQueueIdInput"      , "IMSpriteNumpadQueuePwdInput"      , "IMSpriteNumpadQueuePwdInput"      )));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainLClick"                  , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "M,0002,,,")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainLClick"                  , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "M,0004,,,")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainRClick"                  , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "M,0008,,,")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainRClick"                  , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "M,0010,,,")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainMClick"                  , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "M,0020,,,")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainMClick"                  , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "M,0040,,,")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainZoomIn"                  , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,11,0,M,0800,,,120,K,11,2" )));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainZoomOut"                 , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,11,0,M,0800,,,-120,K,11,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainScrollLeft"              , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,91,0,K,91,2,K,25,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainScrollLeft"              , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,25,2,K,91,0,K,91,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainScrollRight"             , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,91,0,K,91,2,K,27,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainScrollRight"             , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,27,2,K,91,0,K,91,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonLeft"                  , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,25,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonLeft"                  , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,25,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonUp"                    , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,26,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonUp"                    , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,26,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonRight"                 , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,27,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonRight"                 , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,27,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonDown"                  , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,28,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonDown"                  , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,28,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonCtrlPageUp"            , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,A2,0,K,21,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonCtrlPageUp"            , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,A2,2,K,21,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonCtrlPageDown"          , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,A2,0,K,22,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonCtrlPageDown"          , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,A2,2,K,22,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain01"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,01,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain01"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,01,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain02"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,02,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain02"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,02,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain03"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,03,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain03"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,03,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain04"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,04,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain04"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,04,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain05"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,05,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain05"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,05,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain06"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,06,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain06"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,06,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain07"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,07,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain07"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,07,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain08"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,08,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain08"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,08,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain09"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,09,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain09"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,09,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0A"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0A,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0A"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0A,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0B"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0B,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0B"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0B,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0C"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0C,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0C"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0C,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0D1"                  , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0D,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0D1"                  , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0D,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0D2"                  , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0D,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0D2"                  , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0D,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0E"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0E,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0E"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0E,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0F"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0F,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0F"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0F,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain10"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,10,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain10"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,10,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain11"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,11,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain11"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,11,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain12"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,12,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain12"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,12,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain13"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,13,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain13"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,13,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain14"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,14,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain14"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,14,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain15"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,15,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain15"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,15,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain16"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,16,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain16"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,16,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain17"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,17,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain17"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,17,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain18"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,18,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain18"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,18,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain19"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,19,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain19"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,19,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1A"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1A,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1A"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1A,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1B"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1B,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1B"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1B,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1C"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1C,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1C"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1C,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1D"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1D,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1D"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1D,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1E"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1E,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1E"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1E,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1F"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1F,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1F"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1F,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain20"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,20,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain20"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,20,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain21"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,21,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain21"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,21,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain22"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,22,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain22"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,22,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain23"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,23,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain23"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,23,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain24"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,24,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain24"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,24,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain25"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,25,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain25"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,25,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain26"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,26,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain26"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,26,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain27"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,27,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain27"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,27,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain28"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,28,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain28"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,28,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain29"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,29,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain29"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,29,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2A"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2A,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2A"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2A,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2B"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2B,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2B"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2B,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2C"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2C,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2C"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2C,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2D"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2D,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2D"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2D,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2E"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2E,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2E"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2E,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2F"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2F,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2F"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2F,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain30"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,30,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain30"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,30,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain31"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,31,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain31"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,31,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain32"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,32,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain32"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,32,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain33"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,33,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain33"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,33,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain34"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,34,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain34"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,34,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain35"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,35,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain35"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,35,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain36"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,36,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain36"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,36,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain37"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,37,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain37"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,37,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain38"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,38,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain38"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,38,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain39"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,39,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain39"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,39,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3A"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3A,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3A"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3A,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3B"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3B,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3B"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3B,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3C"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3C,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3C"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3C,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3D"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3D,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3D"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3D,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3E"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3E,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3E"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3E,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3F"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3F,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3F"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3F,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain40"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,40,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain40"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,40,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain41"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,41,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain41"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,41,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain42"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,42,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain42"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,42,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain43"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,43,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain43"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,43,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain44"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,44,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain44"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,44,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain45"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,45,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain45"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,45,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain46"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,46,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain46"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,46,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain47"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,47,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain47"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,47,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain48"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,48,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain48"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,48,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain49"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,49,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain49"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,49,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4A"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4A,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4A"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4A,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4B"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4B,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4B"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4B,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4C"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4C,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4C"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4C,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4D"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4D,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4D"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4D,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4E"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4E,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4E"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4E,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4F"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4F,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4F"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4F,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain50"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,50,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain50"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,50,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain51"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,51,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain51"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,51,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain52"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,52,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain52"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,52,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain53"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,53,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain53"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,53,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain54"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,54,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain54"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,54,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain55"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,55,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain55"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,55,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain56"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,56,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain56"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,56,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain57"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,57,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain57"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,57,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain58"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,58,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain58"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,58,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain59"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,59,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain59"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,59,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5A"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5A,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5A"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5A,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5B"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5B,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5B"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5B,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5C"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5C,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5C"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5C,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5D"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5D,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5D"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5D,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5E"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5E,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5E"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5E,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5F"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5F,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5F"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5F,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain60"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,60,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain60"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,60,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain61"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,61,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain61"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,61,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain62"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,62,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain62"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,62,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain63"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,63,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain63"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,63,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain64"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,64,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain64"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,64,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain65"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,65,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain65"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,65,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain66"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,66,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain66"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,66,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain67"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,67,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain67"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,67,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain68"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,68,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain68"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,68,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain69"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,69,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain69"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,69,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6A"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6A,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6A"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6A,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6B"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6B,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6B"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6B,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6C"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6C,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6C"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6C,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6D"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6D,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6D"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6D,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6E"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6E,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6E"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6E,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6F"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6F,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6F"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6F,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain70"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,70,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain70"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,70,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain71"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,71,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain71"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,71,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain72"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,72,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain72"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,72,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain73"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,73,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain73"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,73,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain74"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,74,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain74"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,74,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain75"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,75,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain75"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,75,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain76"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,76,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain76"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,76,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain77"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,77,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain77"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,77,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain78"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,78,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain78"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,78,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain79"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,79,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain79"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,79,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7A"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7A,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7A"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7A,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7B"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7B,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7B"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7B,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7C"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7C,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7C"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7C,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7D"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7D,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7D"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7D,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7E"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7E,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7E"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7E,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7F"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7F,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7F"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7F,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain80"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,80,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain80"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,80,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain81"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,81,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain81"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,81,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain82"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,82,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain82"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,82,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain83"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,83,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain83"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,83,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain84"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,84,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain84"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,84,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain85"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,85,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain85"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,85,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain86"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,86,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain86"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,86,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain87"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,87,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain87"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,87,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain88"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,88,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain88"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,88,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain89"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,89,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain89"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,89,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8A"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8A,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8A"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8A,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8B"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8B,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8B"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8B,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8C"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8C,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8C"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8C,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8D"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8D,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8D"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8D,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8E"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8E,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8E"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8E,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8F"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8F,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8F"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8F,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain90"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,90,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain90"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,90,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain91"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,91,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain91"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,91,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain92"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,92,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain92"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,92,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain93"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,93,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain93"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,93,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain94"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,94,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain94"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,94,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain95"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,95,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain95"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,95,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain96"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,96,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain96"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,96,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain97"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,97,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain97"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,97,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain98"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,98,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain98"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,98,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain99"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,99,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain99"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,99,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9A"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9A,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9A"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9A,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9B"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9B,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9B"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9B,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9C"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9C,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9C"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9C,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9D"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9D,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9D"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9D,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9E"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9E,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9E"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9E,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9F"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9F,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9F"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9F,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA0"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A0,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA0"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A0,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA1"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A1,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA1"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A1,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA2"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A2,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA2"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A2,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA3"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A3,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA3"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A3,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA4"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A4,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA4"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A4,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA5"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A5,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA5"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A5,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA6"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A6,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA6"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A6,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA7"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A7,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA7"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A7,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA8"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A8,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA8"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A8,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA9"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A9,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA9"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A9,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAA"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AA,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAA"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AA,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAB"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AB,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAB"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AB,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAC"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AC,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAC"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AC,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAD"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AD,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAD"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AD,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAE"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AE,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAE"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AE,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAF"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AF,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAF"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AF,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB0"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B0,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB0"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B0,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB1"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B1,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB1"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B1,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB2"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B2,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB2"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B2,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB3"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B3,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB3"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B3,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB4"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B4,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB4"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B4,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB5"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B5,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB5"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B5,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB6"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B6,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB6"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B6,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB7"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B7,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB7"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B7,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB8"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B8,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB8"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B8,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB9"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B9,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB9"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B9,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBA"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BA,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBA"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BA,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBB"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BB,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBB"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BB,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBC"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BC,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBC"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BC,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBD"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BD,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBD"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BD,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBE"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BE,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBE"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BE,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBF"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BF,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBF"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BF,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC0"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C0,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC0"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C0,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC1"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C1,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC1"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C1,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC2"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C2,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC2"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C2,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC3"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C3,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC3"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C3,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC4"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C4,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC4"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C4,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC5"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C5,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC5"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C5,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC6"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C6,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC6"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C6,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC7"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C7,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC7"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C7,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC8"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C8,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC8"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C8,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC9"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C9,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC9"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C9,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCA"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CA,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCA"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CA,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCB"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CB,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCB"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CB,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCC"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CC,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCC"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CC,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCD"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CD,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCD"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CD,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCE"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CE,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCE"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CE,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCF"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CF,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCF"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CF,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD0"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D0,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD0"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D0,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD1"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D1,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD1"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D1,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD2"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D2,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD2"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D2,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD3"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D3,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD3"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D3,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD4"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D4,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD4"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D4,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD5"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D5,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD5"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D5,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD6"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D6,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD6"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D6,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD7"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D7,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD7"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D7,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD8"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D8,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD8"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D8,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD9"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D9,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD9"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D9,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDA"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DA,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDA"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DA,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDB"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DB,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDB"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DB,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDC"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DC,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDC"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DC,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDD"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DD,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDD"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DD,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDE"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DE,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDE"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DE,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDF"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DF,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDF"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DF,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE0"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E0,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE0"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E0,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE1"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E1,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE1"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E1,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE2"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E2,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE2"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E2,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE3"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E3,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE3"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E3,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE4"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E4,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE4"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E4,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE5"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E5,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE5"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E5,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE6"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E6,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE6"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E6,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE7"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E7,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE7"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E7,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE8"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E8,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE8"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E8,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE9"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E9,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE9"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E9,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEA"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EA,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEA"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EA,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEB"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EB,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEB"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EB,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEC"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EC,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEC"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EC,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainED"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,ED,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainED"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,ED,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEE"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EE,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEE"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EE,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEF"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EF,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEF"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EF,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF0"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F0,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF0"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F0,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF1"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F1,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF1"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F1,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF2"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F2,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF2"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F2,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF3"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F3,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF3"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F3,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF4"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F4,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF4"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F4,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF5"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F5,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF5"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F5,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF6"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F6,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF6"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F6,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF7"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F7,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF7"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F7,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF8"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F8,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF8"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F8,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF9"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F9,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF9"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F9,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFA"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FA,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFA"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FA,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFB"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FB,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFB"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FB,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFC"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FC,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFC"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FC,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFD"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FD,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFD"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FD,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFE"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FE,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFE"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FE,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFF"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FF,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFF"                   , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FF,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross2D"                    , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,2D,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross2D"                    , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,2D,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross24"                    , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,24,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross24"                    , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,24,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross21"                    , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,21,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross21"                    , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,21,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross22"                    , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,22,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross22"                    , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,22,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross23"                    , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,23,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross23"                    , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,23,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross25"                    , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,25,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross25"                    , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,25,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross26"                    , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,26,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross26"                    , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,26,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross27"                    , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,27,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross27"                    , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,27,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross28"                    , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,28,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross28"                    , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,28,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross2E"                    , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,2E,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross2E"                    , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,2E,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCrossA0"                    , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,A0,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCrossA0"                    , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,A0,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCrossA2"                    , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,A2,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCrossA2"                    , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,A2,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCrossA4"                    , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,A4,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCrossA4"                    , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,A4,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum0D"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,0D,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum0D"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,0D,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum13"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,13,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum13"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,13,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum2C"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,2C,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum2C"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,2C,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum60"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,60,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum60"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,60,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum61"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,61,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum61"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,61,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum62"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,62,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum62"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,62,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum63"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,63,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum63"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,63,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum64"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,64,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum64"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,64,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum65"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,65,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum65"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,65,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum66"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,66,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum66"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,66,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum67"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,67,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum67"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,67,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum68"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,68,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum68"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,68,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum69"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,69,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum69"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,69,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6A"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,6A,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6A"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,6A,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6B"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,6B,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6B"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,6B,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6C"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,6C,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6C"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,6C,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6D"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,6D,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6D"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,6D,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6E"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,6E,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6E"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,6E,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6F"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,6F,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6F"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,6F,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum90"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,90,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum90"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,90,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum91"                      , IMEnumEvent.OnPointerDown    , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,91,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum91"                      , IMEnumEvent.OnPointerUp      , new IMFacade2Button(        beanFramework, "IMSpriteNumpadQueueIdInput"  , "IMSpriteNumpadQueuePwdInput"  , "K,91,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF0F2"                 , IMEnumEvent.OnPointerDown    , new IMFacade2Toggle(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F0,0", "K,F2,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF0F2"                 , IMEnumEvent.OnPointerUp      , new IMFacade2Toggle(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F0,2", "K,F2,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF3F4"                 , IMEnumEvent.OnPointerDown    , new IMFacade2Toggle(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F3,0", "K,F4,0")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF3F4"                 , IMEnumEvent.OnPointerUp      , new IMFacade2Toggle(        beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F3,2", "K,F4,2")));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainMouseControlJoystick"    , IMEnumEvent.Update           , new IMFacade2JoystickTime(  beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "M,0001,{0},{1},"                              ,200  , 200   , "IMSpriteMouseMainMouseControlJoystick"   , "IMSpriteMouseMainMouseControlJoystickHorizontal"   , "IMSpriteMouseMainMouseControlJoystickVertical"   , "IMSpriteMouseMainMouse"   )));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainScrollControlJoystick"   , IMEnumEvent.Update           , new IMFacade2JoystickTime(  beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "M,1000,,,{0},M,0800,,,{1}"                    ,1000 , -1000 , "IMSpriteMouseMainScrollControlJoystick"  , "IMSpriteMouseMainScrollControlJoystickHorizontal"  , "IMSpriteMouseMainScrollControlJoystickVertical"  , "IMSpriteMouseMainScroll"  )));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonAltTabControlJoystick" , IMEnumEvent.OnPointerDown    , new IMFacade2JoystickButton(beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,A4,0", true )));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonAltTabControlJoystick" , IMEnumEvent.OnPointerUp      , new IMFacade2JoystickButton(beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,A4,2", false)));
        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonAltTabControlJoystick" , IMEnumEvent.Update           , new IMFacade2JoystickPos(   beanFramework, "IMSpriteMouseQueueIdInput"   , "IMSpriteMouseQueuePwdInput"   , "K,1B,0,K,1B,2", "K,A0,0,K,1B,0,K,1B,2,K,A0,2" ,10           , "IMSpriteMouseButtonAltTabControlJoystick", "IMSpriteMouseButtonAltTabControlJoystickHorizontal", "IMSpriteMouseButtonAltTabControlJoystickVertical", "IMSpriteMouseButtonAltTab")));

        return list;
    }

    //MOUSEEVENTF_MOVE            = 0001
    //MOUSEEVENTF_LEFTDOWN        = 0002
    //MOUSEEVENTF_LEFTUP          = 0004
    //MOUSEEVENTF_RIGHTDOWN       = 0008
    //MOUSEEVENTF_RIGHTUP         = 0010
    //MOUSEEVENTF_MIDDLEDOWN      = 0020
    //MOUSEEVENTF_MIDDLEUP        = 0040
    //MOUSEEVENTF_XDOWN           = 0080
    //MOUSEEVENTF_XUP             = 0100
    //MOUSEEVENTF_WHEEL           = 0800
    //MOUSEEVENTF_HWHEEL          = 1000
    //MOUSEEVENTF_MOVE_NOCOALESCE = 2000
    //MOUSEEVENTF_VIRTUALDESK     = 4000
    //MOUSEEVENTF_ABSOLUTE        = 8000
    //VK_LBUTTON                  = 01
    //VK_RBUTTON                  = 02
    //VK_CANCEL                   = 03
    //VK_MBUTTON                  = 04
    //VK_XBUTTON1                 = 05
    //VK_XBUTTON2                 = 06
    //VK_BACK                     = 08
    //VK_TAB                      = 09
    //VK_CLEAR                    = 0C
    //VK_RETURN                   = 0D
    //VK_SHIFT                    = 10
    //VK_CONTROL                  = 11
    //VK_MENU                     = 12
    //VK_PAUSE                    = 13
    //VK_CAPITAL                  = 14
    //VK_KANA                     = 15
    //VK_HANGEUL                  = 15
    //VK_HANGUL                   = 15
    //VK_JUNJA                    = 17
    //VK_FINAL                    = 18
    //VK_HANJA                    = 19
    //VK_KANJI                    = 19
    //VK_ESCAPE                   = 1B
    //VK_CONVERT                  = 1C
    //VK_NONCONVERT               = 1D
    //VK_ACCEPT                   = 1E
    //VK_MODECHANGE               = 1F
    //VK_SPACE                    = 20
    //VK_PRIOR                    = 21
    //VK_NEXT                     = 22
    //VK_END                      = 23
    //VK_HOME                     = 24
    //VK_LEFT                     = 25
    //VK_UP                       = 26
    //VK_RIGHT                    = 27
    //VK_DOWN                     = 28
    //VK_SELECT                   = 29
    //VK_PRINT                    = 2A
    //VK_EXECUTE                  = 2B
    //VK_SNAPSHOT                 = 2C
    //VK_INSERT                   = 2D
    //VK_DELETE                   = 2E
    //VK_HELP                     = 2F
    //VK_0                        = 30
    //VK_1                        = 31
    //VK_2                        = 32
    //VK_3                        = 33
    //VK_4                        = 34
    //VK_5                        = 35
    //VK_6                        = 36
    //VK_7                        = 37
    //VK_8                        = 38
    //VK_9                        = 39
    //VK_A                        = 41
    //VK_B                        = 42
    //VK_C                        = 43
    //VK_D                        = 44
    //VK_E                        = 45
    //VK_F                        = 46
    //VK_G                        = 47
    //VK_H                        = 48
    //VK_I                        = 49
    //VK_J                        = 4A
    //VK_K                        = 4B
    //VK_L                        = 4C
    //VK_M                        = 4D
    //VK_N                        = 4E
    //VK_O                        = 4F
    //VK_P                        = 50
    //VK_Q                        = 51
    //VK_R                        = 52
    //VK_S                        = 53
    //VK_T                        = 54
    //VK_U                        = 55
    //VK_V                        = 56
    //VK_W                        = 57
    //VK_X                        = 58
    //VK_Y                        = 59
    //VK_Z                        = 5A
    //VK_LWIN                     = 5B
    //VK_RWIN                     = 5C
    //VK_APPS                     = 5D
    //VK_SLEEP                    = 5F
    //VK_NUMPAD0                  = 60
    //VK_NUMPAD1                  = 61
    //VK_NUMPAD2                  = 62
    //VK_NUMPAD3                  = 63
    //VK_NUMPAD4                  = 64
    //VK_NUMPAD5                  = 65
    //VK_NUMPAD6                  = 66
    //VK_NUMPAD7                  = 67
    //VK_NUMPAD8                  = 68
    //VK_NUMPAD9                  = 69
    //VK_MULTIPLY                 = 6A
    //VK_ADD                      = 6B
    //VK_SEPARATOR                = 6C
    //VK_SUBTRACT                 = 6D
    //VK_DECIMAL                  = 6E
    //VK_DIVIDE                   = 6F
    //VK_F1                       = 70
    //VK_F2                       = 71
    //VK_F3                       = 72
    //VK_F4                       = 73
    //VK_F5                       = 74
    //VK_F6                       = 75
    //VK_F7                       = 76
    //VK_F8                       = 77
    //VK_F9                       = 78
    //VK_F10                      = 79
    //VK_F11                      = 7A
    //VK_F12                      = 7B
    //VK_F13                      = 7C
    //VK_F14                      = 7D
    //VK_F15                      = 7E
    //VK_F16                      = 7F
    //VK_F17                      = 80
    //VK_F18                      = 81
    //VK_F19                      = 82
    //VK_F20                      = 83
    //VK_F21                      = 84
    //VK_F22                      = 85
    //VK_F23                      = 86
    //VK_F24                      = 87
    //VK_NUMLOCK                  = 90
    //VK_SCROLL                   = 91
    //VK_OEM_NEC_EQUAL            = 92
    //VK_OEM_FJ_JISHO             = 92
    //VK_OEM_FJ_MASSHOU           = 93
    //VK_OEM_FJ_TOUROKU           = 94
    //VK_OEM_FJ_LOYA              = 95
    //VK_OEM_FJ_ROYA              = 96
    //VK_LSHIFT                   = A0
    //VK_RSHIFT                   = A1
    //VK_LCONTROL                 = A2
    //VK_RCONTROL                 = A3
    //VK_LMENU                    = A4
    //VK_RMENU                    = A5
    //VK_BROWSER_BACK             = A6
    //VK_BROWSER_FORWARD          = A7
    //VK_BROWSER_REFRESH          = A8
    //VK_BROWSER_STOP             = A9
    //VK_BROWSER_SEARCH           = AA
    //VK_BROWSER_FAVORITES        = AB
    //VK_BROWSER_HOME             = AC
    //VK_VOLUME_MUTE              = AD
    //VK_VOLUME_DOWN              = AE
    //VK_VOLUME_UP                = AF
    //VK_MEDIA_NEXT_TRACK         = B0
    //VK_MEDIA_PREV_TRACK         = B1
    //VK_MEDIA_STOP               = B2
    //VK_MEDIA_PLAY_PAUSE         = B3
    //VK_LAUNCH_MAIL              = B4
    //VK_LAUNCH_MEDIA_SELECT      = B5
    //VK_LAUNCH_APP1              = B6
    //VK_LAUNCH_APP2              = B7
    //VK_OEM_1                    = BA
    //VK_OEM_PLUS                 = BB
    //VK_OEM_COMMA                = BC
    //VK_OEM_MINUS                = BD
    //VK_OEM_PERIOD               = BE
    //VK_OEM_2                    = BF
    //VK_OEM_3                    = C0
    //VK_OEM_4                    = DB
    //VK_OEM_5                    = DC
    //VK_OEM_6                    = DD
    //VK_OEM_7                    = DE
    //VK_OEM_8                    = DF
    //VK_OEM_AX                   = E1
    //VK_OEM_102                  = E2
    //VK_ICO_HELP                 = E3
    //VK_ICO_00                   = E4
    //VK_PROCESSKEY               = E5
    //VK_ICO_CLEAR                = E6
    //VK_PACKET                   = E7
    //VK_OEM_RESET                = E9
    //VK_OEM_JUMP                 = EA
    //VK_OEM_PA1                  = EB
    //VK_OEM_PA2                  = EC
    //VK_OEM_PA3                  = ED
    //VK_OEM_WSCTRL               = EE
    //VK_OEM_CUSEL                = EF
    //VK_OEM_ATTN                 = F0
    //VK_OEM_FINISH               = F1
    //VK_OEM_COPY                 = F2
    //VK_OEM_AUTO                 = F3
    //VK_OEM_ENLW                 = F4
    //VK_OEM_BACKTAB              = F5
    //VK_ATTN                     = F6
    //VK_CRSEL                    = F7
    //VK_EXSEL                    = F8
    //VK_EREOF                    = F9
    //VK_PLAY                     = FA
    //VK_ZOOM                     = FB
    //VK_NONAME                   = FC
    //VK_PA1                      = FD
    //VK_OEM_CLEAR                = FE
    //KEYEVENTF_KEYDOWN           = 0000
    //KEYEVENTF_EXTENDEDKEY       = 0001
    //KEYEVENTF_KEYUP             = 0002
    //KEYEVENTF_UNICODE           = 0004
    //KEYEVENTF_SCANCODE          = 0008
}








//using System;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//public class IMFramework2
//{
//    static IMFramework2 Instance = new IMFramework2();
//    static List<IMBeanFrameworkConfig> facades = GetFacade();

//    public static IMFramework2 GetInstance()
//    {
//        return Instance;
//    }

//    public void Main(MonoBehaviour component, IMEnumEvent enumEvent)
//    {
//        try
//        {
//            var configs =
//                from p in facades
//                where p.GameObjectName == component.gameObject.name
//                && p.EventName == enumEvent
//                select p;
//            foreach (var config in configs)
//            {
//                var coroutine = config.Facade.Main(component);
//                if (coroutine != null)
//                {
//                    IMCoroutine.CoroutineList.Add(coroutine);
//                }
//            }
//        }
//        catch (Exception e)
//        {
//            Debug.LogException(e);
//        }
//    }

//    static List<IMBeanFrameworkConfig> GetFacade()
//    {
//        var beanFramework = new IMBeanFramework();
//        var list = new List<IMBeanFrameworkConfig>();
//        //list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMenuMouse"                   , IMEnumEvent.OnPointerDown    , new IMFacade2Menu(          beanFramework, "CanvasBack", "IMPrefab/IMSpriteMouse"   , "IMSpriteMouseQueueIdInput"       , "IMSpriteMouseQueueIdInput"       , "IMSpriteMouseQueuePwdInput"       , "IMSpriteMouseQueuePwdInput"       )));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMenuKeyboar", IMEnumEvent.OnPointerDown, new IMFacade2Menu(beanFramework, "CanvasBack", "IMPrefab/IMSpriteKeyboard", "IMSpriteMouseQueueIdInput", "IMSpriteKeyboardQueueIdInput", "IMSpriteMouseQueuePwdInput", "IMSpriteKeyboardQueuePwdInput")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMenuNumpad", IMEnumEvent.OnPointerDown, new IMFacade2Menu(beanFramework, "CanvasBack", "IMPrefab/IMSpriteNumpad", "IMSpriteMouseQueueIdInput", "IMSpriteNumpadQueueIdInput", "IMSpriteMouseQueuePwdInput", "IMSpriteNumpadQueuePwdInput")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMenuMouse", IMEnumEvent.OnPointerDown, new IMFacade2Menu(beanFramework, "CanvasBack", "IMPrefab/IMSpriteMouse", "IMSpriteKeyboardQueueIdInput", "IMSpriteMouseQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "IMSpriteMouseQueuePwdInput")));
//        //list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMenuKeybord"              , IMEnumEvent.OnPointerDown    , new IMFacade2Menu(          beanFramework, "CanvasBack", "IMPrefab/IMSpriteKeyboard", "IMSpriteKeyboardQueueIdInput"    , "IMSpriteKeyboardQueueIdInput"    , "IMSpriteKeyboardQueuePwdInput"    , "IMSpriteKeyboardQueuePwdInput"    )));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMenuNumpad", IMEnumEvent.OnPointerDown, new IMFacade2Menu(beanFramework, "CanvasBack", "IMPrefab/IMSpriteNumpad", "IMSpriteKeyboardQueueIdInput", "IMSpriteNumpadQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "IMSpriteNumpadQueuePwdInput")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadMenuMouse", IMEnumEvent.OnPointerDown, new IMFacade2Menu(beanFramework, "CanvasBack", "IMPrefab/IMSpriteMouse", "IMSpriteNumpadQueueIdInput", "IMSpriteMouseQueueIdInput", "IMSpriteNumpadQueuePwdInput", "IMSpriteMouseQueuePwdInput")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadMenuKeyboar", IMEnumEvent.OnPointerDown, new IMFacade2Menu(beanFramework, "CanvasBack", "IMPrefab/IMSpriteKeyboard", "IMSpriteNumpadQueueIdInput", "IMSpriteKeyboardQueueIdInput", "IMSpriteNumpadQueuePwdInput", "IMSpriteKeyboardQueuePwdInput")));
//        //list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadMenuNumpad"                 , IMEnumEvent.OnPointerDown    , new IMFacade2Menu(          beanFramework, "CanvasBack", "IMPrefab/IMSpriteNumpad"  , "IMSpriteNumpadQueueIdInput"      , "IMSpriteNumpadQueueIdInput"      , "IMSpriteNumpadQueuePwdInput"      , "IMSpriteNumpadQueuePwdInput"      )));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainLClick", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "M,0002,,,")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainLClick", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "M,0004,,,")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainRClick", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "M,0008,,,")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainRClick", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "M,0010,,,")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainMClick", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "M,0020,,,")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainMClick", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "M,0040,,,")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainZoomIn", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,11,1,M,0800,,,120,K,11,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainZoomOut", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,11,1,M,0800,,,-120,K,11,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainScrollLeft", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,91,1,K,91,3,K,25,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainScrollLeft", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,25,3,K,91,1,K,91,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainScrollRight", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,91,1,K,91,3,K,27,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainScrollRight", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,27,3,K,91,1,K,91,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonLeft", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,25,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonLeft", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,25,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonUp", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,26,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonUp", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,26,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonRight", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,27,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonRight", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,27,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonDown", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,28,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonDown", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,28,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonCtrlPageUp", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,A2,1,K,21,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonCtrlPageUp", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,A2,3,K,21,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonCtrlPageDown", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,A2,1,K,22,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonCtrlPageDown", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,A2,3,K,22,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain01", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,01,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain01", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,01,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain02", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,02,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain02", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,02,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain03", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,03,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain03", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,03,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain04", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,04,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain04", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,04,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain05", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,05,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain05", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,05,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain06", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,06,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain06", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,06,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain07", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,07,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain07", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,07,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain08", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,08,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain08", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,08,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain09", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,09,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain09", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,09,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0A", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0A,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0A", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0A,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0B", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0B,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0B", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0B,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0C", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0C,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0C", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0C,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0D1", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0D,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0D1", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0D,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0D2", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0D,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0D2", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0D,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0E", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0E,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0E", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0E,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0F", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0F,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain0F", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,0F,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain10", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,10,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain10", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,10,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain11", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,11,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain11", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,11,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain12", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,12,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain12", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,12,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain13", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,13,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain13", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,13,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain14", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,14,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain14", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,14,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain15", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,15,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain15", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,15,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain16", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,16,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain16", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,16,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain17", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,17,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain17", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,17,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain18", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,18,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain18", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,18,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain19", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,19,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain19", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,19,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1A", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1A,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1A", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1A,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1B", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1B,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1B", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1B,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1C", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1C,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1C", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1C,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1D", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1D,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1D", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1D,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1E", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1E,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1E", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1E,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1F", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1F,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain1F", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,1F,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain20", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,20,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain20", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,20,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain21", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,21,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain21", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,21,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain22", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,22,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain22", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,22,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain23", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,23,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain23", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,23,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain24", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,24,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain24", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,24,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain25", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,25,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain25", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,25,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain26", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,26,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain26", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,26,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain27", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,27,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain27", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,27,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain28", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,28,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain28", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,28,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain29", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,29,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain29", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,29,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2A", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2A,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2A", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2A,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2B", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2B,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2B", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2B,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2C", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2C,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2C", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2C,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2D", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2D,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2D", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2D,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2E", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2E,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2E", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2E,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2F", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2F,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain2F", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,2F,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain30", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,30,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain30", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,30,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain31", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,31,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain31", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,31,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain32", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,32,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain32", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,32,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain33", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,33,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain33", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,33,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain34", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,34,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain34", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,34,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain35", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,35,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain35", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,35,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain36", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,36,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain36", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,36,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain37", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,37,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain37", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,37,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain38", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,38,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain38", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,38,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain39", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,39,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain39", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,39,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3A", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3A,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3A", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3A,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3B", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3B,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3B", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3B,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3C", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3C,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3C", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3C,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3D", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3D,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3D", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3D,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3E", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3E,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3E", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3E,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3F", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3F,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain3F", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,3F,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain40", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,40,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain40", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,40,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain41", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,41,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain41", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,41,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain42", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,42,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain42", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,42,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain43", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,43,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain43", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,43,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain44", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,44,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain44", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,44,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain45", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,45,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain45", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,45,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain46", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,46,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain46", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,46,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain47", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,47,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain47", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,47,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain48", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,48,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain48", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,48,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain49", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,49,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain49", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,49,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4A", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4A,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4A", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4A,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4B", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4B,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4B", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4B,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4C", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4C,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4C", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4C,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4D", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4D,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4D", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4D,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4E", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4E,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4E", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4E,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4F", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4F,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain4F", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,4F,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain50", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,50,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain50", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,50,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain51", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,51,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain51", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,51,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain52", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,52,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain52", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,52,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain53", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,53,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain53", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,53,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain54", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,54,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain54", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,54,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain55", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,55,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain55", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,55,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain56", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,56,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain56", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,56,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain57", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,57,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain57", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,57,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain58", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,58,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain58", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,58,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain59", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,59,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain59", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,59,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5A", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5A,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5A", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5A,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5B", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5B,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5B", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5B,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5C", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5C,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5C", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5C,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5D", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5D,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5D", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5D,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5E", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5E,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5E", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5E,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5F", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5F,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain5F", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,5F,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain60", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,60,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain60", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,60,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain61", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,61,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain61", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,61,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain62", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,62,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain62", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,62,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain63", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,63,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain63", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,63,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain64", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,64,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain64", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,64,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain65", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,65,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain65", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,65,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain66", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,66,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain66", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,66,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain67", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,67,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain67", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,67,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain68", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,68,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain68", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,68,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain69", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,69,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain69", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,69,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6A", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6A,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6A", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6A,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6B", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6B,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6B", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6B,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6C", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6C,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6C", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6C,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6D", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6D,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6D", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6D,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6E", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6E,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6E", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6E,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6F", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6F,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain6F", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,6F,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain70", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,70,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain70", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,70,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain71", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,71,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain71", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,71,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain72", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,72,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain72", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,72,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain73", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,73,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain73", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,73,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain74", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,74,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain74", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,74,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain75", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,75,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain75", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,75,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain76", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,76,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain76", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,76,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain77", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,77,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain77", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,77,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain78", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,78,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain78", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,78,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain79", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,79,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain79", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,79,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7A", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7A,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7A", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7A,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7B", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7B,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7B", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7B,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7C", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7C,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7C", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7C,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7D", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7D,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7D", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7D,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7E", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7E,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7E", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7E,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7F", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7F,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain7F", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,7F,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain80", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,80,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain80", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,80,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain81", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,81,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain81", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,81,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain82", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,82,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain82", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,82,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain83", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,83,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain83", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,83,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain84", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,84,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain84", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,84,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain85", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,85,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain85", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,85,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain86", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,86,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain86", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,86,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain87", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,87,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain87", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,87,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain88", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,88,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain88", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,88,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain89", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,89,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain89", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,89,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8A", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8A,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8A", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8A,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8B", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8B,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8B", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8B,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8C", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8C,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8C", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8C,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8D", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8D,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8D", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8D,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8E", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8E,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8E", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8E,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8F", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8F,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain8F", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,8F,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain90", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,90,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain90", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,90,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain91", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,91,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain91", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,91,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain92", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,92,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain92", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,92,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain93", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,93,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain93", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,93,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain94", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,94,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain94", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,94,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain95", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,95,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain95", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,95,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain96", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,96,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain96", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,96,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain97", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,97,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain97", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,97,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain98", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,98,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain98", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,98,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain99", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,99,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain99", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,99,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9A", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9A,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9A", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9A,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9B", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9B,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9B", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9B,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9C", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9C,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9C", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9C,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9D", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9D,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9D", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9D,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9E", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9E,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9E", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9E,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9F", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9F,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMain9F", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,9F,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA0", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A0,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA0", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A0,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA1", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A1,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA1", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A1,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA2", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A2,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA2", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A2,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA3", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A3,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA3", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A3,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA4", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A4,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA4", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A4,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA5", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A5,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA5", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A5,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA6", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A6,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA6", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A6,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA7", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A7,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA7", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A7,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA8", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A8,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA8", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A8,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA9", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A9,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainA9", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,A9,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAA", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AA,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAA", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AA,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAB", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AB,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAB", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AB,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAC", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AC,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAC", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AC,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAD", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AD,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAD", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AD,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAE", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AE,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAE", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AE,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAF", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AF,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainAF", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,AF,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB0", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B0,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB0", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B0,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB1", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B1,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB1", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B1,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB2", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B2,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB2", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B2,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB3", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B3,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB3", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B3,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB4", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B4,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB4", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B4,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB5", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B5,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB5", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B5,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB6", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B6,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB6", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B6,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB7", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B7,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB7", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B7,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB8", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B8,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB8", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B8,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB9", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B9,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainB9", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,B9,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBA", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BA,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBA", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BA,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBB", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BB,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBB", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BB,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBC", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BC,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBC", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BC,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBD", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BD,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBD", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BD,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBE", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BE,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBE", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BE,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBF", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BF,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainBF", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,BF,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC0", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C0,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC0", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C0,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC1", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C1,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC1", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C1,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC2", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C2,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC2", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C2,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC3", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C3,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC3", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C3,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC4", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C4,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC4", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C4,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC5", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C5,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC5", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C5,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC6", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C6,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC6", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C6,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC7", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C7,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC7", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C7,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC8", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C8,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC8", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C8,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC9", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C9,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainC9", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,C9,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCA", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CA,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCA", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CA,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCB", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CB,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCB", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CB,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCC", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CC,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCC", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CC,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCD", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CD,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCD", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CD,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCE", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CE,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCE", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CE,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCF", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CF,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainCF", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,CF,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD0", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D0,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD0", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D0,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD1", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D1,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD1", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D1,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD2", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D2,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD2", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D2,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD3", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D3,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD3", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D3,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD4", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D4,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD4", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D4,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD5", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D5,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD5", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D5,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD6", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D6,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD6", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D6,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD7", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D7,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD7", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D7,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD8", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D8,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD8", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D8,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD9", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D9,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainD9", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,D9,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDA", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DA,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDA", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DA,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDB", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DB,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDB", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DB,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDC", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DC,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDC", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DC,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDD", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DD,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDD", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DD,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDE", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DE,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDE", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DE,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDF", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DF,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainDF", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,DF,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE0", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E0,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE0", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E0,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE1", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E1,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE1", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E1,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE2", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E2,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE2", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E2,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE3", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E3,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE3", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E3,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE4", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E4,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE4", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E4,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE5", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E5,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE5", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E5,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE6", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E6,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE6", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E6,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE7", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E7,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE7", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E7,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE8", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E8,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE8", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E8,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE9", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E9,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainE9", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,E9,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEA", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EA,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEA", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EA,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEB", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EB,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEB", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EB,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEC", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EC,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEC", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EC,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainED", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,ED,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainED", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,ED,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEE", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EE,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEE", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EE,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEF", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EF,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainEF", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,EF,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF0", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F0,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF0", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F0,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF1", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F1,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF1", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F1,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF2", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F2,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF2", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F2,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF3", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F3,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF3", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F3,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF4", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F4,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF4", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F4,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF5", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F5,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF5", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F5,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF6", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F6,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF6", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F6,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF7", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F7,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF7", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F7,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF8", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F8,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF8", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F8,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF9", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F9,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF9", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F9,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFA", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FA,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFA", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FA,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFB", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FB,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFB", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FB,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFC", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FC,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFC", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FC,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFD", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FD,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFD", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FD,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFE", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FE,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFE", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FE,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFF", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FF,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainFF", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,FF,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross2D", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,2D,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross2D", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,2D,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross24", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,24,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross24", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,24,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross49", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,49,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross49", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,49,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross22", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,22,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross22", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,22,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross23", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,23,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross23", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,23,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross25", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,25,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross25", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,25,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross26", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,26,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross26", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,26,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross27", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,27,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross27", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,27,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross28", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,28,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross28", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,28,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross53", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,53,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCross53", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,53,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCrossA0", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,A0,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCrossA0", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,A0,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCrossA2", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,A2,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCrossA2", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,A2,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCrossA4", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,A4,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadCrossA4", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,A4,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum0D", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,0D,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum0D", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,0D,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum13", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,13,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum13", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,13,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum2C", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,2C,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum2C", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,2C,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum60", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,60,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum60", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,60,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum61", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,61,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum61", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,61,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum62", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,62,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum62", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,62,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum63", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,63,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum63", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,63,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum64", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,64,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum64", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,64,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum65", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,65,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum65", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,65,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum66", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,66,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum66", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,66,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum67", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,67,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum67", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,67,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum68", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,68,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum68", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,68,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum69", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,69,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum69", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,69,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6A", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,6A,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6A", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,6A,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6B", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,6B,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6B", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,6B,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6C", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,6C,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6C", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,6C,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6D", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,6D,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6D", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,6D,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6E", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,6E,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6E", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,6E,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6F", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,6F,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum6F", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,6F,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum90", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,90,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum90", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,90,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum91", IMEnumEvent.OnPointerDown, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,91,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteNumpadNum91", IMEnumEvent.OnPointerUp, new IMFacade2Button(beanFramework, "IMSpriteNumpadQueueIdInput", "IMSpriteNumpadQueuePwdInput", "K,91,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF0F2", IMEnumEvent.OnPointerDownOn, new IMFacade2Toggle(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F0,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF0F2", IMEnumEvent.OnPointerDownOff, new IMFacade2Toggle(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F2,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF0F2", IMEnumEvent.OnPointerUpOn, new IMFacade2Toggle(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F0,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF0F2", IMEnumEvent.OnPointerUpOff, new IMFacade2Toggle(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F2,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF3F4", IMEnumEvent.OnPointerDownOn, new IMFacade2Toggle(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F3,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF3F4", IMEnumEvent.OnPointerDownOff, new IMFacade2Toggle(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F4,1")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF3F4", IMEnumEvent.OnPointerUpOn, new IMFacade2Toggle(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F3,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteKeyboardMainF3F4", IMEnumEvent.OnPointerUpOff, new IMFacade2Toggle(beanFramework, "IMSpriteKeyboardQueueIdInput", "IMSpriteKeyboardQueuePwdInput", "K,F4,3")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainMouseControlJoystick", IMEnumEvent.Update, new IMFacade2JoystickTime(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "M,0001,{0},{1},", 200, 200, "IMSpriteMouseMainMouseControlJoystick", "IMSpriteMouseMainMouseControlJoystickHorizontal", "IMSpriteMouseMainMouseControlJoystickVertical", "IMSpriteMouseMainMouse")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseMainScrollControlJoystick", IMEnumEvent.Update, new IMFacade2JoystickTime(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "M,1000,,,{0},M,0800,,,{1}", 1000, -1000, "IMSpriteMouseMainScrollControlJoystick", "IMSpriteMouseMainScrollControlJoystickHorizontal", "IMSpriteMouseMainScrollControlJoystickVertical", "IMSpriteMouseMainScroll")));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonAltTabControlJoystick", IMEnumEvent.OnPointerDown, new IMFacade2JoystickButton(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,A4,1", true)));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonAltTabControlJoystick", IMEnumEvent.OnPointerUp, new IMFacade2JoystickButton(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,A4,3", false)));
//        list.Add(new IMBeanFrameworkConfig("IMSpriteMouseButtonAltTabControlJoystick", IMEnumEvent.Update, new IMFacade2JoystickPos(beanFramework, "IMSpriteMouseQueueIdInput", "IMSpriteMouseQueuePwdInput", "K,09,1,K,09,3", "K,A0,1,K,09,1,K,09,3,K,A0,3", "IMSpriteMouseButtonAltTabControlJoystick", "IMSpriteMouseButtonAltTabControlJoystickHorizontal", "IMSpriteMouseButtonAltTabControlJoystickVertical", "IMSpriteMouseButtonAltTab")));

//        return list;
//    }

//    //MOUSEEVENTF_MOVE            = 0001
//    //MOUSEEVENTF_LEFTDOWN        = 0002
//    //MOUSEEVENTF_LEFTUP          = 0004
//    //MOUSEEVENTF_RIGHTDOWN       = 0008
//    //MOUSEEVENTF_RIGHTUP         = 0010
//    //MOUSEEVENTF_MIDDLEDOWN      = 0020
//    //MOUSEEVENTF_MIDDLEUP        = 0040
//    //MOUSEEVENTF_XDOWN           = 0080
//    //MOUSEEVENTF_XUP             = 0100
//    //MOUSEEVENTF_WHEEL           = 0800
//    //MOUSEEVENTF_HWHEEL          = 1000
//    //MOUSEEVENTF_MOVE_NOCOALESCE = 2000
//    //MOUSEEVENTF_VIRTUALDESK     = 4000
//    //MOUSEEVENTF_ABSOLUTE        = 8000
//    //VK_LBUTTON                  = 01
//    //VK_RBUTTON                  = 02
//    //VK_CANCEL                   = 03
//    //VK_MBUTTON                  = 04
//    //VK_XBUTTON1                 = 05
//    //VK_XBUTTON2                 = 06
//    //VK_BACK                     = 08
//    //VK_TAB                      = 09
//    //VK_CLEAR                    = 0C
//    //VK_RETURN                   = 0D
//    //VK_SHIFT                    = 10
//    //VK_CONTROL                  = 11
//    //VK_MENU                     = 12
//    //VK_PAUSE                    = 13
//    //VK_CAPITAL                  = 14
//    //VK_KANA                     = 15
//    //VK_HANGEUL                  = 15
//    //VK_HANGUL                   = 15
//    //VK_JUNJA                    = 17
//    //VK_FINAL                    = 18
//    //VK_HANJA                    = 19
//    //VK_KANJI                    = 19
//    //VK_ESCAPE                   = 1B
//    //VK_CONVERT                  = 1C
//    //VK_NONCONVERT               = 1D
//    //VK_ACCEPT                   = 1E
//    //VK_MODECHANGE               = 1F
//    //VK_SPACE                    = 20
//    //VK_PRIOR                    = 21
//    //VK_NEXT                     = 22
//    //VK_END                      = 23
//    //VK_HOME                     = 24
//    //VK_LEFT                     = 25
//    //VK_UP                       = 26
//    //VK_RIGHT                    = 27
//    //VK_DOWN                     = 28
//    //VK_SELECT                   = 29
//    //VK_PRINT                    = 2A
//    //VK_EXECUTE                  = 2B
//    //VK_SNAPSHOT                 = 2C
//    //VK_INSERT                   = 2D
//    //VK_DELETE                   = 2E
//    //VK_HELP                     = 2F
//    //VK_0                        = 30
//    //VK_1                        = 31
//    //VK_2                        = 32
//    //VK_3                        = 33
//    //VK_4                        = 34
//    //VK_5                        = 35
//    //VK_6                        = 36
//    //VK_7                        = 37
//    //VK_8                        = 38
//    //VK_9                        = 39
//    //VK_A                        = 41
//    //VK_B                        = 42
//    //VK_C                        = 43
//    //VK_D                        = 44
//    //VK_E                        = 45
//    //VK_F                        = 46
//    //VK_G                        = 47
//    //VK_H                        = 48
//    //VK_I                        = 49
//    //VK_J                        = 4A
//    //VK_K                        = 4B
//    //VK_L                        = 4C
//    //VK_M                        = 4D
//    //VK_N                        = 4E
//    //VK_O                        = 4F
//    //VK_P                        = 50
//    //VK_Q                        = 51
//    //VK_R                        = 52
//    //VK_S                        = 53
//    //VK_T                        = 54
//    //VK_U                        = 55
//    //VK_V                        = 56
//    //VK_W                        = 57
//    //VK_X                        = 58
//    //VK_Y                        = 59
//    //VK_Z                        = 5A
//    //VK_LWIN                     = 5B
//    //VK_RWIN                     = 5C
//    //VK_APPS                     = 5D
//    //VK_SLEEP                    = 5F
//    //VK_NUMPAD0                  = 60
//    //VK_NUMPAD1                  = 61
//    //VK_NUMPAD2                  = 62
//    //VK_NUMPAD3                  = 63
//    //VK_NUMPAD4                  = 64
//    //VK_NUMPAD5                  = 65
//    //VK_NUMPAD6                  = 66
//    //VK_NUMPAD7                  = 67
//    //VK_NUMPAD8                  = 68
//    //VK_NUMPAD9                  = 69
//    //VK_MULTIPLY                 = 6A
//    //VK_ADD                      = 6B
//    //VK_SEPARATOR                = 6C
//    //VK_SUBTRACT                 = 6D
//    //VK_DECIMAL                  = 6E
//    //VK_DIVIDE                   = 6F
//    //VK_F1                       = 70
//    //VK_F2                       = 71
//    //VK_F3                       = 72
//    //VK_F4                       = 73
//    //VK_F5                       = 74
//    //VK_F6                       = 75
//    //VK_F7                       = 76
//    //VK_F8                       = 77
//    //VK_F9                       = 78
//    //VK_F10                      = 79
//    //VK_F11                      = 7A
//    //VK_F12                      = 7B
//    //VK_F13                      = 7C
//    //VK_F14                      = 7D
//    //VK_F15                      = 7E
//    //VK_F16                      = 7F
//    //VK_F17                      = 80
//    //VK_F18                      = 81
//    //VK_F19                      = 82
//    //VK_F20                      = 83
//    //VK_F21                      = 84
//    //VK_F22                      = 85
//    //VK_F23                      = 86
//    //VK_F24                      = 87
//    //VK_NUMLOCK                  = 90
//    //VK_SCROLL                   = 91
//    //VK_OEM_NEC_EQUAL            = 92
//    //VK_OEM_FJ_JISHO             = 92
//    //VK_OEM_FJ_MASSHOU           = 93
//    //VK_OEM_FJ_TOUROKU           = 94
//    //VK_OEM_FJ_LOYA              = 95
//    //VK_OEM_FJ_ROYA              = 96
//    //VK_LSHIFT                   = A0
//    //VK_RSHIFT                   = A1
//    //VK_LCONTROL                 = A2
//    //VK_RCONTROL                 = A3
//    //VK_LMENU                    = A4
//    //VK_RMENU                    = A5
//    //VK_BROWSER_BACK             = A6
//    //VK_BROWSER_FORWARD          = A7
//    //VK_BROWSER_REFRESH          = A8
//    //VK_BROWSER_STOP             = A9
//    //VK_BROWSER_SEARCH           = AA
//    //VK_BROWSER_FAVORITES        = AB
//    //VK_BROWSER_HOME             = AC
//    //VK_VOLUME_MUTE              = AD
//    //VK_VOLUME_DOWN              = AE
//    //VK_VOLUME_UP                = AF
//    //VK_MEDIA_NEXT_TRACK         = B0
//    //VK_MEDIA_PREV_TRACK         = B1
//    //VK_MEDIA_STOP               = B2
//    //VK_MEDIA_PLAY_PAUSE         = B3
//    //VK_LAUNCH_MAIL              = B4
//    //VK_LAUNCH_MEDIA_SELECT      = B5
//    //VK_LAUNCH_APP1              = B6
//    //VK_LAUNCH_APP2              = B7
//    //VK_OEM_1                    = BA
//    //VK_OEM_PLUS                 = BB
//    //VK_OEM_COMMA                = BC
//    //VK_OEM_MINUS                = BD
//    //VK_OEM_PERIOD               = BE
//    //VK_OEM_2                    = BF
//    //VK_OEM_3                    = C0
//    //VK_OEM_4                    = DB
//    //VK_OEM_5                    = DC
//    //VK_OEM_6                    = DD
//    //VK_OEM_7                    = DE
//    //VK_OEM_8                    = DF
//    //VK_OEM_AX                   = E1
//    //VK_OEM_102                  = E2
//    //VK_ICO_HELP                 = E3
//    //VK_ICO_00                   = E4
//    //VK_PROCESSKEY               = E5
//    //VK_ICO_CLEAR                = E6
//    //VK_PACKET                   = E7
//    //VK_OEM_RESET                = E9
//    //VK_OEM_JUMP                 = EA
//    //VK_OEM_PA1                  = EB
//    //VK_OEM_PA2                  = EC
//    //VK_OEM_PA3                  = ED
//    //VK_OEM_WSCTRL               = EE
//    //VK_OEM_CUSEL                = EF
//    //VK_OEM_ATTN                 = F0
//    //VK_OEM_FINISH               = F1
//    //VK_OEM_COPY                 = F2
//    //VK_OEM_AUTO                 = F3
//    //VK_OEM_ENLW                 = F4
//    //VK_OEM_BACKTAB              = F5
//    //VK_ATTN                     = F6
//    //VK_CRSEL                    = F7
//    //VK_EXSEL                    = F8
//    //VK_EREOF                    = F9
//    //VK_PLAY                     = FA
//    //VK_ZOOM                     = FB
//    //VK_NONAME                   = FC
//    //VK_PA1                      = FD
//    //VK_OEM_CLEAR                = FE
//    //KEYEVENTF_KEYDOWN           = 0000
//    //KEYEVENTF_EXTENDEDKEY       = 0001
//    //KEYEVENTF_KEYUP             = 0002
//    //KEYEVENTF_UNICODE           = 0004
//    //KEYEVENTF_SCANCODE          = 0008
//}
