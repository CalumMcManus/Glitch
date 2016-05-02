using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillMenu : MonoBehaviour
{
   //Base stat skill point buttons
    public Button bHealthUp;
    public Button bStrengthUp;
    public Button bAccuracyUp;
    public Button bIntellectUp;
    public Button bAgilityUp;

    //Base Stat Button Texts
    public Text HealthUpText;
    public Text StrengthUpText;
    public Text AccUpText;
    public Text IntelUpText;
    public Text AgilityUpText;
	public Text LevelUpText;
    //Skill Tree Skill Points

    public Text Info;

    public void HealthUpInfo()
    {
        Info.text = "Increases maxium health by 10 points";
    }

    public void StrengthUpInfo()
    {
        Info.text = "Reduces effect of weapon weight, increases jump height";
    }

    public void AccUpInfo()
    {
        Info.text = "Increases liklihood of a direct hit";
    }

    public void IntelUpInfo()
    {
        Info.text = "Increases health gain from pickups";
    }

    public void AgilityUpInfo()
    {
        Info.text = "Increases Jump height and run speed";
    }

   


    void Start()
    {
        HealthUpText.text = "Health Up! (" +  PlayerSkills.Instance.HealthSkill.ToString() + "/20)";
        StrengthUpText.text = "Strength up! (" + PlayerSkills.Instance.StrengthSkill.ToString() + "/20)";
        AccUpText.text = "Accuracy Up! (" + PlayerSkills.Instance.AccSkill.ToString()  +"/20)";
        IntelUpText.text = "Intellect Up! (" + PlayerSkills.Instance.IntelSkill.ToString()  +"/20)";
        AgilityUpText.text = "Agility Up! (" + PlayerSkills.Instance.AgilitySkill.ToString() + "/20)";
    }

    void Update()
    {
		LevelUpText.text = "Skill Points Remaining:" + PlayerSkills.Instance.SkillPoints.ToString ();
        if (PlayerSkills.Instance.SkillPoints == 0 || !PlayerSkills.Instance.ArmedAndReady)
        {
            Uninteractable();
        }
        else
        {
            Interactable();
        }
    }

    public void HealthUp()
    {
		if (PlayerSkills.Instance.HealthSkill < 20)
		{
			PlayerSkills.Instance.SkillPoints -= 1;
			PlayerSkills.Instance.HealthSkill += 1;
			HealthUpText.text = "Health Up! (" + PlayerSkills.Instance.HealthSkill.ToString () + "/20)";
		}
       
    }

    public void StrengthUp()
    {
		if (PlayerSkills.Instance.StrengthSkill < 20)
		{
			PlayerSkills.Instance.SkillPoints -= 1;
			PlayerSkills.Instance.StrengthSkill += 1;
			StrengthUpText.text = "Strength up! (" + PlayerSkills.Instance.StrengthSkill.ToString () + "/20)";
		}
    }

    public void AccuracyUp()
    {
		if (PlayerSkills.Instance.AccSkill < 20) 
		{	
			
			PlayerSkills.Instance.SkillPoints -= 1;
			PlayerSkills.Instance.AccSkill += 1;
			AccUpText.text = "Accuracy Up! (" + PlayerSkills.Instance.AccSkill.ToString () + "/20)";
		}
    }

    public void IntellectUp()
    {
		if (PlayerSkills.Instance.IntelSkill < 20) 
		{
			PlayerSkills.Instance.SkillPoints -= 1;
			PlayerSkills.Instance.IntelSkill += 1;
			IntelUpText.text = "Intellect Up! (" + PlayerSkills.Instance.IntelSkill.ToString () + "/20)";
		}
    }

    public void AgilityUp()
    {
		if (PlayerSkills.Instance.AgilitySkill < 20) 
		{
			PlayerSkills.Instance.SkillPoints -= 1;
			PlayerSkills.Instance.AgilitySkill += 1;
			AgilityUpText.text = "Agility Up! (" + PlayerSkills.Instance.AgilitySkill.ToString () + "/20)";
		}
    }

     void Uninteractable()
    {
        bHealthUp.interactable = false;
        bStrengthUp.interactable = false;
        bAccuracyUp.interactable = false;
        bIntellectUp.interactable = false;
        bAgilityUp.interactable = false;
    }
     void Interactable()
     {
         bHealthUp.interactable = true;
         bStrengthUp.interactable = true;
         bAccuracyUp.interactable = true;
         bIntellectUp.interactable = true;
         bAgilityUp.interactable = true;
     }
	//Stats modifiers


   

}
