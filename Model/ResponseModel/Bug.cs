﻿namespace jiraApi.Model.ResponseModel
{
	public class Bug
	{
		public string key { get; set; }
		public string summary { get; set; }
		public List<string> teams { get; set; }
		public string visualizedData { get; set; }  //  (Key : Summary)
	}
}
