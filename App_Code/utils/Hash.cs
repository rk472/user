using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Hash
/// </summary>
public class Hash
{
    public Hash()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static String GetHash(String src)
    {
        MD5 mD5 = MD5.Create();
        byte[] data = mD5.ComputeHash(Encoding.UTF8.GetBytes(src));
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            stringBuilder.Append(data[i].ToString());
        }
        return stringBuilder.ToString();
    }
}