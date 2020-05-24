/******************************************************************************************
 			copyright (c) 2007 -  LeadNT.COM 

  class name: DownloadsModel.cs
  Description: This entity class is crate by LeadNT DBTable2EC.

 *****************************************************************************************/

using System;

namespace Eisp.Entity
{

  public class DownloadsModel
  {
     private Int32 _ID;
     private Int32 _F_FileType;
     private String _F_Content;
     private String _F_Title;
     private String _F_Desc;
     private DateTime _F_Date;
     private String _F_Size;
     private String _F_FileImage;
     private String _F_FileSmallImage;
     private String _F_Keywords;
     private Int32 _F_Lang;
     public DownloadsModel()
     {}


     public Int32 ID
     {
         get{return this._ID;}
         set{this._ID = value;}
     }

     public Int32 F_FileType
     {
         get { return this._F_FileType; }
         set { this._F_FileType = value; }
     }
     public String F_FileImage
     {
         get { return this._F_FileImage; }
         set { this._F_FileImage = value; }
     }

     public String F_FileSmallImage
     {
         get { return this._F_FileSmallImage; }
         set { this._F_FileSmallImage = value; }
     }
     public String F_Content
     {
         get{return this._F_Content;}
         set{this._F_Content = value;}
     }

     public String F_Title
     {
         get { return this._F_Title; }
         set { this._F_Title = value; }
     }

      public DateTime F_Date
     {
         get{return this._F_Date;}
         set{this._F_Date = value;}
     }

     public String F_Size
     {
         get { return this._F_Size; }
         set { this._F_Size = value; }
     }
     public String F_Desc
     {
         get { return this._F_Desc; }
         set { this._F_Desc = value; }
     }
     public String F_Keywords
     {
         get { return this._F_Keywords; }
         set { this._F_Keywords = value; }
     }
     public Int32 F_Lang
     {
         get { return this._F_Lang; }
         set { this._F_Lang = value; }
     }
  }
}