/******************************************************************************************
 			copyright (c) 2007 -  LeadNT.COM 

  class name: ColoProClassModel.cs
  Description: This entity class is crate by LeadNT DBTable2EC.

 *****************************************************************************************/

using System;

namespace Eisp.Entity
{

  public class NewsClassModel
  {
     private Int32 _ID;
     private String _F_ClassName;
     private Int32 _F_ParentID;
     private Int32 _F_Sort;
     private Int32 _F_Lang;


     public NewsClassModel()
     {}


     public Int32 ID
     {
         get{return this._ID;}
         set{this._ID = value;}
     }

     public String F_ClassName
     {
         get{return this._F_ClassName;}
         set{this._F_ClassName = value;}
     }

     public Int32 F_ParentID
     {
         get{return this._F_ParentID;}
         set{this._F_ParentID = value;}
     }

     public Int32 F_Sort
     {
         get{return this._F_Sort;}
         set{this._F_Sort = value;}
     }

     public Int32 F_Lang
     {
         get { return this._F_Lang; }
         set { this._F_Lang = value; }
     }

  }
}