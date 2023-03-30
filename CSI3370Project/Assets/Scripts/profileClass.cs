using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class profileClass : MonoBehaviour
{
    public string profileName;
    public string avatar;
    public string background;

    //Setters
    public void setName(string newName)
    {
        profileName = newName;
    }
    public void setAvatar(string newAvatar)
    {
        avatar = newAvatar;
    }
    public void setBackground(string newBackground)
    {
        background = newBackground;
    }

    //Getters
    public string getName()
    {
        return profileName;
    }
    public string getAvatar()
    {
        return avatar;
    }
    public string getBackground()
    {
        return background;
    }

}
