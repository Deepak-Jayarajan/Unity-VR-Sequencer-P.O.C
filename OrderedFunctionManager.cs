using System.Collections.Generic;
using UnityEngine;
using Utility;

public class OrderedFunctionManager : MonoBehaviour
{
    public List<OrderedFunction> OrderOfFunctions = new List<OrderedFunction>();
    public static List<OrderedFunction> FunctionList = new List<OrderedFunction>();
    private static int currentNumberInList;

    private void Start()
    {
        FunctionList.Clear();
        FunctionList = OrderOfFunctions;
        currentNumberInList = -1;
        NextFunction();
    }

    public static void NextFunction()
    {
        currentNumberInList++;
        if (currentNumberInList <= FunctionList.Count - 1)
        {
            FunctionList[currentNumberInList].OnEntry();
        }
        else
        {
            Debug.LogWarning("No more functions in the Ordered Function Manager's list to execute...");
        }
    }
}