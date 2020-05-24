/******************************************************************************************
 			copyright (c) 2007 -  LeadNT.COM 

  class name: ColoAdModel.cs
  Description: This entity class is crate by LeadNT DBTable2EC.

 *****************************************************************************************/

using System;

namespace Eisp.Entity
{

  public class AdModel
  {
     private Int32 _ID;
     private String _F_Pic;
     private String _F_Url;
     private DateTime _F_Date;
     private Int32 _F_Lang;

     public AdModel()
     {}


     public Int32 ID
     {
         get{return this._ID;}
         set{this._ID = value;}
     }

     public String F_Pic
     {
         get{return this._F_Pic;}
         set{this._F_Pic = value;}
     }

     public String F_Url
     {
         get{return this._F_Url;}
         set{this._F_Url = value;}
     }

     public DateTime F_Date
     {
         get{return this._F_Date;}
         set{this._F_Date = value;}
     }

     public Int32 F_Lang
     {
         get { return this._F_Lang; }
         set { this._F_Lang = value; }
     }
  }
}