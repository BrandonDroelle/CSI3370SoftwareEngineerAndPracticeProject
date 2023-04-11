using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileClass
{
    public string profileName;
    public int avatar;
    public int background;

    public string headInfo;
    public string torsoInfo;
    public string legInfo;

    //default constructor
    public ProfileClass(string newName, int newAvatar, int newBackground, string newHeadInfo, string newTorsoInfo, string newLegInfo)
    {
        profileName = newName;
        avatar = newAvatar;
        background = newBackground;
        headInfo = newHeadInfo;
        torsoInfo = newTorsoInfo;
        legInfo = newLegInfo;
    }

    //Setters
    public void setName(string newName)
    {
        profileName = newName;
    }
    public void setAvatar(int newAvatar)
    {
        avatar = newAvatar;
    }
    public void setBackground(int newBackground)
    {
        background = newBackground;
    }
    public void setHeadInfo(string newHeadInfo)
    {
        headInfo = newHeadInfo;
    }
    public void setTorsoInfo(string newTorsoInfo)
    {
        torsoInfo = newTorsoInfo;
    }
    public void setLegInfo(string newLegInfo)
    {
        legInfo = newLegInfo;
    }

    //Getters
    public string getName()
    {
        return profileName;
    }
    public int getAvatar()
    {
        return avatar;
    }
    public int getBackground()
    {
        return background;
    }
    public string getHeadInfo()
    {
        return headInfo;
    }
    public string getTorsoInfo()
    {
        return torsoInfo;
    }
    public string getLegInfo()
    {
        return legInfo;
    }

}
