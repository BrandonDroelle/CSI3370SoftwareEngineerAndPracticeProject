using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class profileButtons : MonoBehaviour
{
    //public attributes
    public List<ProfileClass> profileList = new List<ProfileClass>();   //creates a list of profileClass objects
    public List<string> profileNames = new List<string>();              //creates list of profile names
    public int profileIndex = 0;            //holds index for current class
    public int numOfProfiles = 0;           //counts number of profiles

    public GameObject dropdownMenu;         //contains the dropdown menu

    public string theText;                  //contain the new profiles name
    public GameObject newNameTextBox;       //contains the text box
    public GameObject newProfileName;       //holds the profiles name
    public GameObject createProfileCanvas;  //create profile scene
    public GameObject viewProfileCanvas;    //view profile scene
    public GameObject visualCanvas;         //background & avatar

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
        print("start program");
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
        visualCanvas.SetActive(true);

        //load data
        //profileList = PlayerPrefs.GetList("profileObjects");
        //profileNameList = PlayerPrefs.GetList("profileNames");

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
        //checks if there are more than 0 profiles
        //if there are then removes profile object from list
        if(numOfProfiles > 0)
        {
            profileList.RemoveAt(profileIndex);     //removes profile object at current index
            profileNames.RemoveAt(profileIndex);    //removes profile name at current index
            numOfProfiles -= 1;                     //removes 1 from count of total profiles

            //these 3 lines reset the dropdown & select the previous option
            var dropdown = dropdownMenu.GetComponent<TMP_Dropdown>();
            dropdown.value -= 1;
            fillDropdown();

            print("deleted profile");
        }
        else
            print("no profiles to delete");
    }

    //fill drop down with list of profile names
    public void fillDropdown()
    {
        print("in fillDropdown");
        //initialize drop down menu
        var dropdown = dropdownMenu.GetComponent<TMP_Dropdown>();

        print("dropdown object created");
        //clear dropdown
        dropdown.options.Clear();

        foreach(var name in profileNames)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = name});
        }

        dropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate { dropdownItemSelected(dropdown);});

    }

    //change dropdown selection to name of item in list
    void dropdownItemSelected(TMP_Dropdown dropdown)
    {
        print("in dropdownItemSelected");
        int index = dropdown.value;
        
        dropdown.RefreshShownValue();       //refreshes the value to whatever is now selected

        updateViewProfile(index);
    }

    //save profile button
    public void saveProfileButton()
    {
        print("save profile button clicked");
        //gets name of profile from textbox
        theText = newProfileName.GetComponent<TMP_Text>().text;
        //creates new profile class object
        ProfileClass tempProfile = new ProfileClass(theText, currentAvatarIndex, currentBackgroundIndex);

        profileList.Add(tempProfile);                   //append new profile to list
        profileNames.Add(theText);                      //append name of profile to list of names
        numOfProfiles += 1;                             //add 1 to count of profiles

        //reset canvas
        resetCanvas();

        //update dropdown
        fillDropdown();
        print("out of fillDropdown");

        //save data
        saveData();

        //switch canvases
        viewProfileCanvas.SetActive(true);
        createProfileCanvas.SetActive(false);
        
    }

    public void updateViewProfile(int index)
    {
        avatarArray[currentAvatarIndex].SetActive(false);               //hides the soon-to-be previous avatar
        backgroundArray[currentBackgroundIndex].SetActive(false);       //hides the soon-to-be previous background
        currentBackgroundIndex = profileList[index].getBackground();
        currentAvatarIndex = profileList[index].getAvatar();
        profileIndex = index;                                           //sets the profileIndex to the current index
    }

    //save data
    public void saveData()
    {
        //PlayerPrefs.SetList("profileObjects", profileList);
        //PlayerPrefs.SetString("profileNames_count", profileNames.Count);
    }
}
