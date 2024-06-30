using System.Collections;
using static jiraApi.UrlManager;

namespace jiraApi
{
	public class UrlManager
	{
		public static class Constants
		{
			public static string encodedCredentials { get; } = "YW1pdC5zcml2YXN0YXZhQGdyYXBlY2l0eS5jb206QVRBVFQzeEZmR0YwN1Jrd2puamdxa" +
				"XphQnEzSUI0REFxN0pNWGJZSVBiN2FMQk5oRTRlLXlCZWlHMEZ6TDJTSUpQNVl3bG9zMERJMGZuSFV0NVFGa3JhSmJvNG9ScWVSenFyVmR" +
				"VaHhCenBPRVNZekpQQWF3UVNBTkJsZlN4RjJGTVItUkpkcUtlaW9wc3JQMzBqaHRfWEVtVjd2OERZbnh1MDBHZ1NBdHR2bTgxaTRZSXB2V2xrPTQ1Q0Y2Q0ND";
			public static string ApiServer { get; } = "https://grapeseed.atlassian.net";
		}
		public static class Jql
		{
			public static string AutomationList { get; } = "project%20%3D%20\"{projectKey}\"%0AAND%20labels%20%3D%20Automation%0AAND%20statuscategorychangeddate%20>%3D%20\"{startDate}\"%0AAND%20statuscategorychangeddate%20<%3D%20\"{endDate}\"%0AAND%20status%20NOT%20IN%20%28Draft%2C%20Open%29";
			public static string IndependentStory { get; } = "project%20%3D%20\"{projectKey}\"%20AND%20type%20%3D%20Story%20AND%20resolved%20>%3D%20\"{startDate}\"%20AND%20resolved%20<%3D%20\"{endDate}\"%0AORDER%20BY%20created%20DESC";
			public static string BugsDelivered { get; } = "project%20%3D%20\"{projectKey}\"%0AAND%20type%20%3D%20Bug%0AAND%20resolved%20>%3D%20\"{startDate}\"%0AAND%20resolved%20<%3D%20\"{endDate}\"%0AAND%20status%20IN%20%28Done%2C%20Resolved%2C%20Closed%29%0AORDER%20BY%20created%20DESC";
			public static string BugsRaised { get; } = "project%20%3D%20\"{projectKey}\"%20AND%20type%20%3D%20Bug%20AND%20created%20>%3D%20\"{startDate}\"%20AND%20created%20<%3D%20\"{endDate}\"";
			public static string TechTask { get; } = "project%20%3D%20\"{projectKey}\"%20AND%20type%20%3D%20\"Technical%20Task\"%20AND%20created%20>%3D%20\"{startDate}\"%20AND%20created%20<%3D%20\"{endDate}\"%0AORDER%20BY%20created%20DESC";
			public static string EpicList { get; } = "project%20%3D%20\"{projectKey}\"%20AND%20type%20%3D%20Epic%20AND%20status%20%21%3D%20Draft";
			public static string EpicWithStory { get; } = "project%20%3D%20\"{projectKey}\"%0AAND%20type%20IN%20%28Epic%2C%20Story%29%0AAND%20status%20%21%3D%20Draft%0AAND%20statuscategorychangeddate%20>%3D%20\"{startDate}\"%0AAND%20statuscategorychangeddate%20<%3D%20\"{endDate}\"\r\n";


		}
		public static string url(string functionType, DateTime startDate, DateTime endDate, string projectKey) 
		{
			string startDateString = startDate.ToString("yyyy-MM-dd");
			string endDateString = endDate.ToString("yyyy-MM-dd");

			string JqlTemplate = JqlFetch(functionType);
			string Jql = JqlTemplate.Replace("{projectKey}", projectKey).Replace("{startDate}", startDateString).Replace("{endDate}", endDateString);

			string baseUrl = $"{Constants.ApiServer}/rest/api/3/search?jql={Jql}";
			return baseUrl;
		}

		public static string JqlFetch(string functionType)
		{
			switch (functionType)
			{
				case "Automation":
					return Jql.AutomationList;
				case "IndependentStory":
					return Jql.IndependentStory;
				case "BugsDelivered":
					return Jql.BugsDelivered;
				case "BugsRaised":
					return Jql.BugsRaised;
				case "TechTask":
					return Jql.TechTask;
				case "EpicList":
					return Jql.EpicList;
				case "EpicWithStory":
					return Jql.EpicWithStory;
				default:
					return "";
			}
		}

	}
}
