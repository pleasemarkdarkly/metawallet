
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.ComponentModel;
using MW.MComm.WalletSolution.BLL.UserExperience;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.UserExperience
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage FriendlyError related information.</summary>
	///
	/// File History:
	/// <created>11/9/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class FriendlyErrorManager
	{
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method gets a single FriendlyError by an index.</summary>
		///
		/// <param name="errorNumber">The index for FriendlyError to be fetched</param>
		/// <param name="localeCode">The index for FriendlyError to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static string GetFriendlyErrorMessage(BLL.Core.ErrorNumber error, BLL.Environments.LocaleCode localeCode)
		{
			return GetFriendlyErrorMessage(error, (int)localeCode);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single FriendlyError by an index.</summary>
		///
		/// <param name="errorNumber">The index for FriendlyError to be fetched</param>
		/// <param name="localeCode">The index for FriendlyError to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static string GetFriendlyErrorMessage(BLL.Core.ErrorNumber error, int localeCode)
		{
			try
			{
				// perform main method tasks
				int errorNumber = (int)error;
				BLL.UserExperience.FriendlyError friendlyError = BLL.UserExperience.FriendlyErrorManager.GetOneFriendlyError(errorNumber, localeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
				if (friendlyError != null)
				{
					return friendlyError.FriendlyErrorMessage;
				}
				else
				{
					BLL.Core.Error baseError = BLL.Core.ErrorManager.GetOneError(errorNumber);
					if (baseError != null)
					{
						return baseError.ErrorMessage;
					}
				}
				return "";
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.UserExperience.GetFriendlyErrorMessage");
			}
		}
		#endregion Methods
	}
}