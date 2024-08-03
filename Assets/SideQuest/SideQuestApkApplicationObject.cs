using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ApkApplicationInfo", menuName = "SideQuest/Apk Application", order = 1)]
public class SideQuestApkApplicationObject : ScriptableObject
{
    public SideQuestApkApplication m_value;
}
[System.Serializable]
public class SideQuestApkApplication
{
    public string m_applicationCategory = "Social VR"; //##APPCATEGORY##
    public string m_fullDescription; //##FULLAPPDESCRIPTION##
    public string m_bugTrackerUrl; //##BUGANDISSUETRACKERURL##
    public string m_applicationName;//##APPNAME##
    public string m_sourceCodeUrl;//##CONTACTORSOURCECODE##
    public string m_oneLineDescription;//##ONELINEDESCRIPTION##
    public string m_website;//##WEBSITE##
    public string m_applicationIconRelativePath;//##APPICON##
    public string m_packageId;//##APKPACKAGENAME##
    public string m_value;//
    public string m_downloadApkUrl;//##DOWNLOADAPKURL##
    public string m_minApkVersion;//##MINAPKVERSION##
}
