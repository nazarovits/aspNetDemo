using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoElements
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Category(string name, string description = "")
        {
            Id = GetNextId();
            Name = name;
            Description = description;
        }

        private static int _lastId = 0;
        public static int GetNextId()
        {
            _lastId++;

            return _lastId;
        }
    }

    public interface IListEl
    {
        int Id { get; }
    }

    public interface IBaseListView
    {
    }

    public partial class BaseListView<IListEl> : System.Web.UI.Page, IBaseListView where IListEl : new()
    {
        
        private string _appCollectionName = "CollectionName"; // Need to override
        public List<IListEl> ListItems
        {
            get
            {
                // try to get from Application:
                var _items = (List<IListEl>)Application.Get(_appCollectionName);

                if (_items == null)
                {
                    // initial values:
                    _items = new List<IListEl>();
                    ListItems = _items; // Store in private and olso in App
                }

                return _items;
            }
            set
            {
                Application.Set(_appCollectionName, value);
            }
        }

        protected void Page_Init(object sender, EventArgs eventArgs)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            object deleteIdStr = Request.QueryString.Get("deleteId");

            if (deleteIdStr != null)
            {
                try
                {
                    int deleteId = int.Parse(deleteIdStr.ToString());
                    // RemoveById(deleteId);
                }
                catch (Exception ex)
                {
                }
            }
        }

        /*protected void RemoveById(int id)
        {
            int index = ListItems.FindIndex(el => (IListEl)el.Id == id);
            ListItems.RemoveAt(index);
        }*/
    }
}