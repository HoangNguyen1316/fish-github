using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Collections.ObjectModel;
using QLStore.Database;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Windows;
using QLStore.Database_layer;
using QLStore.Statistic;

namespace QLStore.BS_layer
{
    public class Manage_Product
    {
        DBMain DBMain = new DBMain();
        MANAGEMENT_STORE_Entities db = new MANAGEMENT_STORE_Entities();

        public DbSet<Detail_Product> LoadData_Product ()
        {
         
            return db.Detail_Product;           
        }

        public string Create_NewIdproduct_Auto()
        {
            ObservableCollection<Detail_Product> product = new ObservableCollection<Detail_Product>(db.Detail_Product);
            int count = product.Count();
            string s1 = product[count - 1].ID_Product;
            int s2 = Convert.ToInt32(s1.Remove(0, 4));
            string Id_product;
            if (s2 + 1 < 10)
                Id_product = "Item00" + (s2 + 1).ToString();
            else
                Id_product= "Item0" + (s2 + 1).ToString();
            return Id_product;
        }

        

        public ObservableCollection<Detail_Product> Arrange_Product(int Arrangeindex)
        {

           ObservableCollection<Detail_Product> products = new ObservableCollection<Detail_Product>(db.Detail_Product);
             for (int i = 0; i<products.Count -1; i++)
                 for (int j = i+1; j<products.Count; j++)
                 {
                     if (Compare_Product(products[i], products[j], Arrangeindex))
                     {
                         var temp = products[i];
                            products[i] = products[j];
                         products[j] = temp;
                     }
}
             return products;
        }

        public bool Compare_Product (Detail_Product a, Detail_Product b, int i)
        {
            //Nhập kho lâu nhất                  
            var t = (from time in db.Detail_Product
                     join pro in db.Input_Form
                    on time.ID_Product equals pro.ID_Product into k
                     from product in k
                     where a.ID_Product == product.ID_Product
                     select product.Input_Date).FirstOrDefault();
            var r = (from time in db.Detail_Product
                     join pro in db.Input_Form
                     on time.ID_Product equals pro.ID_Product into k
                     from product in k
                     where b.ID_Product == product.ID_Product
                     select product.Input_Date).SingleOrDefault();

            var var1 = (from time in db.Detail_Product
                        join pro in db.Input_Form
                       on time.ID_Product equals pro.ID_Product into k
                        from product in k
                        where a.ID_Product == product.ID_Product
                        select product.Amount).SingleOrDefault();
            var var2 = (from time in db.Detail_Product
                        join pro in db.Input_Form
                        on time.ID_Product equals pro.ID_Product into k
                        from product in k
                        where b.ID_Product == product.ID_Product
                        select product.Amount).SingleOrDefault();
            switch (i)
            {

                case 0: //nhập kho lâu nhất
                    return t > r;

                case 1: //nhập kho gần đây

                    return t < r;
                case 2: //giá tăng dần return true

                    return a.Original_Price > b.Original_Price;

                case 3:// giá giảm dần
                    return a.Original_Price < b.Original_Price;
                case 4: //tồn kho nhiều nhất
                    return a.Amount_Current < b.Amount_Current;
                case 5: //tồn kho ít nhất
                    return a.Amount_Current > b.Amount_Current;
                case 6: //bán chạy nhất                  
                    return (var1 - a.Amount_Current) < (var2 - b.Amount_Current);
                case 7:  //bán ế nhất
                    return (var1 - a.Amount_Current) > (var2 - b.Amount_Current);
                default:
                    return true;
            }

        }
        /*
                public void AddProductFromexcel(Detail_Product product, DateTime dateTime, int amount_init, int capital)
                {
                    db.Detail_Product.Add(product);
                    Input_Form input = new Input_Form();
                    input.ID_Product = product.ID_Product;
                    input.ID_Sup = product.ID_Supplier;
                    input.Input_Date = dateTime;
                    input.Amount = amount_init;
                    //Tao id tự động cho Input
                    ObservableCollection<Input_Form> Input = new ObservableCollection<Input_Form>(db.Input_Form);
                    int count = Input.Count();
                    string s1 = Input[count - 1].ID_Input;
                    int s2 = Convert.ToInt32(s1.Remove(0, 2));

                    if (s2 + 1 < 10)
                        input.ID_Input = "Ip00" + (s2 + 1).ToString();
                    else
                        input.ID_Input = "Ip0" + (s2 + 1).ToString();
                    db.Input_Form.Add(input);
                    db.Detail_Product.Add(product);
                    Type_product type = db.Type_product.FirstOrDefault(x => x.ID == product.ID_TypeProduct);
                    type.Num_Of_Product += product.Amount_Current;

                    db.SaveChanges();
                }*/

        #region Product
        public void AddProduct1(bool isEdit, string ID, string typeName, string Name_sup, DateTime dateTime, string Name, int Price, int amount_init, string descr, string img_Path)
        {

            SqlParameter id = new SqlParameter("@ID", ID);
            string query = "FindIDType";
            DataTable dataTable;
            SqlParameter ID_type = new SqlParameter("@ID_type", DBMain.FindOneValue(query, CommandType.StoredProcedure, new SqlParameter("@NameType", typeName)));
            //Find id sup
            query = "Select * from Supplier where Name_Sup='" + Name_sup + "'";
            dataTable = DBMain.ExecuteQueryDataSet(query, CommandType.Text);
            SqlParameter ID_sup = new SqlParameter("@ID_sup", dataTable.Rows[0][2].ToString());
            SqlParameter namepro = new SqlParameter("@name", Name);
            SqlParameter price = new SqlParameter("@Org_price", Price);
            SqlParameter descrip = new SqlParameter("@Descrp", descr);
            SqlParameter Image = new SqlParameter("@Image_path", img_Path);
            SqlParameter amount = new SqlParameter("@Amount", amount_init);

            List<SqlParameter> parameters_product = new List<SqlParameter>();
            parameters_product.Add(id);
            parameters_product.Add(ID_sup);
            parameters_product.Add(ID_type);
            parameters_product.Add(namepro);
            parameters_product.Add(price);
            parameters_product.Add(descrip);
            parameters_product.Add(Image);

            // Nếu sửa
            #region Edit
            if (isEdit)
            {

                SqlParameter Input_date = new SqlParameter("@Input_date", dateTime);
                query = "FindInputID";
                SqlParameter ID_in = new SqlParameter("@ID", DBMain.FindOneValue(query, CommandType.StoredProcedure, new SqlParameter("@ID_Pro", ID)));
                string ID_input = DBMain.FindOneValue(query, CommandType.StoredProcedure, new SqlParameter("@ID_Pro", ID));
                query = "select * from Input_Form where ID_Input= '" + ID_input + "'";
                //tăng số lượng sp lên
                DataTable b = DBMain.ExecuteQueryDataSet(query, CommandType.Text);
                int num = Int32.Parse(b.Rows[0][4].ToString());
                num += amount_init;
                amount = new SqlParameter("@Amount", num);
                //Update vào input_form
                List<SqlParameter> parameters_Input = new List<SqlParameter>();
                parameters_Input.Add(ID_in);
                parameters_Input.Add(ID_sup);
                parameters_Input.Add(ID_type);
                parameters_Input.Add(amount);
                parameters_Input.Add(Input_date);

                DBMain.MyExecuteNonQuery("Update_Input_Form", CommandType.StoredProcedure, parameters_Input);
                //update Sản phẩm
                parameters_product.Add(amount);
                DBMain.MyExecuteNonQuery("Update_Detail_Product", CommandType.StoredProcedure, parameters_product);

                DataTable oldProduct = DBMain.ExecuteQueryDataSet("Select * form Detail_Product where ID='" + ID + "'", CommandType.Text);
                DataTable oldType = DBMain.ExecuteQueryDataSet("Select * form Type_Product where Type_Product='" + typeName + "'", CommandType.Text);
                if (oldProduct.Rows[0][1].ToString() != oldType.Rows[0][0].ToString()) // Nếu có thay đổi mã sản phẩm
                {
                    // Tăng mã mới
                    int t = Int32.Parse(oldType.Rows[0][2].ToString()) + amount_init;
                    SqlParameter NumofType = new SqlParameter("@Number", t);
                    List<SqlParameter> parameters_type = new List<SqlParameter>();
                    parameters_type.Add(ID_type);
                    parameters_type.Add(new SqlParameter("@Name", typeName));
                    parameters_type.Add(NumofType);
                    DBMain.MyExecuteNonQuery("Update_Type_Product", CommandType.StoredProcedure, parameters_type);

                    int oldAmount = int.Parse(oldType.Rows[0][2].ToString()) + amount_init; // Giảm mã cũ

                    NumofType = new SqlParameter("@Number", oldAmount);
                    SqlParameter oldtype_id = new SqlParameter("@ID", oldProduct.Rows[0][1].ToString());
                    List<SqlParameter> parameters_oldtype = new List<SqlParameter>();
                    parameters_oldtype.Add(oldtype_id);
                    parameters_oldtype.Add(new SqlParameter("@Name", oldType.Rows[0][1].ToString()));
                    parameters_oldtype.Add(NumofType);
                    DBMain.MyExecuteNonQuery("Update_Type_Product", CommandType.StoredProcedure, parameters_type);
                }
            }
            #endregion

            // Nếu thêm
            #region Add
            else // Nếu thêm
            {
                //THÊM SẢN PHẨM VÀO BẢNG Detail_product
                query = "AddnewProduct";
                parameters_product.Add(amount);
                DBMain.MyExecuteNonQuery(query, CommandType.StoredProcedure, parameters_product);
                //tự động tạo ID cho Input_form

                DataTable Input_f = DBMain.ExecuteQueryDataSet("Select * from Input_Form", CommandType.Text);
                string id_previous = Input_f.Rows[Input_f.Rows.Count - 1][0].ToString();
                string s1 = id_previous;
                int s2 = Convert.ToInt32(s1.Remove(0, 2));
                string newID;
                if (s2 + 1 < 10)
                    newID = "Ip00" + (s2 + 1).ToString();
                else
                    newID = "Ip0" + (s2 + 1).ToString();
                SqlParameter ID_in = new SqlParameter("@ID", newID);
                SqlParameter Input_date = new SqlParameter("@Input_date", dateTime);


                //Thêm vào input_form
                query = "AddnewInput_Form";
                List<SqlParameter> parameters_Input = new List<SqlParameter>();
                parameters_Input.Add(ID_in);
                parameters_Input.Add(new SqlParameter("@ID_pro", ID));
                parameters_Input.Add(ID_sup);
               // parameters_Input.Add(ID_type);
                parameters_Input.Add(amount);
                parameters_Input.Add(Input_date);
                DBMain.MyExecuteNonQuery(query, CommandType.StoredProcedure, parameters_Input);

                //Type_product
                string t = DBMain.FindOneValue("FindIDType", CommandType.StoredProcedure, new SqlParameter("@NameType", typeName));
                query = "select * from Type_Product where ID= '" + t + "'";
                DataTable a = DBMain.ExecuteQueryDataSet(query, CommandType.Text);
                int number = Int32.Parse(a.Rows[0][2].ToString()) + amount_init;
                SqlParameter Number = new SqlParameter("@Number", number);

                List<SqlParameter> parameters_Type = new List<SqlParameter>();

                parameters_Type.Add(new SqlParameter("@ID", a.Rows[0][0]));
                parameters_Type.Add(new SqlParameter("@Name", typeName));
                parameters_Type.Add(Number);
                DBMain.MyExecuteNonQuery("Update_Type_Product", CommandType.StoredProcedure, parameters_Type);

            }
            #endregion
            //db.SaveChanges();
        }
        #endregion

        public void AddProduct(bool isEdit, string ID, string typeName, string Name_sup,DateTime dateTime, string Name, int Price, int amount_init, string descr, string img_Path)
        {
            Detail_Product product = new Detail_Product();
            product.ID_Product = ID;
            product.NameProduct = Name;
            product.Original_Price = Price;
            product.Image_Path = img_Path == null ? null : img_Path;
            product.Description_Pro = descr.Length == 0 ? null : descr;
            product.Amount_Current = amount_init;
            Supplier supp = db.Supplier.FirstOrDefault(x => x.Name_Sup == Name_sup);
            if (supp != null)
                product.ID_Supplier = supp.ID_sup;

            //Thêm thông tin vào Input_form cho sản phẩm           
            Type_product type = db.Type_product.FirstOrDefault(x => x.Type_Product1 == typeName);
            if (type != null)
            {
                product.ID_TypeProduct = type.ID;
            }
            else
                product.ID_Product = "sdf";

                // Nếu sửa
                if (isEdit)
                {
                    Input_Form input_ = db.Input_Form.SingleOrDefault(x=> x.ID_Product==ID);
                    input_.Input_Date = dateTime;
                    input_.ID_Sup = supp.ID_sup;
                    
                    var oldProduct = db.Detail_Product.FirstOrDefault(x=>x.ID_Product==ID);
                    oldProduct.NameProduct = product.NameProduct;
                    oldProduct.Original_Price = product.Original_Price;
                    oldProduct.Description_Pro = product.Description_Pro;
                    oldProduct.Image_Path = product.Image_Path;
                    oldProduct.Amount_Current += product.Amount_Current; // Thêm lượng mới nhập vào cả tồn kho ban đầu và tồn kho hiện tại
                    if (oldProduct.ID_TypeProduct != type.ID) // Nếu có thay đổi mã sản phẩm
                    {
                        type.Num_Of_Product++; // Tăng mã mới
                        Type_product oldType = db.Type_product.Find(oldProduct.ID_TypeProduct);
                        oldType.Num_Of_Product--; // Giảm mã cũ
                        oldProduct.ID_TypeProduct = product.ID_TypeProduct;
                    }
                }

                // Nếu thêm
                else // Nếu thêm
                {
                   
                    Input_Form input = new Input_Form();
                    input.ID_Product = ID;
                    input.ID_Sup = supp.ID_sup;
                    input.Input_Date = dateTime;
                    input.Amount = amount_init;
                    //Tao id tự động cho Input
                    ObservableCollection<Input_Form> Input = new ObservableCollection<Input_Form>(db.Input_Form);
                    int count = Input.Count();
                    string s1 = Input[count - 1].ID_Input;
                    int s2 = Convert.ToInt32(s1.Remove(0, 2));

                    if (s2 + 1 < 10)
                        input.ID_Input = "Ip00" + (s2+1).ToString();
                    else
                        input.ID_Input = "Ip0" + (s2+1).ToString();
                    db.Input_Form.Add(input);
                    db.Detail_Product.Add(product);
                    type.Num_Of_Product += product.Amount_Current;
                }
                db.SaveChanges();
            

            //db.SaveChanges();
        }

        public ObservableCollection<Detail_Product> SearchProduct(string text)
        {
            ObservableCollection<Detail_Product> products = new ObservableCollection<Detail_Product>(db.Detail_Product);
            ObservableCollection<Detail_Product> searchproducts = new ObservableCollection<Detail_Product>();

            for (int i=0;i<products.Count;i++)
            {
                if (products[i].NameProduct.Contains(text))
                    searchproducts.Add(products[i]);
            }
            return searchproducts;
        }

        //Type product

        public DbSet<Type_product> Load_ProductType ()
        {
            return db.Type_product;
        }

        public bool  AddNewTypeproduct (string ID, string name)
        {
            Type_product a = new Type_product();
            a.ID = ID;
            a.Type_Product1 = name;
            a.Num_Of_Product = 0;
            try
            {
                db.Type_product.Add(a);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
           
        }

        public bool DeleteTypeProduct (string id)
        {
            try
            {

                Type_product a = new Type_product();
                a.ID = id;
                db.Type_product.Attach(a);
                db.Type_product.Remove(a);

                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
            
        }

        public void EditProduct (string IdType, string NameType)          
        {
           
                var pro = (from type in db.Type_product
                           where type.ID == IdType
                           select type).SingleOrDefault();
                if (pro != null)
                {
                    pro.Type_Product1 = NameType;
                    db.SaveChanges();
                }           
        }
        // Các hàm lấy dữ liệu cho Detail_page 

        public DateTime GetDateImport(Detail_Product product)
        {
            var  query= (from time in db.Detail_Product
                         join pro in db.Input_Form
                        on time.ID_Product equals pro.ID_Product into k
                         from prod in k
                         where  product.ID_Product == prod.ID_Product
                         select prod.Input_Date).SingleOrDefault();
            return (DateTime) query;
        }

        public string GetIDType(string nametype)
        {
            //return name type
            var query = (from type in db.Type_product
                         where type.Type_Product1 == nametype
                         select type.ID).SingleOrDefault();
            return query.ToString();
        }

        public Type_product getType(string idProduct)
        {
            ObservableCollection<Type_product> a =new ObservableCollection<Type_product>(Load_ProductType());
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].ID == idProduct) return a[i];
            }
            return null;
        }

        public int GetinitialAmount (Detail_Product product)
        {
            var query = (from time in db.Detail_Product
                         join pro in db.Input_Form
                         on time.ID_Product equals pro.ID_Product into k
                         from prod in k
                         where product.ID_Product == prod.ID_Product
                         select prod.Amount).SingleOrDefault();
            return (int) query;
        }

        public string GetType (Detail_Product product)
        {
            var query = (from a in db.Detail_Product
                         join b in db.Type_product
                         on a.ID_TypeProduct equals b.ID into k
                         from prod in k
                         where product.ID_Product == a.ID_Product
                         select prod.Type_Product1).SingleOrDefault();
            return query.ToString();
        }

        public ObservableCollection<string> getListTypeName()
        {
            ObservableCollection<string> t = new ObservableCollection<string>();
            ObservableCollection<Type_product> a = new ObservableCollection<Type_product>( Load_ProductType());
            for (int i = 0; i < a.Count; i++)
            {
                t.Add(a[i].Type_Product1);
            }
            return t;
        }

        public string GetSupplier (Detail_Product product)
        {
            try
            {
                var query = (from a in db.Detail_Product
                             join b in db.Supplier
                             on a.ID_Supplier equals b.ID_sup into k
                             from prod in k
                             where product.ID_Product == a.ID_Product
                             select prod.Name_Sup).SingleOrDefault();

                return query.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

               // return query.ToString();
            }
            return "t";

        }
        // mới thêm
        //Bill
        public ObservableCollection<Bills> Load_Bill (string ID_product)
        {
            ObservableCollection<Bills> listbill = new ObservableCollection<Bills>();
            
            try
            {
                var query = (from a in db.Output_Form
                             where a.ID_Product == ID_product
                             select a);
                if (query != null)
                    foreach (Output_Form t in query)
                    {
                        Bills bill = new Bills();
                        bill.CustName = db.Customers.FirstOrDefault(x => x.ID_Customer == t.ID_Customer).Name_Cus;
                        bill.Date = db.Output_Form.FirstOrDefault(x => x.ID_Product == ID_product).Output_Date.ToString();
                        bill.Price_sale = db.Output_Form.FirstOrDefault(x => x.ID_Product == ID_product).Price_Sale.ToString();
                        bill.Amountsale = db.Output_Form.FirstOrDefault(x => x.ID_Product == ID_product).Amount.ToString();
                        listbill.Add(bill);
                       // MessageBox.Show(listbill[count].CustName + "," + listbill[count].Date);
                    }
                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
            return listbill;
        }

        public void DeleteProduct(Detail_Product product)
        {
                           
            db.Detail_Product.Attach(product);
            db.Detail_Product.Remove(product);
            Input_Form input_ =new Input_Form();
            input_ = db.Input_Form.FirstOrDefault(x => x.ID_Product == product.ID_Product);
            db.Input_Form.Attach(input_);
            db.Input_Form.Remove(input_);
            db.SaveChanges();                     
        }


        //Supplier
        public DbSet<Supplier> LoadData_Supplier()
        {

            return db.Supplier;
        }

        public void AddnewSupplier(string id, string name, string addr, string phone, string email, string more)
        {
            Supplier a = new Supplier();
            a.ID_sup = id;
            a.Name_Sup = name;
            a.Phone = phone;
            a.MoreInfo = more;
            a.Email = email;
            a.Address_sup = addr;
            //try
            //{
                db.Supplier.Add(a);
                db.SaveChanges();
            //}
            //catch
            //{
            //    return;
            //}                      
        }
        public string Create_NewIdSupplier_Auto()
        {
            ObservableCollection<Supplier> sup = new ObservableCollection<Supplier>(db.Supplier);
            int count = sup.Count();
            string s1 = sup[count - 1].ID_sup;
            int s2 = Convert.ToInt32(s1.Remove(0, 4));
            string Id_sup;
            if (s2 + 1 < 10)
                Id_sup = "SUPP00" + (s2 + 1).ToString();
            else
                Id_sup = "SUPP0" + (s2 + 1).ToString();
            return Id_sup;
        }


        public void DeleteSupplier (Supplier a)
        {

            db.Supplier.Attach(a);
            db.Supplier.Remove(a);           
            var pro = from pros in db.Detail_Product
                      where pros.ID_Supplier == a.ID_sup
                      select pros;
           
                     foreach (Detail_Product product in pro)
                     {

                         db.Detail_Product.Attach(product);
                         db.Detail_Product.Remove(product);
                         Input_Form input_ = new Input_Form();
                         input_ = db.Input_Form.FirstOrDefault(x => x.ID_Product == product.ID_Product);
                         db.Input_Form.Attach(input_);
                         db.Input_Form.Remove(input_);
                         
                     }
            db.SaveChanges();

        }

        public void EditSupplier (string id, string name, string addr, string phone, string email, string more)
        {
            var sup = (from s in db.Supplier
                       where s.ID_sup == id
                       select s).SingleOrDefault();

            try
            {
                if (sup!=null)
                {
                    sup.Name_Sup = name;
                    sup.MoreInfo = more;
                    sup.Phone = phone;
                    sup.Email = email;
                    sup.Address_sup = addr;
                    db.SaveChanges();
                }
            }
            catch
            {
                return;
            }

            //mới thêm          
        }
        public ObservableCollection<Bill_Show> Load_ListBill()
        {
            ObservableCollection<Output_Form> out_form = new ObservableCollection<Output_Form>(db.Output_Form);
            ObservableCollection<Bill_Show> a = new ObservableCollection<Bill_Show>();
            for (int i = 0; i < out_form.Count; i++)
            {
                
                Bill_Show n = new Bill_Show();
                n.ID_output = out_form[i].ID_Output;
                n.Namepro = db.Detail_Product.Find(out_form[i].ID_Product).NameProduct;
                n.Initial_price =n.Sale_price= Int32.Parse(db.Detail_Product.Find(out_form[i].ID_Product).Original_Price.ToString());
                n.Name_Cus = db.Customers.Find(out_form[i].ID_Customer).Name_Cus;
                n.status = out_form[i].Status;
                n.ID_PRO = out_form[i].ID_Product;
                n.Online = out_form[i].BuyOnline;
                n.Amount =(Int32) out_form[i].Amount;
                n.DateCreate = (DateTime) out_form[i].Output_Date;
                n.Phone = db.Customers.Find(out_form[i].ID_Customer).Phone;
                n.Ship =(int) out_form[i].Ship;
                n.Address = db.Customers.Find(out_form[i].ID_Customer).Address_Cus;
                n.Email = db.Customers.Find(out_form[i].ID_Customer).Email == "" ? "" : db.Customers.Find(out_form[i].ID_Customer).Email;
                n.birthday = (DateTime) db.Customers.Find(out_form[i].ID_Customer).Birthday;
                //lấy danh sách các Bill để show lên listbill
                a.Add(n);
            }

            return a;
        }

        //Sắp xếp Bill
        public ObservableCollection<Bill_Show> Arrange_ListBill(int Arrangeindex)
        {
            ObservableCollection<Bill_Show> Bills = Load_ListBill();
            ObservableCollection<Bill_Show> returnBill = new ObservableCollection<Bill_Show>();
            if (Arrangeindex == 0)
                return Bills;
            if(Arrangeindex==1)
            {
                for (int i = 0; i < Bills.Count - 1; i++)
                    if (Bills[i].status == "Complete")
                        returnBill.Add(Bills[i]);
                return returnBill;
            }

            if( Arrangeindex==2)
            {
                for (int i = 0; i < Bills.Count - 1; i++)
                    if (Bills[i].status == "Not Complete")
                        returnBill.Add(Bills[i]);
                return returnBill;
            }


            if(Arrangeindex==3)
            {
                for (int i = 0; i < Bills.Count - 1; i++)
                    for (int j = i + 1; j < Bills.Count; j++)
                    {                       
                        if (Bills[i].DateCreate< Bills[j].DateCreate ) 
                        {
                            var temp = Bills[i];
                            Bills[i] = Bills[j];
                            Bills[j] = temp;
                        }
                    }
                return Bills;
            }
            if (Arrangeindex == 4)
            {
                for (int i = 0; i < Bills.Count - 1; i++)
                    for (int j = i + 1; j < Bills.Count; j++)
                    {
                        if (Bills[i].DateCreate > Bills[j].DateCreate)
                        {
                            var temp = Bills[i];
                            Bills[i] = Bills[j];
                            Bills[j] = temp;
                        }
                    }
                return Bills;
            }

            if (Arrangeindex == 5)
            {
                for (int i = 0; i < Bills.Count - 1; i++)
                    if (Bills[i].status == "Not Complete")
                        returnBill.Add(Bills[i]);
                return returnBill;
            }
          

            if (Arrangeindex == 6)
            {
                for (int i = 0; i < Bills.Count - 1; i++)
                    if (Bills[i].Online.Trim() == "Yes")
                        returnBill.Add(Bills[i]);
                return returnBill;
            }
            if (Arrangeindex == 7)
            {
                for (int i = 0; i < Bills.Count - 1; i++)
                    if (Bills[i].Online.Trim() == "No")
                        returnBill.Add(Bills[i]);
                return returnBill;
            }

            return Bills;
        }

        public void UpdateStatusBill (Bill_Show bill_)
        {
            var t=db.Output_Form.Find(bill_.ID_output);
            t.Status = "Complete";
            db.SaveChanges();

        }

        public void CancelBill (Bill_Show bill)
        {
            
            var curProduct = db.Detail_Product.Find(bill.ID_PRO);
            var curBill = db.Output_Form.Find(bill.ID_output);

            // Đưa lại vào kho
            curProduct.Amount_Current += (bill.Amount ); // Tính cả phần tặng

            // Cập nhật trạng thái
            curBill.Status = "Canceled";

            db.SaveChanges();
        }

        public bool CheckCurrentAmount (string id_product,int number)
        {
            var t = db.Detail_Product.Find(id_product);
            if(t!=null)
            {
                if (t.Amount_Current < number) return false;
                else
                    return true;
            }
            return false;
        }

        public string Create_NewIdOutput_Auto()
        {
            ObservableCollection<Output_Form> output_Forms = new ObservableCollection<Output_Form>(db.Output_Form);
            int count = output_Forms.Count();
            string s1 = output_Forms[count - 1].ID_Output;
            int s2 = Convert.ToInt32(s1.Remove(0, 3));
            string Id_out;
            if (s2 + 1 < 10)
                Id_out = "Out00" + (s2 + 1).ToString();
            else
                Id_out = "Out0" + (s2 + 1).ToString();
            return Id_out;
        }

        public string Create_NewIdCustomer_Auto()
        {
            ObservableCollection<Customer> customers = new ObservableCollection<Customer>(db.Customers);
            int count = customers.Count();
            string s1 = customers[count - 1].ID_Customer;
            int s2 = Convert.ToInt32(s1.Remove(0, 3));
            string Id;
            if (s2 + 1 < 10)
                Id = "CUS00" + (s2 + 1).ToString();
            else
                Id = "CUS0" + (s2 + 1).ToString();
            return Id;
        }

        public void AddnewOutput(Bill_Show bill_)
        {
            Output_Form a = new Output_Form();
            a.ID_Output = bill_.ID_output;            
            a.ID_Product = bill_.ID_PRO;
            a.Note = "";
            a.Output_Date = bill_.DateCreate;
            a.Price_Sale = bill_.Sale_price;
            a.Ship = bill_.Ship;
            a.Status = bill_.status;
            a.Amount = bill_.Amount;
            a.BuyOnline = bill_.Online;
            //nếu khách hàng đã tồn tại thì ko cần thêm vào
            if (db.Customers.Find(bill_.Phone) == null) //chưa tồn tại
            {
                Customer b = new Customer()
                {
                    ID_Customer = Create_NewIdCustomer_Auto(),
                    Phone = bill_.Phone,
                    Name_Cus = bill_.Name_Cus,
                    Address_Cus = bill_.Address == null ? "" : bill_.Address,
                    Email = bill_.Email,
                    Birthday =(DateTime) bill_.birthday,

                };
                a.ID_Customer = b.ID_Customer;

                db.Customers.Add(b);

            }
            else
                a.ID_Customer = db.Customers.Find(bill_.Phone).ID_Customer;

            db.Output_Form.Add(a);
            db.SaveChanges();                              
        }
        //Statistic
        public ObservableCollection<InstanceStatistic> getProductPeriod(DateTime start, DateTime finish)
        {

            var q = from output in db.Output_Form
                    join detail in db.Detail_Product
                    on output.ID_Product equals detail.ID_Product
                    where output.Output_Date >= start & output.Output_Date <= finish
                    select new { Amout = output.Amount, IDProduct = output.ID_Product, IDTypeProduct = detail.ID_TypeProduct, Price = output.Price_Sale };
            var p = (from itemProduct in q
                     group itemProduct by itemProduct.IDTypeProduct
                    into g
                     select new InstanceStatistic
                     {
                         NameType = g.Key,
                         AmountType = g.Sum(s => s.Amout.Value),
                         TotalProceed = g.Sum(s => s.Price.Value)
                     });
            ObservableCollection<InstanceStatistic> tmpList = new ObservableCollection<InstanceStatistic>();

            foreach (var item in p)
            {
                InstanceStatistic temp = (InstanceStatistic)item;
                tmpList.Add(temp);
            }
            return tmpList;

        }
        public Type_product getTypeList(string nameProduct)
        {
            return db.Type_product.FirstOrDefault(x => x.Type_Product1 == nameProduct);
        }
        public ObservableCollection<Type_product> getTypeList()
        {
            var temp = db.Type_product;
            ObservableCollection<Type_product> listTmp = new ObservableCollection<Type_product>();
            foreach (Type_product item in temp)
            {
                Type_product tempItem = (Type_product)item;
                listTmp.Add(tempItem);
            }
            return listTmp;
        }
        #region Customer
        public DbSet<Customer> Load_Customer()
        {
            return db.Customers;

        }
        public bool DeleteCustomer(string id)
        {
            try
            {
                Customer cus = (from customer in db.Customers
                                where customer.ID_Customer == id
                                select customer).SingleOrDefault();
                db.Customers.Remove(cus);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool AddNewCustomer(string ID, string name, string address, string phone, string gmail, DateTime birthday)
        {
            //Type_product hasValue = (from type in db.Type_product
            //                         where type.ID == ID
            //                         select type).SingleOrDefault();
            Customer hasValue = (from cus in db.Customers
                                 where cus.ID_Customer == ID
                                 select cus).SingleOrDefault();

            if (hasValue == null)
            {
                Customer cus = new Customer();
                cus.ID_Customer = ID;
                cus.Name_Cus = name;
                cus.Phone = phone;
                cus.Email = gmail;
                cus.Birthday = birthday;
                cus.Address_Cus = address;
                try
                {
                    // Entity
                    db.Customers.Add(cus);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }

            }
            else
            {

                // try
                // {
                //Type_product tmp = (Type_product)hasValue;
                //tmp.Type_Product1 = "";
                //tmp.Type_Product1 = name
                var cus = db.Customers.Find(ID);  //:)

                cus.ID_Customer = ID;
                cus.Name_Cus = name;
                cus.Phone = phone;
                cus.Email = gmail;
                cus.Birthday = birthday;
                cus.Address_Cus = address;
                // Mark as Changed
                db.Entry(cus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                //hasValue.Type_Product1 = name;
                //db.Entry(hasValue).State = EntityState.Modified;
                //db.SaveChanges();

                // db.SaveChanges();




                //}
                //   catch
                //   {
                //  return false;
                //}
            }
            return true;

        }
        #endregion


        #region STAFF

        public ObservableCollection<Staff> LoadData_Staff()
        {
            ObservableCollection<Staff> list = new ObservableCollection<Staff>(db.Staff);
            
            return list;
        }

        public ObservableCollection<string> LoadListNamestaff()
        {
            ObservableCollection<string> a = new ObservableCollection<string>();
            ObservableCollection<Staff> list = LoadData_Staff();

            for (int i = 0; i < list.Count; i++)
            {
                a.Add(list[i].Name_staff);
            }

            return a;
        }

        public string Create_NewIdstaff_Auto()
        {
            ObservableCollection<Staff> staffs = LoadData_Staff();
            int count = staffs.Count();
            string s1 = staffs[count - 1].ID;
            int s2 = Convert.ToInt32(s1.Remove(0, 2));
            string Id;
            if (s2 + 1 < 10)
                Id = "NV00" + (s2 + 1).ToString();
            else
                Id = "NV0" + (s2 + 1).ToString();
            return Id;
        }

        public void AddStaff(bool isEdit, string ID, string Name, string address, DateTime birthday, DateTime startwork, string sex, string Phone, string position, string img_Path)
        {
           if(isEdit)
           {
                var staff = db.Staff.FirstOrDefault(x => x.ID == ID);
                staff.Name_staff = Name;
                staff.Address_ = address;
                staff.Birthday = birthday;
                staff.Startwork = startwork;
                staff.Sex = sex;
                staff.position = position;
                staff.Phone = Phone;
                staff.Image_path = img_Path;
                
           }

           else
           {
                Staff staff = new Staff();
                staff.ID = ID;
                staff.Name_staff = Name;
                staff.Address_ = address;
                staff.Birthday = birthday;
                staff.Startwork = startwork;
                staff.Sex = sex;
                staff.position = position;
                staff.Phone = Phone;
                staff.Image_path = img_Path;
                db.Staff.Add(staff);
           }
            db.SaveChanges();
        }

        public void DeleteStaff(string ID)
        {
            var staff = db.Staff.FirstOrDefault(x => x.ID == ID);
            db.Staff.Attach(staff);
            db.Staff.Remove(staff);
        }

        public ObservableCollection<Detail_Product> FilterProduct(string Type)
        {
            String idtype = GetIDType(Type);

            ObservableCollection<Detail_Product> list = new ObservableCollection<Detail_Product>();
            var query = (from product in db.Detail_Product
                        where product.ID_TypeProduct == idtype
                        select product);
            foreach (var pro in query)
                list.Add(pro);
            return list;

        }

        #endregion

        //lOGIN
        public bool CheckLogin(string Name, string pass)
        {
            var query = (from s in db.LoginUsers
                         where s.NameLog == Name
                         select pass).FirstOrDefault();
            if (query == null) return false;
            if (query.ToString().Trim() == pass) return true;
            return false;

        }

        public DbSet<LoginUser> LoadLogin()
        {
            return db.LoginUsers;
        }

        public bool ChangeLogin (string login,string name,string oldpass, string newpass)
        {
            ObservableCollection<LoginUser> a = new ObservableCollection<LoginUser>(db.LoginUsers);

            if(login=="admin")
            {
                string t = a[0].ID;
                var query = db.LoginUsers.Find(a[0].ID);
                if(query!=null)
                {
                    if (oldpass == a[0].Pass.Trim())
                    {
                        query.NameLog = name;
                        query.Pass = newpass;
                        db.SaveChanges();
                    }
                    else
                        return false;
                }
            }

            else
            {
                string t = a[1].ID;
                var query = db.LoginUsers.Find(a[1].ID);
                if (query != null)
                {
                    if (oldpass == a[1].Pass.Trim())
                    {
                        query.NameLog = name;
                        query.Pass = newpass;
                        db.SaveChanges();
                    }
                    else
                        return false;
                }
            }
           
          
            return true;
        }
    }
}
