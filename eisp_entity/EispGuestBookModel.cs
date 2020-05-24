/******************************************************************************************
 			copyright (c) 2007 -  LeadNT.COM 

  class name: ColoGuestBookModel.cs
  Description: This entity class is crate by LeadNT DBTable2EC.

 *****************************************************************************************/

using System;

namespace Eisp.Entity
{

  public class GuestBookModel
  {
     private Int32 _ID;
     private String _F_Contacts;
     private String _F_Way;
     private String _F_Content;
     private DateTime _F_Date;
     private String _F_IP;
     private String _F_Replay;
     private int _F_Lang;
     public GuestBookModel()
     {}


     public Int32 ID
     {
         get{return this._ID;}
         set{this._ID = value;}
     }

     public String F_Contacts
     {
         get{return this._F_Contacts;}
         set{this._F_Contacts = value;}
     }

     public String F_Way
     {
         get{return this._F_Way;}
         set{this._F_Way = value;}
     }

     public String F_Content
     {
         get{return this._F_Content;}
         set{this._F_Content = value;}
     }

     public DateTime F_Date
     {
         get{return this._F_Date;}
         set{this._F_Date = value;}
     }

     public String F_IP
     {
         get{return this._F_IP;}
         set{this._F_IP = value;}
     }

     public String F_Replay
     {
         get{return this._F_Replay;}
         set{this._F_Replay = value;}
     }
     public Int32 F_Lang
     {
         get { return this._F_Lang; }
         set { this._F_Lang = value; }
     }


  }
}