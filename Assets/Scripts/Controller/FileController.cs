using System;
using System.IO;

public class FileController
{
    public string read(string path)
    {
        string result = null;
        StreamReader streamReader = null;

        try
        {
            streamReader = new StreamReader(path);
            result = streamReader.ReadToEnd();
        }
        catch
        {
        }
        finally
        {
            if(streamReader != null)
            {
                streamReader.Close();
            }
        }

        return result;
    }
}