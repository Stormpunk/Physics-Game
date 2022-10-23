using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest Stage", menuName = "CreatQuestItems/CreateQuestStage")]

public class QuestStage : ScriptableObject
{
    public string qSName;
    public string qSDescription;
    public enum Stage{ QuestBegin,NewStage,End}
    public Stage thisStage;
    public int stageNum;

}
