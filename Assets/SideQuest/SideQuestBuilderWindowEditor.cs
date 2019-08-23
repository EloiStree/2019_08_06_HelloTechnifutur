using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

class SideQuestBuilderWindowEditor : EditorWindow
{
    [MenuItem("Window/Side Quest Builder")]
    public static void ShowWindow()
    {
        SideQuestBuilderWindowEditor.GetWindow(typeof(SideQuestBuilderWindowEditor));
        RefreshPatternFromResources();
    }

    private static void RefreshPatternFromResources()
    {
        m_repoPattern = Resources.Load<TextAsset>("SideQuest_Repository").text;
        m_applicationPattern = Resources.Load<TextAsset>("SideQuest_Application").text;
        m_apkPattern = Resources.Load<TextAsset>("SideQuest_APK").text;
    }

    public SideQuestRepositoryObject m_repo;
    public string m_fullFile;
    public string m_repositoryResult;
    public ApplicationInfo[] m_applicationResult;

    public static string m_repoPattern="";
    public static string m_applicationPattern = "";
    public static string m_apkPattern = "";

    public Vector2 scrollPos;
    public struct ApplicationInfo
    {
        public string name;
        public string apkText;
        public string applicationText;
    };
    void OnGUI()
    {
        m_repo = (SideQuestRepositoryObject)EditorGUILayout.ObjectField(m_repo, typeof(SideQuestRepositoryObject));
        if (m_repo == null) return;


        int applicationCount = m_repo.m_value.m_applications.Length;
        m_applicationResult = new ApplicationInfo[applicationCount];

        if (GUILayout.Button("Generate")) {
            RefreshPatternFromResources();
            m_repositoryResult = ReplaceTagWith(m_repoPattern, m_repo.m_value);

            for (int i = 0; i < applicationCount; i++)
            {
                SideQuestApkApplication app = m_repo.m_value.m_applications[i].m_value;

                if (app != null)
                {
                    m_applicationResult[i].name = app.m_applicationName;
                       m_applicationResult[i].apkText = ReplaceTagWithApk(m_apkPattern, app);
                    m_applicationResult[i].applicationText = ReplaceTagWithApplication(m_applicationPattern, app);
                }
            }
        }
        //GUILayout.Label("Full");
        //m_fullFile = GUILayout.TextArea(m_fullFile);

        GUILayout.Label("Repository");
        m_repositoryResult = GUILayout.TextArea(m_repositoryResult);

        for (int i = 0; i < m_applicationResult.Length; i++)
        {
            GUILayout.Label("Application: "+ m_applicationResult[i].name);
            GUILayout.Label("  Information");
            GUILayout.TextArea(m_applicationResult[i].applicationText);
            GUILayout.Label("  Namespace");
            GUILayout.TextArea(m_applicationResult[i].apkText);
        }


        scrollPos = GUILayout.BeginScrollView(scrollPos);

        GUILayout.EndScrollView();
    }

    private string ReplaceTagWith(string repositoryJson, SideQuestRepository value)
    {
        repositoryJson = repositoryJson.Replace("##REPONAME##", value.m_repositoryName);
        repositoryJson = repositoryJson.Replace("##ICONNAME##", value.m_iconRelativePath);
        repositoryJson = repositoryJson.Replace("##URLOFREPO##", value.m_urlRepository);
        repositoryJson = repositoryJson.Replace("##DESCRIPTIONOFREPO##", value.m_description);
        return repositoryJson;
    }

    private string ReplaceTagWithApplication(string repositoryJson, SideQuestApkApplication value)
    {
        repositoryJson = repositoryJson.Replace("##APKPACKAGENAME##", value.m_packageId);
        repositoryJson = repositoryJson.Replace("##APPCATEGORY##", value.m_applicationCategory);
        repositoryJson = repositoryJson.Replace("##ONELINEDESCRIPTION##", value.m_oneLineDescription);
        repositoryJson = repositoryJson.Replace("##FULLAPPDESCRIPTION##", value.m_fullDescription);
        repositoryJson = repositoryJson.Replace("##BUGANDISSUETRACKERURL##", value.m_bugTrackerUrl);
        repositoryJson = repositoryJson.Replace("##CONTACTORSOURCECODE##", value.m_sourceCodeUrl);
        repositoryJson = repositoryJson.Replace("##GAMEWEBSITE##", value.m_website);
        repositoryJson = repositoryJson.Replace("##APPICON##", value.m_applicationIconRelativePath);
        return repositoryJson;
    }

    private string ReplaceTagWithApk(string repositoryJson, SideQuestApkApplication value)
    {
        repositoryJson = repositoryJson.Replace("##APKPACKAGENAME##", value.m_packageId);
        repositoryJson = repositoryJson.Replace("##DOWNLOADAPKURL##", value.m_downloadApkUrl);
        repositoryJson = repositoryJson.Replace("##MINAPKVERSION##", value.m_minApkVersion);
        return repositoryJson;
    }
}