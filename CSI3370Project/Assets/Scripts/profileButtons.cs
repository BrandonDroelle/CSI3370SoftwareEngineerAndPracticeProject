using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class profileButtons : MonoBehaviour
{
    //public attributes
    public List<ProfileClass> profileList = new List<ProfileClass>();   //creates a list of profileClass objects
    public int profileIndex = 0;            //holds index for current class
    public int numOfProfiles = 0;           //counts number of profiles

    public string theText;                  //contain the new profiles name
    public GameObject newNameTextBox;       //contains the text box
    public GameObject newProfileName;       //holds the profiles name
    public GameObject createProfileCanvas;  //create profile scene
    public GameObject viewProfileCanvas;    //view profile scene

    //Buttons
    public GameObject leftArrow1;           //change avatar left
    public GameObject rightArrow1;          //change avatar right
    public GameObject leftArrow2;           //change background left
    public GameObject rightArrow2;          //change background right
    public GameObject saveProfile;          //saves profile

    public GameObject addProfileButton;     //changes canvas to create profile


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

    }

    // Update is called once per frame
    void Update()
    {
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
        newNameTextBox.GetComponent<TMP_InputField>().text = "";
        previousAvatarIndex = currentAvatarIndex;
        currentAvatarIndex = 0;
        previousBackgroundIndex = currentBackgroundIndex;
        currentBackgroundIndex = 0;
        
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
        if(numOfProfiles > 0)
        {
            profileList.RemoveAt(profileIndex);
            numOfProfiles -= 1;
            print("deleted profile");
        }
        else
            print("no profiles to delete");
    }

    //save profile button
    public void saveProfileButton()
    {
        theText = newProfileName.GetComponent<TMP_Text>().text;

        ProfileClass tempProfile = new ProfileClass(theText, currentAvatarIndex, currentBackgroundIndex);

        string testName = tempProfile.getName();
        int testAvatar = tempProfile.getAvatar();
        int testBackground = tempProfile.getBackground();

        profileList.Add(tempProfile);                   //append new profile to list
        numOfProfiles += 1;                             //add 1 to count of profiles

        //reset canvas
        resetCanvas();

        //switch canvases
        viewProfileCanvas.SetActive(true);
        createProfileCanvas.SetActive(false);
        
    }
}
