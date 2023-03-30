using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class profileButtons : MonoBehaviour
{
    public GameObject saveProfile;


    public GameObject leftArrow1;   //change avatar left
    public GameObject rightArrow1;  //change avatar right
    public GameObject leftArrow2;   //change background left
    public GameObject rightArrow2;  //change background right
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
        avatarArray[0] = avatar001;
        avatarArray[1] = avatar002;
        backgroundArray[0] = backgroundGrass;
        backgroundArray[1] = backgroundHills;
        backgroundArray[2] = backgroundBeach;
        backgroundArray[3] = backgroundMesa;
        backgroundArray[4] = backgroundOcean;

        print("Background List Length: " + backgroundArrayLength);
        print("Current background List Index: " + currentBackgroundIndex);
    }

    // Update is called once per frame
    void Update()
    {
        print("Current background List Index: " + currentBackgroundIndex);
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
}
