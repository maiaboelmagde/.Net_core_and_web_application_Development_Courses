using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.EntityList;
using DAL;

namespace BLL.EntityManager
{
    public class TitleManager
    {

        //"SELECT * FROM titles INNER JOIN publishers ON publishers.pub_id = titles.pub_id"


        static DBManager manager = new();

        public static TitlesList SelectALLTitles()
        {
            TitlesList titles = new();
            try
            {
                //return DataTableToTitleList(manager.ExecuteDataTable("SELECT * FROM titles INNER JOIN publishers ON publishers.pub_id = titles.pub_id"));
                return DataTableToTitleList(manager.ExecuteDataTable("SELECT * FROM titles"));
            }
            catch
            {

            }
            return titles;
        }

        

        public static bool InsertTitle(Title InsertedTitle, int TitlesCount)
        {
            try
            {
                Dictionary<string, object> Parameters = new()
                {
                    ["title_id"] = GenerateUniqueTitleId(TitlesCount),
                    ["title"] = InsertedTitle.title,
                    ["type"] = InsertedTitle.type,
                    ["pub_id"] = InsertedTitle.pub_id,
                    ["price"] = InsertedTitle.price,
                    ["advance"] = InsertedTitle.advance,
                    ["royalty"] = InsertedTitle.royalty,
                    ["ytd_sales"] = InsertedTitle.ytd_sales,
                    ["notes"] = InsertedTitle.notes,
                    ["pubdate"] = InsertedTitle.pubdate
                };


                return manager.ExecuteNonQuery("INSERT INTO titles (title_id, title, type, pub_id, price, advance, royalty, ytd_sales, notes, pubdate) VALUES (@title_id, @title, @type, @pub_id, @price, @advance, @royalty, @ytd_sales, @notes, @pubdate)", Parameters) > 0;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return false;
        }

        private static string GenerateUniqueTitleId(int TitlesCount)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 300);
            return "T" + Guid.NewGuid().ToString().Substring(0, 2) + (TitlesCount).ToString("D3");
        }

        public static bool UpdateTitle(Title UpdatedTitle)
        {
            try
            {
                Dictionary<string, object> Parameters = new()
                {
                    ["title_id"] = UpdatedTitle.title_id,
                    ["title"] = UpdatedTitle.title,
                    ["type"] = UpdatedTitle.type,
                    ["pub_id"] = UpdatedTitle.pub_id,
                    ["price"] = UpdatedTitle.price,
                    ["advance"] = UpdatedTitle.advance,
                    ["royalty"] = UpdatedTitle.royalty,
                    ["ytd_sales"] = UpdatedTitle.ytd_sales,
                    ["notes"] = UpdatedTitle.notes,
                    ["pubdate"] = UpdatedTitle.pubdate
                };


                return manager.ExecuteNonQuery("UPDATE titles SET title = @title, type = @type, pub_id = @pub_id, price = @price, advance = @advance, royalty = @royalty, ytd_sales = @ytd_sales, notes = @notes, pubdate = @pubdate WHERE title_id = @title_id", Parameters) > 0;
            }
            catch (Exception Ex) 
            {
                throw new Exception(Ex.Message);
            }
            return false;
        }


        public static bool DeleteTitle(Title DeletedTitle)
        {
            try
            {

                Dictionary<string, object> Param = new()
                {
                    ["title_id"] = DeletedTitle.title_id,
                };
                return manager.ExecuteNonQuery("DELETE FROM titles WHERE title_id = @title_id", Param) > 0;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }



        #region Mapping Function
        internal static TitlesList DataTableToTitleList(DataTable Dt)
        {
            TitlesList titles = new();
            try
            {
                for (int i = 0; i < Dt?.Rows?.Count; i++)
                    titles.Add(DataRowToTitle(Dt.Rows[i]));
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return titles;
        }
        internal static Title DataRowToTitle(DataRow Dr)
        {
            Title t = new()
            {
                title_id = Dr.Field<string>("title_id"),
                title = Dr.Field<string>("title"),
                type = Dr.Field<string>("type"),
                pubdate = Dr.Field<DateTime>("pubdate")
                //pubdate = (DateTime.TryParse(Dr["pubdate"]?.ToString() ?? "-1", out DateTime TempDate)) ? TempDate : DateTime.Now
            };

            try
            {
                t.pub_id = Dr.Field<string>("pub_id");

                if (decimal.TryParse(Dr["price"]?.ToString() ?? "-1", out decimal TempMoney))
                    t.price = TempMoney;

                if (decimal.TryParse(Dr["advance"]?.ToString() ?? "-1", out  TempMoney))
                    t.advance = TempMoney;

                if (int.TryParse(Dr["royalty"]?.ToString() ?? "-1", out int TempInt))
                    t.royalty = TempInt;

                if (int.TryParse(Dr["ytd_sales"]?.ToString() ?? "-1", out  TempInt))
                    t.ytd_sales = TempInt;

                t.notes = Dr.Field<string>("notes");

                //t.pub_name = Dr.Field<string>("pub_name");

                t.State = EntityState.UnChanged;
            }
            catch(Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return t;

        }

        #endregion
    }
}
