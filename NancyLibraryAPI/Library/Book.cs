using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyLibraryAPI.Models
{
    public class Book
    {

        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Author { get; set; }
        public virtual int YearPublished { get; set; }
        public virtual string Genre { get; set; }
        public virtual bool IsCheckedOut { get; set; }
        public virtual DateTime? LastCheckedOutDate
        {
            get
            {
                return this.lastCheckedOutDate.HasValue
                       ? this.lastCheckedOutDate.Value
                       : DateTime.Now;
            }
            set { this.lastCheckedOutDate = value; }
        }
        private DateTime? lastCheckedOutDate { get; set; }
        public virtual string NeatLastCheckedOutDate
        {
            get
            {
                if (LastCheckedOutDate.HasValue)
                {
                    return ((DateTime)this.LastCheckedOutDate).ToShortDateString();

                }
                else
                {
                    return null;
                }
            }
        }
    }
}