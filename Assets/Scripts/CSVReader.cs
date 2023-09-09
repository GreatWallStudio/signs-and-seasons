using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class CSVReader
{
	static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
	static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
	static char[] TRIM_CHARS = { '\"' };

	public static List<Dictionary<string, object>> Read(string file)
	{
		var list = new List<Dictionary<string, object>>();
		TextAsset data = Resources.Load(file) as TextAsset;

		//split csv file into one line per row
		var lines = Regex.Split(data.text, LINE_SPLIT_RE);

		//if there is one or fewer 
		if (lines.Length <= 1) return list;

		//the first row is the heading
		var header = Regex.Split(lines[0], SPLIT_RE);

		//loop through the rest of the rows
		for (var i = 1; i < lines.Length; i++)
		{
			//if the row is empty go to the next row
			var values = Regex.Split(lines[i], SPLIT_RE);
			if (values.Length == 0 || values[0] == "") continue;

			//otherwise save the row as a new dictionary entry
			var entry = new Dictionary<string, object>();

			//loop through the columns
			for (var j = 0; j < header.Length && j < values.Length; j++)
			{
				string value = values[j];

				//trim white space 
				value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
				object finalvalue = value;
				int n;
				float f;

				//try to cast
				if (int.TryParse(value, out n))
				{
					finalvalue = n;
				}
				else if (float.TryParse(value, out f))
				{
					finalvalue = f;
				}
				entry[header[j]] = finalvalue;
			}
			//add entry to dictionary
			list.Add(entry);
		}
		return list;
	}
}