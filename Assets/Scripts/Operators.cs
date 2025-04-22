using UnityEngine;
public class Operators : MonoBehaviour
{
    string tempMark;
    public void SetMark(string mark)
    {
        if (!Number.canChooseNumber)
        {
            tempMark = mark;
            MainPanel.instance.GetMark(tempMark);
        }
        Number.canChooseNumber = true;
    }
}
