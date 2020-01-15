/*<copyright>
 MOD Systems, Inc (c) 2005 All Rights Reserved. 720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036 
All Rights Reserved, (c) 2005, covered by Trademark Laws, contents are considered Restricted Secrets 
by MOD Systems.  The contents also may only be viewed by MOD Systems Engineers (employees) and selected 
SBUX employees as outlined in the Licensing Agreement between MOD Systems and Starbuck Corporation on 
June 3rd, 2005.   
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, 
read, or have access to any part or whole of software source code.  If you have done so, immediatly 
report yourself to your manager. 
Do not reproduce any portions of this software.  Unauthorized use or disclosure of this information 
could impact MOD System's competitive advantage.   
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel 
or otherwise, to any intellectual property rights is granted in this source code.   
CONFIDENTIAL SOURCE CODE
</copyright>*/

using System;
using System.Security.Principal;
using System.Collections;
namespace MW.MComm.Ganadero.Utility
{

	/// <summary>
	/// Summary description for FastGenericPrincipal.
	/// </summary>
	public class FastGenericPrincipal : IPrincipal 
	{
		private IIdentity _identity;
		private IDictionary _roles;

		private Guid _userID = MOD.Data.DefaultValue.Guid;

		public FastGenericPrincipal(IIdentity identity, IDictionary roles)
		{
			_identity = identity;
			_roles = roles;
			Initialize();
		}

		public FastGenericPrincipal(IIdentity identity, ICollection roles)
		{
			_identity = identity;
			_roles = new Hashtable(roles.Count);
			foreach(string role in roles)
				_roles[role] = true;
			Initialize();
		}

		private void Initialize()
		{
			_userID = MOD.Data.DataHelper.GetGuid(_identity.Name,MOD.Data.DefaultValue.Guid);
		}

		public virtual IIdentity Identity
		{
			get { return _identity; }
		}

		public virtual bool IsInRole(string role)
		{
			return role != null && _roles != null && _roles.Contains(role);
		}

		public virtual Guid UserID
		{
			get { return _userID; }
		}
	}
}
