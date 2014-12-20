//This code was taken from http://social.msdn.microsoft.com/profile/khaled%20jemni/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReaderWindowsPhone
{
     public class RSSItem
     {
         private string Description;

         public string Description1
         {
             get { return Description; }
             set { Description = value; }
         }

         private string Link;

         public string Link1
         {
             get { return Link; }
             set { Link = value; }
         }

         private string Title;

         public string Title1
         {
             get { return Title; }
             set { Title = value; }
         }
    }
}
