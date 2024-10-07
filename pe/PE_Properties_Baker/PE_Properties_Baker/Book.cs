/* Book.cs
 * Last edited 10-03-24 by Wyatt Baker
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Properties_Baker
{
    internal class Book
    {
        // -------- Fields ------------------------------------------------------------------------
        // Get-only
        private string title;
        private string author;
        private int pageCount;

        // Assignable
        private string owner;
        private int timesRead;


        // -------- Methods -----------------------------------------------------------------------
        // --- Constructor
        public Book(string title, string author, int pageCount, string owner)
        {
            timesRead = 0;
            this.title = title;
            this.author = author;
            this.pageCount = pageCount;
            this.owner = owner;
        }


        // --- Properties
        // Get only
        public string Title
        {
            get { return title; }
        }

        public string Author
        {
            get { return author; }
        }

        public int PageCount
        {
            get { return pageCount; }
        }

        // Get and Set
        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public int TimesRead
        {
            get { return timesRead; }
            set 
            {
                // Only allow timesRead to be updated if the given value is an increase
                if (timesRead < value)
                {
                    timesRead = value;
                }
            }
        }


        // --- Behavior
        public void Print()
        {
            Console.WriteLine
                (
                $"{title} by {author} has {pageCount} pages. " +
                $"It is owned by {owner} and has been read {TimesRead} times."
                );
        }

    } // End Book Class
}
