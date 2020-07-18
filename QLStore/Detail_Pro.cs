using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLStore
{
    public class Detail_Pro
    {
        public string ID_Product { get; set; }
        public string ID_TypeProduct { get; set; }
        public string ID_Supplier { get; set; }
        public Nullable<int> Original_Price { get; set; }
        public string NameProduct { get; set; }
        public string Description_Pro { get; set; }
        public string Image_Path { get; set; }
        public Nullable<int> Amount_Current { get; set; }

        //public ObservableCollection<Object> ConverseTabletoObs(DataTable a)
        //{
        //    DataTable TestTable = new DataTable();
        //    TestTable.Columns.Add(new DataColumn("ID_Product", typeof(string)));
        //    TestTable.Columns.Add(new DataColumn("ID_TypeProduct", typeof(string)));
        //    TestTable.Columns.Add(new DataColumn("ID_Supplier", typeof(string)));
        //    TestTable.Columns.Add(new DataColumn("Original_Price", typeof(int)));
        //    TestTable.Columns.Add(new DataColumn("NameProduct", typeof(string)));
        //    TestTable.Columns.Add(new DataColumn("Image_Path", typeof(string)));
        //    TestTable.Columns.Add(new DataColumn("Amount_Current", typeof(int)));

        //    var test = new ObservableCollection<Detail_Pro>();
        //    foreach (DataRow row in TestTable.Rows)
        //    {
        //        test.Add(new Detail_Pro()
        //        {
        //            ID_Product = (string)row["ID_Product"],
        //            ID_Supplier = (string)row["ID_Supplier"],
        //            ID_TypeProduct = (string)row["ID_TypeProduct"],

        //        });
        //        //test.Add(obj);
        //    }
        //}
    }
}

