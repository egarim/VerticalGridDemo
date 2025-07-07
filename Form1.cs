using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
using DevExpress.XtraEditors.Repository;
using VerticalGridDemo.Services;
using VerticalGridDemo.Models;

namespace VerticalGridDemo
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private List<Customer> customers;

        public Form1()
        {
            InitializeComponent();
            SetupVerticalGrid();
            LoadData();
        }

        private void LoadData()
        {
            customers = DataService.GetCustomers();
            
            // Populate the listbox with customers
            listBoxControl1.DataSource = customers;
            listBoxControl1.DisplayMember = "FullName";
            listBoxControl1.ValueMember = "Id";
            
            // Select the first customer by default and bind to grid
            if (customers.Count > 0)
            {
                listBoxControl1.SelectedIndex = 0;
                vGridControl1.DataSource = customers[0];
            }
        }

        private void SetupVerticalGrid()
        {
            // Clear any existing rows
            vGridControl1.Rows.Clear();
            
            // Create category rows for better organization
            CategoryRow personalInfo = new CategoryRow("Personal Information");
            CategoryRow contactInfo = new CategoryRow("Contact Information");
            CategoryRow locationInfo = new CategoryRow("Location Information");
            
            // Add category rows to the grid
            vGridControl1.Rows.Add(personalInfo);
            vGridControl1.Rows.Add(contactInfo);
            vGridControl1.Rows.Add(locationInfo);
            
            // Create property rows and add them under appropriate categories
            EditorRow idRow = new EditorRow("ID");
            idRow.Properties.FieldName = "Id";
            idRow.Properties.ReadOnly = true;
            personalInfo.ChildRows.Add(idRow);
            
            EditorRow firstNameRow = new EditorRow("First Name");
            firstNameRow.Properties.FieldName = "FirstName";
            personalInfo.ChildRows.Add(firstNameRow);
            
            EditorRow lastNameRow = new EditorRow("Last Name");
            lastNameRow.Properties.FieldName = "LastName";
            personalInfo.ChildRows.Add(lastNameRow);
            
            EditorRow fullNameRow = new EditorRow("Full Name");
            fullNameRow.Properties.FieldName = "FullName";
            fullNameRow.Properties.ReadOnly = true;
            personalInfo.ChildRows.Add(fullNameRow);
            
            EditorRow birthDateRow = new EditorRow("Birth Date");
            birthDateRow.Properties.FieldName = "BirthDate";
            personalInfo.ChildRows.Add(birthDateRow);
            
            EditorRow emailRow = new EditorRow("Email");
            emailRow.Properties.FieldName = "Email";
            contactInfo.ChildRows.Add(emailRow);
            
            EditorRow phoneRow = new EditorRow("Phone");
            phoneRow.Properties.FieldName = "Phone";
            contactInfo.ChildRows.Add(phoneRow);
            
            // Create country lookup row
            EditorRow countryRow = new EditorRow("Country");
            countryRow.Properties.FieldName = "Country";
            
            // Create and configure the lookup repository item
            RepositoryItemLookUpEdit countryLookup = new RepositoryItemLookUpEdit();
            countryLookup.DataSource = DataService.GetCountries();
            countryLookup.DisplayMember = "Name";
            countryLookup.ValueMember = ""; // Use the entire object
            countryLookup.ShowHeader = false;
            countryLookup.ShowLines = false;
            countryLookup.DropDownRows = 10;
            
            // Apply the lookup to the country row
            countryRow.Properties.RowEdit = countryLookup;
            locationInfo.ChildRows.Add(countryRow);
            
            EditorRow isActiveRow = new EditorRow("Is Active");
            isActiveRow.Properties.FieldName = "IsActive";
            personalInfo.ChildRows.Add(isActiveRow);
            
            // Expand all categories by default
            personalInfo.Expanded = true;
            contactInfo.Expanded = true;
            locationInfo.Expanded = true;
        }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Try multiple approaches to get the selected customer
            Customer selectedCustomer = null;
            
            // First try to get directly from SelectedItem
            if (listBoxControl1.SelectedItem is Customer customer)
            {
                selectedCustomer = customer;
            }
            // If that fails, try to get by index
            else if (listBoxControl1.SelectedIndex >= 0 && listBoxControl1.SelectedIndex < customers.Count)
            {
                selectedCustomer = customers[listBoxControl1.SelectedIndex];
            }
            
            // Bind the selected customer to the vertical grid
            if (selectedCustomer != null)
            {
                vGridControl1.DataSource = this.customers.Where(customer => customer.Id == selectedCustomer.Id).ToList() ;


                //vGridControl1.DataSource = new List<object> { customerData } ;

                //vGridControl1.DataSource=this.customers.Where(customers => customers.Id == selectedCustomer.Id).Select(c => new
                //{
                //    Id = c.Id,
                //    FirstName = c.FirstName,
                //    LastName = c.LastName,
                //    FullName = c.FullName,
                //    Email = c.Email,
                //    Phone = c.Phone,
                //    IsActive = c.IsActive
                //}).ToList();

          


                vGridControl1.Refresh();
            }
        }
    }
}
