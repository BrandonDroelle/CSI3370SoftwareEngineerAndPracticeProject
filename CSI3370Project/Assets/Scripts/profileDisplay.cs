using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class profileDisplay : MonoBehaviour
{

    //canvases
    public GameObject createProfileCanvas;   //create profile scene
    public GameObject viewProfileCanvas;     //view profile scene

    //buttons
    public GameObject addProfileButton;

    public int profileIndex = 0;
    //ProfileClass currentProfile = profileList[profileIndex];   //sets current profile

    //default constructor
    public profileDisplay(int currentIndex)
    {
        profileIndex = currentIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //add a new profile
    public void addProfile()
    {
        //switch canvases
        createProfileCanvas.SetActive(true);
        viewProfileCanvas.SetActive(false);
    }

    //delete current profile
    public void deleteProfile()
    {
        profileDisplay tempObject = new profileDisplay(profileIndex);   //create temp object with current index
        profileButtons.deleteProfile(tempObject);                                           //call delete profile function
    }

    //get current index
    public int getIndex()
    {
        return profileIndex;
    }
}
