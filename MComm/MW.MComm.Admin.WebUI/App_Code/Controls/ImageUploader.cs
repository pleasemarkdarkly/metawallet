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
	/// <summary>
	/// Summary description for ImageUploader
	/// </summary>
	public class ImageUploader : FileUploader
	{
		protected System.Web.UI.WebControls.Image _image;
		protected FlashContainer _flash;
		protected MovieContainer _movie;
		private void GetBaseControls()
		{
			foreach (System.Web.UI.Control loopControl in this.Controls)
			{
				if (loopControl is System.Web.UI.WebControls.Image)
				{
					_image = (System.Web.UI.WebControls.Image)loopControl;
				}
				else if (loopControl is FlashContainer)
				{
					_flash = (FlashContainer)loopControl;
				}
				else if (loopControl is MovieContainer)
				{
					_movie = (MovieContainer)loopControl;
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
				if (loopControl is System.Web.UI.WebControls.Image)
				{
					_image = (System.Web.UI.WebControls.Image)loopControl;
				}
				else if (loopControl is FlashContainer)
				{
					_flash = (FlashContainer)loopControl;
				}
				else if (loopControl is MovieContainer)
				{
					_movie = (MovieContainer)loopControl;
				}
				else
				{
					GetBaseControls(loopControl);
				}
			}
		}
		protected override HyperLink LinkFile
		{
			get { return _linkFile; }
			set { _linkFile = value; }
		}
		public override HtmlInputFile HtmlInputFile
		{
			get { return _htmlInputFile; }
			set { _htmlInputFile = value; }
		}
		Utility.ImageTypeCode _imageTypeCode;
		public Utility.ImageTypeCode ImageTypeCode
		{
			get { return _imageTypeCode; }
			set { _imageTypeCode = value; }
		}
		public string Width
		{
			get { return _image.Width.ToString(); }
			set 
			{
				if (_image == null || _flash == null || _movie == null)
				{
					GetBaseControls();
				}
				if (_image != null)
				{
					_image.Width = new Unit(value);
				}
				if (_flash != null)
				{
					_flash.Width = (int)_image.Width.Value;
				}
				if (_movie != null)
				{
					_movie.Width = (int)_image.Width.Value;
				}
			}
		}
		public string Height
		{
			get { return _image.Height.ToString(); }
			set 
			{
				if (_image == null || _flash == null || _movie == null)
				{
					GetBaseControls();
				}
				if (_image != null)
				{
					_image.Height = new Unit(value);
				}
				if (_flash != null)
				{
					_flash.Height = (int)_image.Height.Value;
				}
				if (_movie != null)
				{
					_movie.Height = (int)_image.Height.Value;
				}
			}
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}
		public System.Web.UI.WebControls.Image Image
		{
			get { return _image; }
			set { _image = value; }
		}
		//DAL.Files.ImageType _imageType = null;
		//public DAL.Files.ImageType ValidImageType
		//{
		//    get
		//    {
		//        if (_imageType == null && _imageTypeCode != 0)
		//            _imageType = BLL.Files.ImageTypeManager.GetOneImageType((int)ImageTypeCode, Globals.DBOptions, Globals.getDataOptions("", ""), Globals.DebugLevel, Globals.CurrentUserID);
		//        return _imageType;
		//    }
		//}
		public int ValidWidth
		{
			get
			{
				return 50;
				//return MOD.Data.DataHelper.GetInt(ValidImageType.Width, 0);
			}
		}
		public int ValidHeight
		{
			get
			{
				return 50;
				//return MOD.Data.DataHelper.GetInt(ValidImageType.Height, 0);
			}
		}
		public override bool Validate()
		{
			if(!base.Validate())
				return false;
			//DAL.Files.ImageType imageType = ValidImageType;
			//if (imageType == null)
			//    return true;
			//assuming swf is valid extension handled by base class
			if(System.IO.Path.GetExtension(_htmlInputFile.PostedFile.FileName).ToLower() == ".swf")
				return true;
			if(System.IO.Path.GetExtension(_htmlInputFile.PostedFile.FileName).ToLower() == ".wmv")
				return true;
			// TODO: no support for limiting by resolution at this point
			//using(System.Drawing.Image image = System.Drawing.Image.FromStream(_htmlInputFile.PostedFile.InputStream))
			//{
			//    if(image != null && imageType != null
			//        && (imageType.Height <= 0 || image.Height == imageType.Height)
			//        && (imageType.Width <= 0 || image.Width == imageType.Width))
			//        return true;
			//    else
			//    {
			//        Globals.AddErrorMessage( Page, "{0} must have a resolution of {1} x {2}", DisplayName, imageType.Width, imageType.Height );
			//        return false;
			//    }
			//}
			return true;
		}
		//public bool IsValidImage(DAL.Files.ImageType imageType)
		//{
		//    if (_htmlInputFile == null)
		//        return false;
		//    // load image
		//    System.Drawing.Image image = System.Drawing.Image.FromStream(_htmlInputFile.PostedFile.InputStream);
		//    if (image != null && image.Height == imageType.Height && image.Width == imageType.Width)
		//        return true;
		//    else
		//        return false;
		//}
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
			this.PreRender += new EventHandler(UploadableImage_PreRender);
		}
		#endregion
		private void UploadableImage_PreRender(object sender, EventArgs e)
		{
			_image.Visible = false;
			_flash.Visible = false;
			_movie.Visible = false;
			string relativeFilePath = RelativeFilePath;
			if (relativeFilePath != null && System.IO.Path.GetExtension(relativeFilePath).ToLower() == ".swf")
			{
				_flash.Visible = relativeFilePath != null && relativeFilePath.Trim().Length > 0;
				_flash.FlashURL = Utility.FileManager.GetAbsoluteFileUrl(FileGroup, relativeFilePath);
			}
			else if (relativeFilePath != null && System.IO.Path.GetExtension(relativeFilePath).ToLower() == ".wmv")
			{
				_movie.Visible = relativeFilePath != null && relativeFilePath.Trim().Length > 0;
				_movie.MovieURL = Utility.FileManager.GetAbsoluteFileUrl(FileGroup, relativeFilePath);
			}
			else
			{
				_image.Visible = true;
				_image.ImageUrl = Utility.FileManager.GetAbsoluteHttpUrl(FileGroup, relativeFilePath,
                    Page.ResolveUrl("~/images/missing_image-75.jpg"));
			}
		}
		public string AutoScaleAndSaveToFile(string imageFilePath)
		{
			string fileName = GetNewFileName(imageFilePath);
			string relativePath = FolderPath + fileName;
			string localFilePath = Utility.FileManager.GetAbsoluteFilePath(FileGroup, relativePath);
			string localDirPath = Utility.FileManager.GetAbsoluteFilePath(FileGroup, FolderPath);
			Globals.AddErrorMessage(Page, "ImageFilePath: {0}", imageFilePath);
			Globals.AddErrorMessage(Page, "RelativeFilePath: {0}", relativePath);
			Globals.AddErrorMessage(Page, "LocalFilePath: {0}", localFilePath);
			Globals.AddErrorMessage(Page, "LocalDirPath: {0}", localDirPath);
			if(!System.IO.Directory.Exists(localDirPath))
				System.IO.Directory.CreateDirectory(localDirPath);
				
			
			using(Bitmap bmp = new Bitmap( ValidWidth, ValidHeight, System.Drawing.Imaging.PixelFormat.Format32bppRgb  ) )
			{
				try
				{
					using(System.Drawing.Image img = System.Drawing.Image.FromFile(imageFilePath))
					{
						bmp.SetResolution(img.HorizontalResolution,img.VerticalResolution);
						using(Graphics gr = Graphics.FromImage(bmp))
						{
							gr.Clear(Color.White);
							gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
							gr.DrawImage(img, 
								new Rectangle(0,0,ValidWidth,ValidHeight),
								new Rectangle(0,0,img.Width,img.Height),
								GraphicsUnit.Pixel);
						}
					}
					bmp.Save(localFilePath,System.Drawing.Imaging.ImageFormat.Jpeg);
					try
					{
						if(RelativeFilePath != null && RelativeFilePath.Trim().Length > 0)
						{
							string oldFilePath = Utility.FileManager.GetAbsoluteFilePath(FileGroup, RelativeFilePath);
							if(string.Compare(oldFilePath,localFilePath,true) != 0)
								System.IO.File.Delete(oldFilePath);
						}
					}
					catch(Exception ex)
					{
						do
						{
							Globals.AddErrorMessage(Page,"Delete Exception: {0}",ex.Message);
						} while( (ex = ex.InnerException) != null );
					}
				}
				catch(Exception ex)
				{
					do
					{
						Globals.AddErrorMessage(Page,ex.Message);
					} while( (ex = ex.InnerException) != null );
				}
			}
			return relativePath;
		}
	}
}
