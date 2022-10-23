using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "CreatQuestItems/CreateQuest")]
public class Quest : ScriptableObject
{
    public QuestStage[] stages;
    public QuestStage currentStage;
}
