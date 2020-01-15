/*<copyright>
	MOD Systems, Inc (c) 2006 All Rights Reserved.
	720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
	All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by MOD Systems.  The contents also may only be viewed by MOD Systems Engineers (employees) and selected Starbucks employees as outlined in the Licensing Agreement between MOD Systems and Starbucks Corporation on June 3rd, 2005.
	No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
	No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact MOD System's competitive advantage.
	Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace MW.MComm.Ganadero.Utility
{
	// ------------------------------------------------------------------------------
	/// <summary>This enumeration is for holding known ImageType codes.</summary>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public enum ImageTypeCode
	{
		/// <summary>None.</summary>
		None = 0,
	}

	// ------------------------------------------------------------------------------
	/// <summary>This enumeration is for holding known FileGroup codes.</summary>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public enum FileGroupCode
	{
		/// <summary>Files.</summary>
		Files = 1,
		/// <summary>UserExperience.</summary>
		UserExperience = 2,
		/// <summary>Customers.</summary>
		Customers = 3,
	}

	public class FileManager
	{
		/// <summary>
		/// Returns the UNC or File Path for a relative path URL of the specified file Group
		/// </summary>
		/// <param name="fileGroup"></param>
		/// <param name="relativePath"></param>
		/// <returns></returns>
		public static string GetAbsoluteFilePath(FileGroupCode fileGroup, string relativePath)
		{
			string appSettingsKey = fileGroup.ToString() + "FileRootPath";

			string root = System.Configuration.ConfigurationManager.AppSettings[appSettingsKey];
			if (relativePath == null)
			{
				return root;
			}
			return Path.Combine(root, relativePath.Replace(@"/", @"\"));
		}

		/// <summary>
		/// Returns the absolute Url to the relative path URL for the specified file group.
		/// </summary>
		/// <param name="fileGroup"></param>
		/// <param name="relativePath"></param>
		/// <returns></returns>
		public static string GetAbsoluteFileUrl(FileGroupCode fileGroup, string relativePath)
		{
			string appSettingsKey = fileGroup.ToString() + "FileRootPath"; // UNC path

			Uri root = new Uri(System.Configuration.ConfigurationManager.AppSettings[appSettingsKey]);
			if (relativePath == null || relativePath == "")
				return "";
			else
			{
				string fullUrl = new Uri(root, relativePath.Replace(@"\", @"/")).AbsoluteUri;
				return fullUrl;
			}
		}

		public static string GetAbsoluteHttpUrl(FileGroupCode fileGroup, string relativePath)
		{
			string appSettingsKey = fileGroup.ToString() + "FileRootUrl";
			string rootUrl = System.Configuration.ConfigurationManager.AppSettings[appSettingsKey];
			return new Uri(new Uri(rootUrl), relativePath).AbsoluteUri;
		}

		/// <summary>
		/// AdamL: I am writing this grudgingly. This should be a property on a business object,
		/// not a static method call.
		/// </summary>
		/// <param name="fileGroup"></param>
		/// <param name="relativePath"></param>
		/// <returns></returns>
		public static string GetAbsoluteHttpUrl(FileGroupCode fileGroup, string relativePath, string defaultUrl)
		{
			if (System.IO.File.Exists(GetAbsoluteFilePath(fileGroup, relativePath)))
			{
				string appSettingsKey = fileGroup.ToString() + "FileRootUrl";
				string rootUrl = System.Configuration.ConfigurationManager.AppSettings[appSettingsKey];
				return new Uri(new Uri(rootUrl), relativePath).AbsoluteUri;
			}
			else
			{
				return defaultUrl;
			}
		}

		/// <summary>
		/// Returns a unique file name with the same extension as the supplied filename.
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public static string GenerateUniqueFileName(string fileName)
		{
			//return DateTime.Now.Ticks.ToString() + Path.GetExtension(fileName);
			return Guid.NewGuid().ToString("N") + Path.GetExtension(fileName);
		}

		/// <summary>
		/// Returns a relative pathname to a specified file to be used with the Feature file group.
		/// </summary>
		/// <param name="subgroup"></param>
		/// <param name="itemID"></param>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public static string GenerateRelativePath(string subgroup, int itemID, string fileName)
		{
			return string.Format("{0}/{1}/{2}", subgroup, itemID, fileName);
		}

		/// <summary>
		/// Returns a folder path created from the specified primary key.
		/// </summary>
		/// <param name="primaryKey"></param>
		/// <returns></returns>
		public static string GenerateFolderPathFromFileName(string fileName)
		{
			string fileNameNoExt = Path.GetFileNameWithoutExtension(fileName);
			string path = @"local/";
			if (fileNameNoExt.Length >= 6)
			{
				path += fileNameNoExt.Substring(0, 3) + @"/";
				path += fileNameNoExt.Substring(3, 3) + @"/";
			}
			return path;
		}

		/// <summary>
		/// Returns a file name created from the specified string.
		/// </summary>
		/// <param name="primaryKey"></param>
		/// <returns></returns>
		public static string GenerateFileName(string fileID, string oldFileName)
		{
			string newFileName;
			if (fileID == null || fileID == Guid.Empty.ToString() || fileID.Length != Guid.Empty.ToString().Length)
			{
				newFileName = Guid.NewGuid().ToString();
			}
			else
			{
				newFileName = fileID;
			}

			return newFileName + Path.GetExtension(oldFileName);
		}

	}
}
