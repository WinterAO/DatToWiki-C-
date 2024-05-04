using System;
using System.Collections.Generic;
using System.IO;

public class IniParser {
    private Dictionary<string, Dictionary<string, string>> sections;

    public IniParser() {
        sections = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);
    }

    public void Load(string filePath) {
        sections.Clear();

        string currentSection = null;
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines) {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith(";"))
                continue;

            if (line.StartsWith("[") && line.EndsWith("]")) {
                currentSection = line.Substring(1, line.Length - 2);
                sections[currentSection] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            } else if (currentSection != null) {
                int separatorIndex = line.IndexOf("=");
                if (separatorIndex >= 0) {
                    string key = line.Substring(0, separatorIndex).Trim();
                    string value = line.Substring(separatorIndex + 1).Trim();
                    sections[currentSection][key] = value;

                }
            }
        }
    }

    public string GetValue(string section, string key) {
        if (sections.TryGetValue(section, out var sectionData) && sectionData.TryGetValue(key, out var value)) {
            return value;
        }

        return null;
    }
}