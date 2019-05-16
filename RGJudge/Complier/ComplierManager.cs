/*
 * Created by SharpDevelop.
 * User: stu
 * Date: 2019-05-09
 * Time: 20:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.IO;

namespace RGJudge.Complier
{
	/// <summary>
	/// Description of ComplierManager.
	/// </summary>
	public class ComplierManager
	{
		public ComplierManager()
		{
		}
		void Complie(string filename,JudgeComplier complier){
			string cp=complier.Parameters;
			cp.Replace("$i$",filename);
			Process process=new Process();
			process.StartInfo.FileName=complier.EXEPath;
			process.StartInfo.Arguments=cp;
			process.StartInfo.CreateNoWindow=true;
			process.StartInfo.RedirectStandardOutput=true;
			process.StartInfo.RedirectStandardInput=true;
			process.StartInfo.RedirectStandardError=true;
			process.Start();
			string result=process.StandardOutput.ReadToEnd();
			process.WaitForExit();
		}
		ComplieResult Complie(string inputfile,string outputfile,JudgeComplier complier){
			string cp=complier.Parameters;
			cp.Replace("$i$",inputfile);
			cp.Replace("$o$",outputfile);
			Process process=new Process();
			process.StartInfo.FileName=complier.EXEPath;
			process.StartInfo.Arguments=cp;
			process.StartInfo.CreateNoWindow=true;
			process.StartInfo.RedirectStandardOutput=true;
			process.StartInfo.RedirectStandardInput=true;
			process.StartInfo.RedirectStandardError=true;
			Stopwatch sw=new Stopwatch();
			sw.Start();
			process.Start();
			string result=process.StandardOutput.ReadToEnd();
			process.WaitForExit();
			sw.Stop();
			ComplieResult cr=new ComplieResult();
			cr.complieOutput=result;
			cr.complieTime=(float)sw.Elapsed.TotalSeconds;
			if(CheckComplieResult(outputfile)){
				cr.complieStatue=true;
				cr.outputfile=outputfile;
				FileInfo finfo=new FileInfo(outputfile);
				cr.size=finfo.Length/(float)1024;
				
			}else{
				cr.complieStatue=false;
			}
			
		}
		bool CheckComplieResult(string outputfile){
			if(File.Exists(outputfile)){
				return true;
			}else{
				return false;
			}
		}
	}
}
