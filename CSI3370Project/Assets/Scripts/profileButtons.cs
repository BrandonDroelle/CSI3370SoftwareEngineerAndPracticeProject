using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class profileButtons : MonoBehaviour
{
    //public attributes
    public List<ProfileClass> profileList = new List<ProfileClass>();   //creates a list of profileClass objects
    public List<string> profileNames = new List<string>();              //creates list of profile names
    public int numOfNames;                                              //saves the length of names list
    public int profileIndex = 0;            //holds index for current class
    public int numOfProfiles = 0;           //counts number of profiles

    public GameObject dropdownMenu;         //contains the dropdown menu

    public string theText;                  //contain the new profiles name
    public string headText;                 //contains text for the head data
    public string torsoText;                //contains text for the torso
    public string legText;                  //conmtains text for the legs

    public GameObject newNameTextBox;       //contains the text box
    public GameObject newProfileName;       //holds the profiles name
    public GameObject createProfileCanvas;  //create profile scene
    public GameObject viewProfileCanvas;    //view profile scene
    public GameObject textBoxTypeTitle;     //display current text box info type


    public bool profileDeleted = false;     

    //Buttons
    public GameObject leftArrow1;           //change avatar left
    public GameObject rightArrow1;          //change avatar right
    public GameObject leftArrow2;           //change background left
    public GameObject rightArrow2;          //change background right
    public GameObject saveProfile;          //saves profile

    public GameObject addProfileButton;     //changes canvas to create profile

    public GameObject finishTextButton;     //closes text box
    public GameObject editHeadSizes;        //opens text box for head sizes
    public GameObject editTorsoSizes;       //opens text box for torso sizes
    public GameObject editLegSizes;         //opens text box for leg sizes

    //Sprites
    public GameObject avatar001;
    public GameObject avatar002;
    public GameObject backgroundGrass;
    public GameObject backgroundHills;
    public GameObject backgroundBeach;
    public GameObject backgroundMesa;
    public GameObject backgroundOcean;

    public GameObject avatar001V;
    public GameObject avatar002V;
    public GameObject backgroundGrassV;
    public GameObject backgroundHillsV;
    public GameObject backgroundBeachV;
    public GameObject backgroundMesaV;
    public GameObject backgroundOceanV;

    //text boxes
    public GameObject headTextBox;
    public GameObject torsoTextBox;
    public GameObject legTextBox;
    //text in text boxes
    public GameObject headtxt;
    public GameObject torsotxt;
    public GameObject legtxt;


    private int currentAvatarIndex = 0;
    private int previousAvatarIndex = 0;
    private int currentBackgroundIndex = 0;
    private int previousBackgroundIndex = 0;

    public int currentAvatarIndexV = 0;
    public int previousAvatarIndexV = 0;
    public int currentBackgroundIndexV = 0;
    public int previousBackgroundIndexV = 0;
    
    private static int avatarArrayLength = 2;
    private static int backgroundArrayLength = 5;

    //create list of avatars
    public GameObject[] avatarArray = new GameObject[avatarArrayLength];
    public GameObject[] avatarArrayV = new GameObject[avatarArrayLength];

    //create list of backgrounds
    public GameObject[] backgroundArray = new GameObject[backgroundArrayLength];
    public GameObject[] backgroundArrayV = new GameObject[backgroundArrayLength];

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

        avatarArrayV[0] = avatar001V;
        avatarArrayV[1] = avatar002V;
        backgroundArrayV[0] = backgroundGrassV;
        backgroundArrayV[1] = backgroundHillsV;
        backgroundArrayV[2] = backgroundBeachV;
        backgroundArrayV[3] = backgroundMesaV;
        backgroundArrayV[4] = backgroundOceanV;

        //set canvases
        createProfileCanvas.SetActive(false);
        viewProfileCanvas.SetActive(true);
        visualCanvas.SetActive(true);

        //load data
        loadData();

    }

    //save data
    public void saveData()
    {

        string profileListSave = Application.persistentDataPath + "/profileList.json";
        List<string> profileListStrings = new List<string>();
        foreach (ProfileClass profile in profileList)
        {
            string profileJSON = JsonUtility.ToJson(profile);
            //print(profileJSON);
            profileListStrings.Add(profileJSON);
        }
        string profileListJSON = JsonUtility.ToJson(new JSONListWrapper<string>(profileListStrings));

        File.WriteAllText(profileListSave, profileListJSON);

        string profileNamesSave = Application.persistentDataPath + "/profileNames.json";
        string profileNamesJSON = JsonUtility.ToJson(new JSONListWrapper<string>(profileNames));
        print(profileNamesSave);
        print(profileNamesJSON);



        File.WriteAllText(profileNamesSave, profileNamesJSON);

        PlayerPrefs.SetInt("profileIndex", profileIndex);
        PlayerPrefs.SetInt("numOfProfiles", numOfProfiles);
        
    }

    public void loadData()
    {

        //bottom two lines store in PlayerPrefs
        profileIndex = PlayerPrefs.GetInt("profileIndex", 0);
        numOfProfiles = PlayerPrefs.GetInt("numOfProfiles", 0);


        string profileListSave = Application.persistentDataPath + "/profileList.json";

        if (File.Exists(profileListSave))
        {
            string profileListJSON = File.ReadAllText(profileListSave);
            profileList = new List<ProfileClass>();
            List<string> profileListStrings = JsonUtility.FromJson<JSONListWrapper<string>>(profileListJSON).list;

            foreach (string profileJSON in profileListStrings)
            {
                ProfileClass profile = JsonUtility.FromJson<ProfileClass>(profileJSON);

                profileList.Add(profile);
            }


        } else
        {

            profileList = new List<ProfileClass>();
            profileIndex = 0;
            numOfProfiles = 0;
        }

        string profileNamesSave = Application.persistentDataPath + "/profileNames.json";

        if (File.Exists(profileNamesSave))
        {
            string profileNamesJSON = File.ReadAllText(profileNamesSave);
            print(profileNamesJSON);
            profileNames = JsonUtility.FromJson<JSONListWrapper<string>>(profileNamesJSON).list;
        } else
        {
            profileNames = new List<string>();
            profileIndex = 0;
            numOfProfiles = 0;
        }

        //dropdownMenu.GetComponent<TMP_Dropdown>().RefreshShownValue();
        fillDropdown();                     //for when it loads ViewProfileCanvas first - it fills the dropdown with the loaded data
    }

    // Update is called once per frame
    void Update()
    {
        //updates sprite objects
        avatarArray[previousAvatarIndex].SetActive(false);
        avatarArray[currentAvatarIndex].SetActive(true);
        backgroundArray[previousBackgroundIndex].SetActive(false);
        backgroundArray[currentBackgroundIndex].SetActive(true);

        avatarArrayV[previousAvatarIndexV].SetActive(false);
        avatarArrayV[currentAvatarIndexV].SetActive(true);
        backgroundArrayV[previousBackgroundIndexV].SetActive(false);
        backgroundArrayV[currentBackgroundIndexV].SetActive(true);

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

    //turn off text boxes
    public void resetTextBoxes()
    {
        //reset text boxes
        finishTextButton.SetActive(false);
        headTextBox.SetActive(false);
        torsoTextBox.SetActive(false);
        legTextBox.SetActive(false);
        textBoxTypeTitle.SetActive(false);

    }

    //save text from text boxes
    public void saveText()
    {
        //update profile class object
        headText = headtxt.GetComponent<TMP_Text>().text;
        profileList[profileIndex].setHeadInfo(headText);

        torsoText = torsotxt.GetComponent<TMP_Text>().text;
        profileList[profileIndex].setTorsoInfo(torsoText);

        legText = legtxt.GetComponent<TMP_Text>().text;
        profileList[profileIndex].setLegInfo(legText);

        //save data
        saveData();
    }

    //load text boxes
    public void loadText()
    {
        print("in load text function");
        print(profileIndex);
        headTextBox.GetComponent<TMP_InputField>().text = "test";
        torsoTextBox.GetComponent<TMP_InputField>().text = profileList[profileIndex].getTorsoInfo();
        legTextBox.GetComponent<TMP_InputField>().text = profileList[profileIndex].getLegInfo();
    }

    //edit head size text box
    public void editHeadSizeData()
    {
        //set title
        textBoxTypeTitle.GetComponent<TMP_Text>().text = "Head";
        textBoxTypeTitle.SetActive(true);
        finishTextButton.SetActive(true);
        headTextBox.SetActive(true);

        //load text
        headTextBox.GetComponent<TMP_InputField>().text = profileList[profileIndex].getHeadInfo();

    }

    //edit torso size text box
    public void editTorsoSizeData()
    {
        textBoxTypeTitle.GetComponent<TMP_Text>().text = "Torso";
        textBoxTypeTitle.SetActive(true);
        finishTextButton.SetActive(true);
        torsoTextBox.SetActive(true);

        //load text
        torsoTextBox.GetComponent<TMP_InputField>().text = profileList[profileIndex].getTorsoInfo();
    }

    //edit leg size text box
    public void editLegSizeData()
    {
        textBoxTypeTitle.GetComponent<TMP_Text>().text = "Leg";
        textBoxTypeTitle.SetActive(true);
        finishTextButton.SetActive(true);
        legTextBox.SetActive(true);

        //load text
        legTextBox.GetComponent<TMP_InputField>().text = profileList[profileIndex].getLegInfo();
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
            profileIndex = 0;                       //set profile index to 0
            profileDeleted = true;                  //set profile deleted to true to avoid index out of range when updating the canvas
            //print("deleted profile");
            fillDropdown();                         //updates the dropdown menu
            
        }
        else
            print("no profiles to delete");
    }

    //fill drop down with list of profile names
    public void fillDropdown()
    {
        //initialize drop down menu
        var dropdown = dropdownMenu.GetComponent<TMP_Dropdown>();

        //clear dropdown
        dropdown.options.Clear();

        foreach(var name in profileNames)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = name});
        }

        dropdownItemSelected(dropdown);

        //reset text boxes
        resetTextBoxes();

    }

    //change dropdown selection to name of item in list
    public void dropdownItemSelected(TMP_Dropdown dropdown)
    {

        int index = 0;

        if (profileDeleted == false)
        {
            index = dropdown.value;
        }
        else
        {
            index = 0;
        }
        profileIndex = index;               //update global index for current profile

        updateViewProfile(index, dropdown);

        //reset text boxes
        resetTextBoxes();
        loadText();
        
    }

    //save profile button
    public void saveProfileButton()
    {
        //gets name of profile from textbox
        theText = newProfileName.GetComponent<TMP_Text>().text;
        //creates new profile class object
        ProfileClass tempProfile = new ProfileClass(theText, currentAvatarIndex, currentBackgroundIndex, "", "", "");

        profileList.Add(tempProfile);                   //append new profile to list
        profileNames.Add(theText);                      //append name of profile to list of names
        numOfProfiles += 1;                             //add 1 to count of profiles

        //reset canvas
        resetCanvas();

        //update dropdown
        fillDropdown();
        //print("out of fillDropdown");

        //save data
        saveData();

        //switch canvases
        viewProfileCanvas.SetActive(true);
        createProfileCanvas.SetActive(false);

        
    }

    public void updateViewProfile(int index, TMP_Dropdown dropdown)
    {

        //update sprites
        if(numOfProfiles == 0)
        {
            previousBackgroundIndexV = currentBackgroundIndexV;
            currentBackgroundIndexV = 0;
            previousAvatarIndexV = currentAvatarIndexV;
            currentAvatarIndexV = 0;
            dropdown.captionText.text = "Hit + to Create Profile";

        }
        else
        {
            previousBackgroundIndexV = currentBackgroundIndexV;
            currentBackgroundIndexV = profileList[index].getBackground();
            previousAvatarIndexV = currentAvatarIndexV;
            currentAvatarIndexV = profileList[index].getAvatar();
            string currentProfileName = profileList[index].getName();
            //update label text
            dropdown.captionText.text = currentProfileName;
        }

        //reset delelted profile
        profileDeleted = false;

    }

    [System.Serializable]
    public class JSONListWrapper<T>
    {
        public List<T> list;
        public JSONListWrapper(List<T> profileList) => this.list = profileList;

    }

}
