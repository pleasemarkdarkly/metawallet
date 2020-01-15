
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using MOD.Data;
using MW.MComm.WalletSolution.Utility;
namespace MW.MComm.WalletSolution.BLL
{
	public class SortableList<T> : List<T> where T : PersistedBusinessObject, new()
	{
		public virtual bool IsDirty
		{
			get
			{
				foreach (T item in this)
				{
					if (item.IsDirty)
					{
						return true;
					}
				}
				return false;
			}
		}
		public SortableList()
		{ }
		/// <summary>
		/// Constructs a list of business objects from a collection of data objects.
		/// Recurses the object graph of each object
		/// </summary>
		/// <param name="items"></param>
		public SortableList(SortableObjectCollection items)
			: this(items, true, false)
		{ }
		public SortableList(SortableObjectCollection items, bool recurse)
			: this(items, recurse, false, new Hashtable(50, new ReferenceEqualityComparer()))
		{ }
		public SortableList(SortableObjectCollection items, bool recurse, bool clearDirtyState)
			: this(items, recurse, clearDirtyState, new Hashtable(50, new ReferenceEqualityComparer()))
		{ }
		public SortableList(SortableObjectCollection items, bool recurse, Hashtable processed)
			: this(items, recurse, false, processed)
		{ }
		public SortableList(SortableObjectCollection items, bool recurse, bool clearDirtyState, Hashtable processed)
		{
			if (items == null) return;
			foreach (BaseDataAccessObject dataObject in items)
			{
				T businessObject = new T();
				if (processed.Contains(dataObject) &&
					processed[dataObject].GetType().FullName == businessObject.GetType().FullName)
				{
					this.Add((T)processed[dataObject]);
				}
				else
				{
					processed[dataObject] = businessObject;
					ReflectionHelper.Copy(dataObject, businessObject, recurse, dataObject.GetType(), businessObject.GetType(), processed);
					this.Add(businessObject);
				}
			}
			if (clearDirtyState) ClearDirtyState(true);
		}
		public SortableList(SortableList<T> items, bool recurse)
		{
			foreach (T item in items)
			{
				T businessObject = new T();
				ReflectionHelper.Copy(item, businessObject, recurse, item.GetType(), businessObject.GetType(),
					new Hashtable(50, new ReferenceEqualityComparer()));
				this.Add(businessObject);
			}
		}
		public SortableList(SortableList<T> items, bool recurse, Hashtable processed)
		{
			foreach (T item in items)
			{
				T businessObject = new T();
				ReflectionHelper.Copy(item, businessObject, recurse, item.GetType(), businessObject.GetType(), processed);
				this.Add(businessObject);
			}
		}
		public T FindByHashCode(int hashCode)
		{
			foreach (T t in this)
			{
				if (t.GetHashCode() == hashCode)
					return t;
			}
			return null;
		}
		public T Find(int hashCode)
		{
			return FindByHashCode(hashCode);
		}
		public virtual object Find(string propertyName, object propertyValue)
		{
			foreach (object o in this)
			{
				PropertyInfo propInfo = o.GetType().GetProperty(propertyName);
				object val = propInfo.GetValue(o, null);
				if (0 == Comparer.Default.Compare(Convert.ChangeType(propertyValue, propInfo.PropertyType), val))
					return o;
			}
			return null;
		}
		public virtual void ClearDirtyState()
		{
			foreach (T item in this)
			{
				item.ClearDirtyState();
			}
		}
		public virtual void ClearDirtyState(bool clearItemDirtyState)
		{
			foreach (T item in this)
			{
				item.ClearDirtyState(true);
			}
		}
		public virtual void Sort(string propertyName1, SortDirection sortDirection1, string propertyName2, SortDirection sortDirection2)
		{
			Sort(new GenericTwoPropertyComparer<T>(propertyName1, sortDirection1, propertyName2, sortDirection2));
		}
		public void Sort(string propertyName, SortDirection sortDirection)
		{
			if (propertyName != string.Empty)
			{
				Sort(new GenericComparer<T>(propertyName, sortDirection));
			}
		}
	}
}