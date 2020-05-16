<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookInventory.aspx.cs" Inherits="BookListmain.BookInventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {

            //$(document).ready(function () {
            //$('.table').DataTable();
            // });

            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            //$('.table1').DataTable();
        });
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />

     <div class="container">
        <div class="row">
            <div class="col-md-5"> 
                <div class="card">
                    <div class="card-body">

                        

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Inventory Management</h4>                                   
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/books.png" width="100"/>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>

                        
                        <div class="row">
                            <div class="col-md-4">
                                <label>Title</label>
                               <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox cssClass="form-control" ID="txtTitle" runat="server" placeholder="TITLE"></asp:TextBox>
                                    </div>
                               </div>

                            </div>
                            <div class="col-md-8">
                                <label>Author</label>
                               <div class="form-group">
                                   
                                   <asp:TextBox cssClass="form-control" ID="txtAuthor" runat="server" placeholder="Author Name"></asp:TextBox>
                               </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-4">
                                <label>ISBN</label>
                               <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox cssClass="form-control" ID="txtISBN" runat="server" placeholder="ISBN"></asp:TextBox>
                                         <asp:Button class="btn btn-secondary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click1"  />
                                    </div>
                               </div>

                            </div>
                            <div class="col-md-8">
                                Publisher
                               <div class="form-group">
                                   
                                   <asp:TextBox cssClass="form-control" ID="txtPublisher" runat="server" placeholder="Publisher"></asp:TextBox>
                               </div>
                            </div>
                        </div>

                          <div class="row">
                            <div class="col-md-6">
                                <label>YEAR</label>
                               <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox cssClass="form-control" ID="txtYear" runat="server" placeholder="ISBN" TextMode="Date"></asp:TextBox>
                                         
                                    </div>
                               </div>

                            </div>
                            <div class="col-md-6">
                                <label>Book Description</label>
                               <div class="form-group">
                                   
                                   <asp:TextBox cssClass="form-control" ID="txtDescription" runat="server" placeholder="Description" TextMode="MultiLine"></asp:TextBox>
                               </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">  
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click1"  />
                               </div>

                            </div>

                            <div class="col-md-4">
                                <div class="form-group">  
                                    <asp:Button class="btn btn-warning btn-block btn-lg" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"   />
                               </div>

                            </div>

                            <div class="col-md-4">
                                <div class="form-group">  
                                    <asp:Button class="btn btn-danger btn-block btn-lg" ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                               </div>

                            </div>
                        </div>
                     
                     

 
                        </div>

                    </div>
                   
                </div>
                <br /><br />

             <div class="col-md-7">
                  <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Members List</h4>
                                                                        
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">

                                <asp:GridView class="table table-stripped table-bordered table-hover" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ISBN" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                                        <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
                                        <asp:BoundField DataField="ISBN" HeaderText="ISBN" ReadOnly="True" SortExpression="ISBN" />
                                        <asp:BoundField DataField="Publisher" HeaderText="Publisher" SortExpression="Publisher" />
                                        <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                    </Columns>
                                </asp:GridView>

                                </div>
                            </div>
           

           
        </div>
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bookinventorylistConnectionString %>" SelectCommand="SELECT * FROM [BookInventory]"></asp:SqlDataSource>
    </div>
        </div>
            </div>
           </div>


</asp:Content>
