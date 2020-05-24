/******************************************************************************************
 			copyright (c) 2007 -  LeadNT.COM 

  class name: ColoProModel.cs
  Description: This entity class is crate by LeadNT DBTable2EC.

 *****************************************************************************************/

using System;

namespace Eisp.Entity
{

  public class ProModel 
  {
     private int _ProID;
     private String _F_ProName;
     private String _F_Proattributes;
     private String _F_ProDescription;
     private String _F_ProWashing;
     private String _F_ProSize;
     private Int32 _F_ProClassID;
     private DateTime _F_Date;
     private String _F_ProSizeTable;
     private String _F_ClassName;
     private String _F_ExtClass;
     private String _F_Pic;
     private String _F_ProSmallPic;
     private Boolean _F_IsTop;
     private Boolean _F_IsProvider;
     private Int32 _F_Lang;


     public ProModel()
     {}

     private int _F_Sort;

     public int F_Sort
     {
         get { return _F_Sort; }
         set { _F_Sort = value; }
     }
     public Boolean F_IsTop
     {
         get { return _F_IsTop; }
         set { _F_IsTop = value; }
     }
     public Boolean F_IsProvider
     {
         get { return _F_IsProvider; }
         set { _F_IsProvider = value; }
     }
     public String F_Pic
     {
         get { return this._F_Pic; }
         set { this._F_Pic = value; }
     }
     public String F_SmallPic
     {
         get { return this._F_ProSmallPic; }
         set { this._F_ProSmallPic = value; }
     }
     public String F_ClassName
     {
         get { return this._F_ClassName; }
         set { this._F_ClassName = value; }
     }

     public String F_ExtClass
     {
         get { return this._F_ExtClass; }
         set { this._F_ExtClass = value; }
     }

     public int ProID
     {
         get{return this._ProID;}
         set{this._ProID = value;}
     }

     public String F_ProName
     {
         get{return this._F_ProName;}
         set{this._F_ProName = value;}
     }

     public String F_Proattributes
     {
         get{return this._F_Proattributes;}
         set{this._F_Proattributes = value;}
     }

     public String F_ProDescription
     {
         get{return this._F_ProDescription;}
         set{this._F_ProDescription = value;}
     }

     public String F_ProWashing
     {
         get{return this._F_ProWashing;}
         set{this._F_ProWashing = value;}
     }

     public String F_ProSize
     {
         get{return this._F_ProSize;}
         set{this._F_ProSize = value;}
     }

     public Int32 F_ProClassID
     {
         get{return this._F_ProClassID;}
         set{this._F_ProClassID = value;}
     }

     public DateTime F_Date
     {
         get{return this._F_Date;}
         set{this._F_Date = value;}
     }

     public String F_ProSizeTable
     {
         get{return this._F_ProSizeTable;}
         set{this._F_ProSizeTable = value;}
     }

     public Int32 F_Lang
     {
         get { return this._F_Lang; }
         set { this._F_Lang = value; }
     }
  }
}