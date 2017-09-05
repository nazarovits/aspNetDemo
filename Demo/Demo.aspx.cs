using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Category(string name, string description="")
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

    public class DemoCategories
    {
        public static List<Category> Items = new List<Category>();

        public List<Category> FetchMany()
        {
            return Items;
        }

        public List<Category> GetList()
        {
            return DemoCategories.Items;
        }

        public void Add(Category item)
        {
            Items.Add(item);
        }

        public void Remove(int id)
        {
            var item = Items.Find(el => el.Id == id);

            Items.Remove(item);
        }
    }

    public partial class Demo : System.Web.UI.Page
    {
        public List<Category> CategoryItems
        {
            get {
                // try to get from Application:
                var _items = (List<Category>)Application.Get("CategoryItems");

                if (_items == null)
                {
                    // initial values:
                    _items = new List<Category>
                    {
                        new Category("Category 1"),
                        new Category("Category 2"),
                        new Category("Category 3")
                    };

                    CategoryItems = _items; // Store in private and olso in App
                }

                return _items;    
            }
            set { 
                 Application.Set("CategoryItems", value);
            }
        }

        private void DisplayItems()
        {
            Log(CategoryItems.Aggregate("", (str, cat) => str += cat.Name + "; "));
        }

        private void Log(string text)
        {
            // InfoBox.InnerHtml += $"<p>{text}</p>";
            Console.WriteLine(text);
        }

        protected void Page_Init(object sender, EventArgs eventArgs)
        {
            Log(">>> init <<<");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            categoryListBox.DataSource = CategoryItems;
            categoryListBox.DataBind();

            categoriesRepeater.DataSource = CategoryItems;
            categoriesRepeater.DataBind();

            Log(">>> Load <<<");
        }

        protected void SubmitFormBtn_Click(object sender, EventArgs eventArgs)
        {
            Log(">>> Submit btn click <<<");

            string info = InfoBox.InnerText;
            string name = CategoryName.Text;
            string description = CategoryDescription.Text;

            var newCategory = new Category(name, description);

            CategoryItems.Add(newCategory);

            DisplayItems();
        }

        protected void RemoveById(int id)
        {
            int index = CategoryItems.FindIndex(el => el.Id == id);
            CategoryItems.RemoveAt(index);
            categoryListBox.DataBind();
        }

        protected void OnDeleteButton_Click(object sender, EventArgs eventArgs)
        {
            Button DeleteButton = (Button)sender;
            // HtmlButton

            try
            {
                int intId = Convert.ToInt32(DeleteButton.Attributes["data-id"]);
                RemoveById(intId);
            }
            catch (Exception ex)
            {
                Log($">>> Exception {ex.Message}");
            }
        }
    }
}