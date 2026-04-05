using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public SimulationRunner runner;
    
    [Header("Result text fields")]
    public TMP_Text starterBox;
    public TMP_Text extenderBox, disruptionBox, brickBox, subStarterBox, subExtenderBox, subDisruptionBox, subBrickBox;
    private TMP_Text[] textboxes;
    private SimulationResult result;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textboxes = new TMP_Text[]{starterBox, extenderBox, disruptionBox, brickBox, subStarterBox, subExtenderBox, subDisruptionBox, subBrickBox};
        runner.NewResults.AddListener(DisplayNewResults);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void DisplayNewResults()
    {
        // New results in UI
        result = runner.result;

        foreach (var box in textboxes)
        {
            box.text = "";
        }

        foreach(var res in result.tagHits)
        {
            float percent;
            switch (res.Key)
            {
                case CardDefinition.Tag.Starter:

                percent = (float)res.Value / runner.iterations * 100f;
                starterBox.text += $"{res.Key} {percent:F2}%\n";

                break;
                
                case CardDefinition.Tag.Extender:

                percent = (float)res.Value / runner.iterations * 100f;
                extenderBox.text += $"{res.Key} {percent:F2}%\n";

                break;
                
                case CardDefinition.Tag.Disruption:

                percent = (float)res.Value / runner.iterations * 100f;
                disruptionBox.text += $"{res.Key} {percent:F2}%\n";

                break;

                case CardDefinition.Tag.Brick:

                percent = (float)res.Value / runner.iterations * 100f;
                brickBox.text += $"{res.Key} {percent:F2}%\n";

                break;

                case CardDefinition.Tag.SubStarter:

                percent = (float)res.Value / runner.iterations * 100f;
                subStarterBox.text += $"{res.Key} {percent:F2}%\n";

                break;

                case CardDefinition.Tag.SubExtender:

                percent = (float)res.Value / runner.iterations * 100f;
                subExtenderBox.text += $"{res.Key} {percent:F2}%\n";

                break;

                case CardDefinition.Tag.SubDisruption:

                percent = (float)res.Value / runner.iterations * 100f;
                subDisruptionBox.text += $"{res.Key} {percent:F2}%\n";

                break;

                case CardDefinition.Tag.SubBrick:

                percent = (float)res.Value / runner.iterations * 100f;
                subBrickBox.text += $"{res.Key} {percent:F2}%\n";

                break;
            }
            //decimal decimalNumber;

            /*decimalNumber = (decimal)res.Value / runner.iterations;
            //resultTextBox.text += res.Key + " " + (percent).ToString(F2);
            resultTextBox.text += $"{res.Key} {Math.Truncate(decimalNumber)}%";
            */
            // float percent = (float)res.Value * 100f / runner.iterations; //* 100f; // * 100ff perchance this might perchance work? surely
            
        }
       
    }
}
