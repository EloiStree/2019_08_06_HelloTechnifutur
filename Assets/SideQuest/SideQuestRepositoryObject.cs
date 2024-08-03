using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Repository", menuName = "SideQuest/Repository", order = 1)]
public class SideQuestRepositoryObject : ScriptableObject
{
    public SideQuestRepository m_value;
}
[System.Serializable]
public class SideQuestRepository
{
    public string m_repositoryName; //##REPONAME##
    public string m_iconRelativePath="icon.jpg"; //##ICONNAME##
    public string m_urlRepository; //##URLOFREPO##
    [TextArea(0,5)]
    public string m_description; //##DESCRIPTIONOFREPO##
    public SideQuestApkApplicationObject [] m_applications;
}
