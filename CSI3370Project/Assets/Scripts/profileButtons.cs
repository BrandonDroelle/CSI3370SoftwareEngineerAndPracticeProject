using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class profileButtons : MonoBehaviour
{

    //public ProfileClass[] profileList = new ProfileClass[99];       //creates list for profile class objects
    public List<ProfileClass> profileList = new List<ProfileClass>();

    public string theText;                  //contain the profiles name
    public GameObject theTextBox;           //contains the text box
    public GameObject ourNote;              //holds the profiles name
    public GameObject createProfileCanvas;  //create profile scene
    public GameObject viewProfileCanvas;    //view profile scene

    //Buttons
    public GameObject leftArrow1;           //change avatar left
    public GameObject rightArrow1;          //change avatar right
    public GameObject leftArrow2;           //change background left
    public GameObject rightArrow2;          //change background right
    public GameObject saveProfile;          //saves profile

    //Sprites
    public GameObject avatar001;
    public GameObject avatar002;
    public GameObject backgroundGrass;
    public GameObject backgroundHills;
    public GameObject backgroundBeach;
    public GameObject backgroundMesa;
    public GameObject backgroundOcean;
    

    

    private int currentAvatarIndex = 0;
    private int previousAvatarIndex = 0;
    private int currentBackgroundIndex = 0;
    private int previousBackgroundIndex = 0;
    private static int avatarArrayLength = 2;
    private static int backgroundArrayLength = 5;

    //create list of avatars
    public GameObject[] avatarArray = new GameObject[avatarArrayLength];

    //create list of backgrounds
    public GameObject[] backgroundArray = new GameObject[backgroundArrayLength];

    //create list of profile class objects
    //public profileClass[] profileList = profileClass[99];

    

    // Start is called before the first frame update
    void Start()
    {
        //initialize sprites
        avatarArray[0] = avatar001;
        avatarArray[1] = avatar002;
        backgroundArray[0] = backgroundGrass;
        backgroundArray[1] = backgroundHills;
        backgroundArray[2] = backgroundBeach;
        backgroundArray[3] = backgroundMesa;
        backgroundArray[4] = backgroundOcean;

        //set canvases
        createProfileCanvas.SetActive(true);
        viewProfileCanvas.SetActive(false);

        //print("Background List Length: " + backgroundArrayLength);
        //print("Current background List Index: " + currentBackgroundIndex);
    }

    // Update is called once per frame
    void Update()
    {
        //print("Current background List Index: " + currentBackgroundIndex);
        avatarArray[previousAvatarIndex].SetActive(false);
        avatarArray[currentAvatarIndex].SetActive(true);
        backgroundArray[previousBackgroundIndex].SetActive(false);
        backgroundArray[currentBackgroundIndex].SetActive(true);
    }

    //change avatar index
    public void LeftArrow1()
    {
        previousAvatarIndex = currentAvatarIndex;
        currentAvatarIndex = currentAvatarIndex - 1;
        if (currentAvatarIndex < 0)
        {
            currentAvatarIndex = avatarArrayLength - 1;
        }
        
    }

    //change avatar index
    public void RightArrow1()
    {
        previousAvatarIndex = currentAvatarIndex;
        currentAvatarIndex = currentAvatarIndex + 1;
        if (currentAvatarIndex == avatarArrayLength)
        {
            currentAvatarIndex = 0;
        }
    }

    //change background index
    public void LeftArrow2()
    {
        previousBackgroundIndex = currentBackgroundIndex;
        currentBackgroundIndex = currentBackgroundIndex - 1;
        if (currentBackgroundIndex < 0)
        {
            currentBackgroundIndex = backgroundArrayLength - 1;
        }
        
    }

    //change background index
    public void RightArrow2()
    {
        previousBackgroundIndex = currentBackgroundIndex;
        currentBackgroundIndex = currentBackgroundIndex + 1;
        if (currentBackgroundIndex == backgroundArrayLength)
        {
            currentBackgroundIndex = 0;
        }
    }

    //resets profile creation canvas to default values
    public void resetCanvas()
    {
        theTextBox.GetComponent<TMP_InputField>().text = "";
        previousAvatarIndex = currentAvatarIndex;
        currentAvatarIndex = 0;
        previousBackgroundIndex = currentBackgroundIndex;
        currentBackgroundIndex = 0;
        
    }

    //delete current profile
    public void deleteProfile(profileDisplay tempList)
    {
        int index = tempList.getIndex;
        //int profileList = tempObject.getProfileIndex();
        profileList.Remove(profileList[index]);
        print("deleted profile");
    }

    //save profile button
    public void saveProfileButton()
    {
        theText = ourNote.GetComponent<TMP_Text>().text;
        // print("Name: " + theText);
        // print("Avatar Index: " + currentAvatarIndex);
        // print("Background Index: " + currentBackgroundIndex);


        ProfileClass tempProfile = new ProfileClass(theText, currentAvatarIndex, currentBackgroundIndex);

        string testName = tempProfile.getName();
        int testAvatar = tempProfile.getAvatar();
        int testBackground = tempProfile.getBackground();

        //print("Name: " + testName);
        //print("Avatar Index: " + testAvatar);
        //print("Background Index: " + testBackground);



        profileList.Add(tempProfile);                   //append new profile to list

        // int count = 0;
        // foreach(ProfileClass test in profileList)         //print name of each profile
        // {
        //     string name = test.getName();
        //     print("Profile Names: " + name);
        //     count += 1;
        // }

        //reset canvas
        resetCanvas();

        //switch canvases
        viewProfileCanvas.SetActive(true);
        createProfileCanvas.SetActive(false);
        

    }
}
