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
    public class PublisherManager
    {

        static DBManager manager = new();
        public static PublisherList GetAllPublishers()
        {
            return DataTableToPublisherList(manager.ExecuteDataTable("Select * from [publishers]"));
        }




        internal static PublisherList DataTableToPublisherList(DataTable dataTable)
        {
            PublisherList publisherList = new PublisherList();
                
            foreach (DataRow dr in dataTable.Rows)
            {
                publisherList.Add(DataRowToPublisher(dr));
            }

            return publisherList;
        }


        internal static Publisher DataRowToPublisher(DataRow dr)
        {
            Publisher publisher = new Publisher();
            try
            {
                publisher.pub_id = dr.Field<string>("pub_id");
                publisher.pub_name = dr.Field<string>("pub_name");
            }catch (Exception ex)
            {
                ///////
            }

            return publisher;
        }
    }
}
