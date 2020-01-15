/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DAL = MW.MComm.WalletSolution.DAL;
using BLL = MW.MComm.WalletSolution.BLL;
using Utility = MW.MComm.WalletSolution.Utility;
namespace MW.MComm.Admin.WebUI.Controls
{
	public interface IHaveUploadableFiles
	{
		string GetFileRelativePath(FileUploader ctl);
		string GetFolderPath(FileUploader ctl);
		string GetNewFileName(FileUploader ctl, string fileName);
	}
	/// <summary>
	///		Summary description for FileUploader.
	/// </summary>
	public class FileUploader : Components.Desktop.BaseUserControl
	{
		protected Utility.FileGroupCode _fileGroup;
		protected string _fileName;
		protected string _relativeFilePath;
		protected string _folderPath;
		protected HyperLink _linkFile;
		protected HtmlInputFile _htmlInputFile;
		private void GetBaseControls()
		{
			foreach (System.Web.UI.Control loopControl in this.Controls)
			{
				if (loopControl is HyperLink)
				{
					_linkFile = (HyperLink)loopControl;
				}
				else if (loopControl is HtmlInputFile)
				{
					_htmlInputFile = (HtmlInputFile)loopControl;
				}
				else
				{
					GetBaseControls(loopControl);
				}
			}
		}
		private void GetBaseControls(System.Web.UI.Control currentControl)
		{
			foreach (System.Web.UI.Control loopControl in currentControl.Controls)
			{
				if (loopControl is HyperLink)
				{
					_linkFile = (HyperLink)loopControl;
				}
				else if (loopControl is HtmlInputFile)
				{
					_htmlInputFile = (HtmlInputFile)loopControl;
				}
				else
				{
					GetBaseControls(loopControl);
				}
			}
		}
		protected virtual HyperLink LinkFile
		{
			get { return _linkFile; }
			set { _linkFile = value; }
		}
		public virtual HtmlInputFile HtmlInputFile
		{
			get { return _htmlInputFile; }
			set { _htmlInputFile = value; }
		}
		public string FileName
		{
			get { return _fileName; }
			set { _fileName = value; }
		}
		public Utility.FileGroupCode FileGroup
		{
			get { return _fileGroup; }
			set { _fileGroup = value; }
		}
		public string DisplayName
		{
			get { return (string)ViewState["DisplayName"]; }
			set { ViewState["DisplayName"] = value; }
		}
		public bool Required
		{
			get { return MOD.Data.DataHelper.GetBool(ViewState["Required"], false); }
			set { ViewState["Required"] = value; }
		}
		public string RequiredErrorMessage
		{
			get { return MOD.Data.DataHelper.GetString(ViewState["RequiredErrorMessage"], string.Empty); }
			set { ViewState["RequiredErrorMessage"] = value; }
		}
		public string ValidExtensions
		{
			get { return MOD.Data.DataHelper.GetString(ViewState["ValidExtensions"], string.Empty); }
			set { ViewState["ValidExtensions"] = value.Trim(); }
		}
		public string RelativeFilePath
		{
			get
			{
				if (_relativeFilePath != null)
					return _relativeFilePath;
				else if (NamingContainer is IHaveUploadableFiles)
					return (NamingContainer as IHaveUploadableFiles).GetFileRelativePath(this);
				else
					return null;
			}
			set
			{
				_relativeFilePath = value;
			}
		}
		public string FolderPath
		{
			get
			{
				if (_folderPath != null)
					return _folderPath;
				else if (NamingContainer is IHaveUploadableFiles)
					return (NamingContainer as IHaveUploadableFiles).GetFolderPath(this);
				else
					return null;
			}
			set
			{
				_folderPath = value;
			}
		}
		public string GetNewFileName(string fileName)
		{
			return (NamingContainer as IHaveUploadableFiles).GetNewFileName(this, fileName);
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (HtmlInputFile == null)
			{
				GetBaseControls();
			}
			if (HtmlInputFile != null)
			{
				HtmlInputFile.Attributes.Add("onclick", "javascript:document.forms[0].encoding = \"multipart/form-data\";");
			}
		}
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new EventHandler(UploadableFile_PreRender);
		}
		#endregion
		//things to have..
		//way to download file
		//way to automate saving of file (keyed off of filegrouptype)
		public virtual bool Validate()
		{
			if (ValidExtensions.Length == 0)
				return true;
			string ext = MOD.Data.DataHelper.GetString(System.IO.Path.GetExtension(HtmlInputFile.PostedFile.FileName).Substring(1), string.Empty);
			if (ValidExtensions.Length == 0)
				return true;
			string[] arExts = ValidExtensions.Split(',');
			foreach (string validExt in arExts)
				if (string.Compare(ext, validExt, true) == 0)
					return true;
			Globals.AddErrorMessage(Page, "{0} must be one of the following file types: {1}", DisplayName, ValidExtensions);
			return false;
		}
		private void UploadableFile_PreRender(object sender, EventArgs e)
		{
			LinkFile.Visible = RelativeFilePath != null && RelativeFilePath.Trim().Length > 0;
			LinkFile.NavigateUrl = Utility.FileManager.GetAbsoluteHttpUrl(FileGroup, RelativeFilePath);
		}
		public virtual string SaveFile()
		{
			try
			{
				if (HtmlInputFile == null)
				{
					GetBaseControls();
				}
				if (HtmlInputFile == null)
				{
					return "";
				}
				if (HtmlInputFile.PostedFile == null || HtmlInputFile.PostedFile.ContentLength == 0)
				{
					CheckIfRequired();
					return RelativeFilePath;
				}
				if (Validate())
				{
					try
					{
						string fileName = GetNewFileName(HtmlInputFile.PostedFile.FileName);
						string relativePath = FolderPath + fileName;
						string localFilePath = Utility.FileManager.GetAbsoluteFilePath(FileGroup, relativePath);
						string localDirPath = Utility.FileManager.GetAbsoluteFilePath(FileGroup, FolderPath);
						if (!System.IO.Directory.Exists(localDirPath))
							System.IO.Directory.CreateDirectory(localDirPath);
						HtmlInputFile.PostedFile.SaveAs(localFilePath);
						try
						{
							if (RelativeFilePath != null && RelativeFilePath.Trim().Length > 0)
							{
								string oldFilePath = Utility.FileManager.GetAbsoluteFilePath(FileGroup, RelativeFilePath);
								if (string.Compare(oldFilePath, localFilePath, true) != 0)
									System.IO.File.Delete(oldFilePath);
							}
						}
						catch (Exception ex)
						{
							do
							{
								Globals.AddErrorMessage(Page, "Delete Exception: {0}", ex.Message);
							} while ((ex = ex.InnerException) != null);
						}
						return relativePath;
					}
					catch (Exception ex)
					{
						do
						{
							Globals.AddErrorMessage(Page, ex.Message);
						} while ((ex = ex.InnerException) != null);
					}
				}
				return RelativeFilePath;
			}
			catch (Exception ex)
			{
				throw MW.MComm.WalletSolution.Utility.CustomAppException.WrapException(ex, "UploadableFile.Save");
			}
		}
		public string LocalFilePath
		{
			get
			{
				return Utility.FileManager.GetAbsoluteFilePath(FileGroup, RelativeFilePath);
			}
		}
		protected void CheckIfRequired()
		{
			if (Required && (RelativeFilePath == null || RelativeFilePath.Trim() == string.Empty))
			{
				if (RequiredErrorMessage.Length > 0)
					Globals.AddErrorMessage(Page, RequiredErrorMessage);
				else
					Globals.AddErrorMessage(Page, "{0} is required.", DisplayName);
			}
		}
	}
}
