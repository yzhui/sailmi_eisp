/******************************************************************************************
 			copyright (c) 2007 -  LeadNT.COM 

  class name: ColoNewModel.cs
  Description: This entity class is crate by LeadNT DBTable2EC.

 *****************************************************************************************/

using System;

namespace Eisp.Entity
{

  public class NewsModel
  {
     private Int32 _ID;
     private String _F_Title;
     private String _F_Content;
     private String _F_Keywords;
     private String _F_ClassName;
     private DateTime _F_Date;
     private String _F_Location;
     private int _F_ParentID;
     private Int32 _F_Lang;


     public NewsModel()
     {}


     public int F_ParentID
     {
         get { return this._F_ParentID; }
         set { this._F_ParentID=value ; }
     }

     public Int32 ID
     {
         get{return this._ID;}
         set{this._ID = value;}
     }

     public String F_Title
     {
         get{return this._F_Title;}
         set{this._F_Title = value;}
     }
     public String F_ClassName
     {
         get { return this._F_ClassName; }
         set { this._F_ClassName = value; }
     }
     public String F_Keyword
     {
         get { return this._F_Keywords; }
         set { this._F_Keywords = value; }
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

     public String F_Location
     {
         get{return this._F_Location;}
         set{this._F_Location = value;}
     }

     public Int32 F_Lang
     {
         get { return this._F_Lang; }
         set { this._F_Lang = value; }
     }
  }
}