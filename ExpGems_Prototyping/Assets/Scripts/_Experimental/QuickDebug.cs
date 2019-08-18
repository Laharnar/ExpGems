using System.Text;
using UnityEngine;

public static class QuickLog {
    public static void Msg(params object[] data)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sb.Append(data[i]);
            sb.Append(" ");
        }
        Debug.Log(sb.ToString());
    }
}
