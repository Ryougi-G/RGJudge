/*
 * Created by SharpDevelop.
 * User: stu
 * Date: 2019-05-09
 * Time: 20:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace RGJudge.Complier
{
	/// <summary>
	/// Description of JudgeComplier.
	/// </summary>
	public class JudgeComplier
	{
		public string EXEPath="";
		public string Parameters="";
		public string ComplierName="";
		public JudgeComplier(string exepath,string parameters,string name)
		{
			EXEPath=exepath;
			Parameters=parameters;
			ComplierName=name;
		}
		
	}
}
