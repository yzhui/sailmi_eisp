/******************************************************************************************
 			copyright (c) 2007 -  LeadNT.COM 

  class name: SysInfoModel.cs
  Description: This entity class is crate by LeadNT DBTable2EC.

 *****************************************************************************************/

using System;

namespace Eisp.Entity
{

  public class SysInfoModel
  {
     private Int32 _ID;
     private String _Content;
     private Int32 _Lang;
     private String _Title;
     private Int32 _InfoType;
     public SysInfoModel()
     {}


     public Int32 ID
     {
         get{return this._ID;}
         set{this._ID = value;}
     }

     public String Content
     {
         get{return this._Content;}
         set{this._Content = value;}
     }

     public String Title
     {
         get { return this._Title; }
         set { this._Title = value; }
     }

     public Int32 Lang
     {
         get { return this._Lang; }
         set { this._Lang = value; }
     }
     public Int32 InfoType
     {
         get { return this._InfoType; }
         set { this._InfoType = value; }
     }
  }
}