using System;
using System.Collections.Generic;
using System.Text;
using MOD.Data;
using MW.MComm.Ganadero.Utility;

namespace MW.MComm.Ganadero.BLL
{
    public class SortableList<T> : List<T> where T : BusinessObject, new()
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
			: this(items, recurse, false)
		{ }
		
		public SortableList(SortableObjectCollection items, bool recurse, bool clearDirtyState)
        {
            if (items == null) return;
            
            foreach (BaseDataAccessObject dataObject in items)
            {
                T businessObject = new T();
                ReflectionHelper.Copy(dataObject, businessObject, recurse);
                this.Add(businessObject);
            }

			if (clearDirtyState) ClearDirtyState(true);
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
            throw new NotImplementedException();
        }

        public void Sort(string propertyName, SortDirection sortDirection)
        {
            Sort(new GenericComparer<T>(propertyName, sortDirection));
        }

	}
}