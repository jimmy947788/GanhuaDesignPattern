using Ganhua.Library.Services;
using Ganhua.Library.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ganhua.Library.UI.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayCustomers();
                DisplayBooks();
            }
        }

        private void DisplayCustomers()
        {
            FindMemberRequest request = new FindMemberRequest();
            LibraryService service = ServiceFactory.CreateLibraryService();
            request.All = true;
            FindMembersResponse response = service.FindMembers(request);

            rptMembers.DataSource = response.MembersFound;
            rptMembers.DataBind();
        }

        protected void btnCreateMember_Click(object sender, EventArgs e)
        {
            LibraryService service = ServiceFactory.CreateLibraryService();
            AddMemberRequest request = new AddMemberRequest();
            request.FirstName = txtFirstName.Text;
            request.LastName = txtLastName.Text;

            service.AddMember(request);

            DisplayCustomers();
        }

        protected void btnAddBook_Click(object sender, EventArgs e)
        {
            LibraryService service = ServiceFactory.CreateLibraryService();
            AddBookRequest request = new AddBookRequest();
            request.ISBN = ddlBookTitles.SelectedValue;

            service.AddBook(request);
            DisplayBooks();
        }

        private void DisplayBooks()
        {
            LibraryService service = ServiceFactory.CreateLibraryService();
            FindBooksRequest request = new FindBooksRequest();
            request.All = true;
            FindBooksResponse response = service.FindBooks(request);

            rptBooks.DataSource = response.Books;
            rptBooks.DataBind();

            FindBookTitlesRequest bookTitleRequest = new FindBookTitlesRequest();
            bookTitleRequest.All = true;
            FindBookTitlesResponse bookTitlesResponse = service.FindBookTitles(bookTitleRequest);


            ddlBookTitles.DataSource = bookTitlesResponse.BookTitles;
            ddlBookTitles.DataTextField = "Title";
            ddlBookTitles.DataValueField = "ISBN";
            ddlBookTitles.DataBind();

            rptBookTitles.DataSource = bookTitlesResponse.BookTitles;
            rptBookTitles.DataBind();
        }

        protected void btnAddTitle_Click(object sender, EventArgs e)
        {
            AddBookTitleRequest request = new AddBookTitleRequest();
            request.ISBN = txtBookISBN.Text;
            request.Title = txtBookTitle.Text;

            LibraryService service = ServiceFactory.CreateLibraryService();

            service.AddBookTitle(request);
            DisplayBooks();
        }
    }
}