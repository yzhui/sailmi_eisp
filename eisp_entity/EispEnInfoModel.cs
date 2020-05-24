/******************************************************************************************
 			copyright (c) 2007 -  LeadNT.COM 

  class name: SysInfoModel.cs
  Description: This entity class is crate by LeadNT DBTable2EC.

 *****************************************************************************************/

using System;

namespace Eisp.Entity
{

  public class EnInfoModel
  {
     private Int32 _ID;
     private String _EnName;
     private Int32 _Lang;
     private String _EnAddr;
     private String _EnContact;
     private String _EnOnlineContact;
     private String _EnKeywords;
     private String _EnDesc;
     private String _EnContent;
     public EnInfoModel()
     {}


     public Int32 ID
     {
         get{return this._ID;}
         set{this._ID = value;}
     }

     public String EnName
     {
         get { return this._EnName; }
         set { this._EnName = value; }
     }
     public String EnDetail
     {
         get { return this._EnContent; }
         set { this._EnContent = value; }
     }
     public String EnAddr
     {
         get { return this._EnAddr; }
         set { this._EnAddr = value; }
     }

     public Int32 Lang
     {
         get { return this._Lang; }
         set { this._Lang = value; }
     }
     public String EnContact
     {
         get { return this._EnContact; }
         set { this._EnContact = value; }
     }
     public String EnOnlineContact
     {
         get { return this._EnOnlineContact; }
         set { this._EnOnlineContact = value; }
     }
     public String EnKeywords
     {
         get { return this._EnKeywords; }
         set { this._EnKeywords = value; }
     }
     public String EnDesc
     {
         get { return this._EnDesc; }
         set { this._EnDesc = value; }
     }
  }
}