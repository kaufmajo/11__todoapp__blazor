namespace TodoList
{
    using System;
    using System.IO;

    public static class DotEnv
    {
        public static void Load(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(
                    '=',
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                    continue;

                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }

        public static string Get(string key)
        {
            int start = key.IndexOf("<");
            int end = key.IndexOf(">");

            while (start != -1 && end != -1)
            {
                string replace = key.Substring(start, end - start + 1);
                string replaceKey = replace.Substring(1, replace.Length - 2);
                string replaceValue = Environment.GetEnvironmentVariable(replaceKey) ?? "";
                key = key.Replace(replace, replaceValue);
                
                start = key.IndexOf("<");
                end = key.IndexOf(">");
            }
            
            return key;
        }
    }
}
