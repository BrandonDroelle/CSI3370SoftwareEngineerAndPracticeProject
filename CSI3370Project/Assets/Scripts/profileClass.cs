using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileClass
{
    public string profileName;
    public int avatar;
    public int background;

    //default constructor
    public ProfileClass(string newName, int newAvatar, int newBackground)
    {
        profileName = newName;
        avatar = newAvatar;
        background = newBackground;
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

}
