using System;
using System.Collections.Generic;
[Serializable]
public class ListTask
{

    public EnumPotionTask PotionTaskEnum;
    public List<ItemTaskConfig> listTasks;

    public int TaskIndex;

    public void IndexTask(int index)
    {
        TaskIndex = index;
    }
}
