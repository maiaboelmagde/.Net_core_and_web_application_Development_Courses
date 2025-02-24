using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Title:EntityBase
    {

        public required string title_id {  get; init; }

        string _title;
        string _type;
        string? _pub_id;
        decimal? _price;
        decimal? _advance;
        int? _royalty;
        int? _ytd_sales;
        string? _notes;
        DateTime _pubdate;


        public required string title 
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;

                    if(this.State != EntityState.Added)
                    {
                        this.State = EntityState.Modified;
                    }
                }
            }
        }

        public required string type {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;

                    if (this.State != EntityState.Added)
                    {
                        this.State = EntityState.Modified;
                    }
                }
            }
        }


        

        public decimal? price 
        { 
            get=> _price;
            set
            {
                if (_price != value)
                {
                    _price = value;

                    if (this.State != EntityState.Added)
                    {
                        this.State = EntityState.Modified;
                    }
                }
            }
        }

        public decimal? advance 
        {
            get => _advance;
            set
            {
                if (_advance != value)
                {
                    _advance = value;

                    if (this.State != EntityState.Added)
                    {
                        this.State = EntityState.Modified;
                    }
                }
            }
        }

        public int? royalty 
        {
            get => _royalty;
            set
            {
                if (_royalty != value)
                {
                    _royalty = value;

                    if (this.State != EntityState.Added)
                    {
                        this.State = EntityState.Modified;
                    }
                }
            } 
        }

        public int? ytd_sales 
        {
            get => _ytd_sales;
            set
            {
                if (_ytd_sales != value)
                {
                    _ytd_sales = value;

                    if (this.State != EntityState.Added)
                    {
                        this.State = EntityState.Modified;
                    }
                }
            }
        }


        public string? notes 
        {
            get => _notes;
            set
            {
                if (_notes != value)
                {
                    _notes = value;

                    if (this.State != EntityState.Added)
                    {
                        this.State = EntityState.Modified;
                    }
                }
            }
        }

        public required DateTime pubdate 
        {
            get => _pubdate;
            set
            {
                if (_pubdate != value)
                {
                    _pubdate = value;

                    if (this.State != EntityState.Added)
                    {
                        this.State = EntityState.Modified;
                    }
                }
            }
        }


        public string? pub_id
        {
            get => _pub_id;
            set
            {
                if (_pub_id != value)
                {
                    _pub_id = value;
                    if (this.State != EntityState.Added)
                    {
                        this.State = EntityState.Modified;
                    }
                }
            }
        }

        //string? PublisherName;
        public string? pub_name
        {
            get;
            set;
        }



    }
}
