//------------------------------------------------------------------------------
// <auto-generated>
//    這個程式碼是由範本產生。
//
//    對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//    如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ganhua.Library.Repository.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public System.Guid Id { get; set; }
    
        public virtual BookTitle Title { get; set; }
        public virtual Member OnLoanTo { get; set; }
    }
}
